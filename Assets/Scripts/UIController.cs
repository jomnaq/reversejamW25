using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Canvas pauseCanvas;   
    private bool isPaused = false; 

    void Start()
    {
        pauseCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isPaused)
            {
                Restart();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; 
        pauseCanvas.gameObject.SetActive(true);  
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; 
        pauseCanvas.gameObject.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
