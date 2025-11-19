using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{
    public static DontDestroyScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
