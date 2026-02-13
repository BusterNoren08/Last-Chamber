using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int respawnScene;

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

    public void SetRespawnScene(int sceneName)
    {
        respawnScene = sceneName;
    }

    public int GetRespawnScene()
    {
        return respawnScene;
    }
}
