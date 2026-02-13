using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public TextMeshProUGUI text;
    

    private void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            text.enabled = false;
            Time.timeScale = 1;

            //// Get the saved respawn scene from GameManager
            //int respawnScene = GameManager.instance.GetRespawnScene();
            Debug.Log("Reload");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
