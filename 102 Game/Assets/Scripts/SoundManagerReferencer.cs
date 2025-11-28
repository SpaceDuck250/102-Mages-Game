using UnityEngine;

public class SoundManagerReferencer : MonoBehaviour
{
    SoundManagerScript soundManager;

    BattleManager battleManager;

    DialogueManager dialogueManager;

    private void Start()
    {
        if (DontDestroyScript.instance == null)
        {
            return;
        }

        soundManager = DontDestroyScript.instance.transform.Find("SoundManager").GetComponent<SoundManagerScript>();
        dialogueManager = DialogueManager.instance;

        battleManager = GameManager.instance.battleManager;

        battleManager.onBattleStart += PlayBattleMusic;
        battleManager.onBattleEnd += PlayNormalMusic;
        dialogueManager.onType += UnpauseTyping;
        dialogueManager.onTypeEnd += PauseTyping;

        battleManager.onPlayerAttack += PlayAttackSounds;
        battleManager.onEnemyAttack += PlayEnemyAttackSound;

        PlayNormalMusic(null);
        
    }

    private void OnDestroy()
    {
        if (DontDestroyScript.instance == null)
        {
            return;
        }

        battleManager.onBattleStart -= PlayBattleMusic;
        battleManager.onBattleEnd -= PlayNormalMusic;

        dialogueManager.onType -= UnpauseTyping;
        dialogueManager.onTypeEnd -= PauseTyping;

        battleManager.onPlayerAttack -= PlayAttackSounds;
        battleManager.onEnemyAttack -= PlayEnemyAttackSound;

    }

    private void PlayAttackSounds(float damage, Battler currentBattler)
    {
        AudioClip damageClip = ChooseSoundDependingOnDamage(damage);
        soundManager.PlaySoundFX(damageClip);
    }

    private void PlayEnemyAttackSound(float damage, Battler currentBattler)
    {
        AudioClip enemyHit = soundManager.enemyHit;
        soundManager.PlaySoundFX(enemyHit);
    }

    private AudioClip ChooseSoundDependingOnDamage(float damage)
    {
        AudioClip weakHit = soundManager.weakHit;
        AudioClip normalHit = soundManager.normalHit;
        AudioClip strongHit = soundManager.strongHit;

        float weakRange = 18;
        float normalRange = 32;


        if (damage < weakRange)
        {
            return weakHit;
        }
        else if (damage < normalRange)
        {
            return normalHit;
        }
        else
        {
            return strongHit;
        }
    }

    private void UnpauseTyping()
    {
        soundManager.UnpauseTyping();
    }

    private void PauseTyping()
    {
        soundManager.PauseTyping();
    }

    private void PlayBattleMusic(Battler obj)
    {
        AudioSource musicSrc = soundManager.musicSrc;
        musicSrc.Stop();

        AudioSource battleMusicSrc = soundManager.battleMusicSrc;
        AudioClip battleMusic = soundManager.battleMusic;
        soundManager.PlayMusic(battleMusicSrc, battleMusic);

    }

    private void PlayNormalMusic(Battler obj)
    {
        AudioSource battleMusicSrc = soundManager.battleMusicSrc;
        battleMusicSrc.Stop();

        AudioSource musicSrc = soundManager.musicSrc;
        AudioClip normalMusic = soundManager.musicClip2;
        soundManager.PlayMusic(musicSrc, normalMusic);

    }




}
