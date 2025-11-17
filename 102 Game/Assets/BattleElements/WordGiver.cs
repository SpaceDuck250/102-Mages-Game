using UnityEngine;


public class WordGiver : MonoBehaviour
{
    public string wordsAskedToType;
    int wordCount;

    UIManager UImanager;
    BattlePanelScript battlePanelScript;

    [SerializeField] TimerScript timerScript;

    public bool timerOn;
    public float timer;
    public float timerStartValue;
    public bool reachedDeadline;

    public bool challengeStarted = false;

    private void Awake()
    {
        UImanager = GameManager.instance.uiManager;
        battlePanelScript = GameManager.instance.uiManager.battlePanelScript;
    }

    private void Update()
    {
        if (!timerOn)
        {
            return;
        }

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = timerStartValue;
            reachedDeadline = true;
            timerOn = false;

            FinishWordChallenge();
        }
    }

    public void GenerateWordChallenge()
    {
        BattleManager battlemanager = BattleManager.instance;

        wordsAskedToType = battlemanager.currentBattler.ChooseRandomLine(battlemanager.currentBattler.playerAttackLines);

        wordCount = wordsAskedToType.Split(' ').Length;
        timerStartValue = CalculateTimeGiven(wordCount);

        timerScript.StartTimer(timerStartValue);

        timer = timerStartValue;
        timerOn = true;

        challengeStarted = true;
        reachedDeadline = false;

        battlePanelScript.SetPromptTextTo($"Please type: {wordsAskedToType}");
    }

    public float CalculateTimeGiven(int wordCount)
    {
        float wpmMin = 60;
        float wpmMax = 80;

        float randomWPM = Random.Range(wpmMin, wpmMax);
        float timeGiven = wordCount / randomWPM;
        timeGiven = timeGiven * 60;

        float timeToRead = 3;
        timeGiven += timeToRead;

        return timeGiven;

    }

    public void CheckIfCommandMatchesWord(string command) // The data from the commandprocessor will be send here when finished
    {
        if (command.ToLower() == wordsAskedToType.ToLower() && challengeStarted && !reachedDeadline)
        {
            FinishWordChallenge();
        }
    }

    public void FinishWordChallenge()
    {
        timerOn = false;
        challengeStarted = false;
        battlePanelScript.SetPromptTextTo("");

        timerScript.CloseTimer();
        float timeTaken = timerStartValue - timer;

        BattleManager.instance.LetPlayerAttack(timeTaken, wordCount);
    }
}
