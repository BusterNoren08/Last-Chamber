using UnityEngine;
using UnityEngine.SceneManagement; // Needed for scene management

public class RestartScene : MonoBehaviour
{
    void Update()
    {
        // Check if the R key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Reload the current active scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}