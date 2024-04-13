using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    // Start is called before the first frame update
    public static bool isPaused;
    void Start()
    {
        gameOverMenu.SetActive(false);
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Game");
    }
}
