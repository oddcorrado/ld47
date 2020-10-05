using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    [SerializeField] GameObject pauseButton;

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pauseButton.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuLevels");
        pauseButton.SetActive(true);
        gameObject.SetActive(false);
    }
}
