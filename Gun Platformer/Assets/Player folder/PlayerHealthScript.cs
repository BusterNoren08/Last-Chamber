using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealthScript : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives;
    public bool isDead = false;
    public TextMeshProUGUI text;
    public bool godMode;

    void Start()
    {
        currentLives = maxLives;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentLives -= damage;
        Debug.Log("Lives left: " + currentLives);

        if (currentLives <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;
        Debug.Log("Player died!");
        Time.timeScale = 0;
        text.enabled = true;
        Destroy(gameObject);


        // Reload the scene after a short delay
        //Invoke(nameof(RestartScene), 1.5f);
    }

    //void RestartScene()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
}
