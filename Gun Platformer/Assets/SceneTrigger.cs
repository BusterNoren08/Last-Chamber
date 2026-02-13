using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public int sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.SetRespawnScene(sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
