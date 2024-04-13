using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public float score;
    public TextMeshProUGUI scoreText;
    public GameOverMenu gameOverMenu;
    public int livesLeft;
    public GameObject[] lives;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
        gameOver = false;
        BuildLivesArray();
    }

    private void BuildLivesArray()
    {
        livesLeft = 3;
        lives = new GameObject[livesLeft];
        lives[0] = GameObject.Find("Life1");
        lives[1] = GameObject.Find("Life2");
        lives[2] = GameObject.Find("Life3");
        for (int i = 0; i < livesLeft; i++)
        {
            lives[i].SetActive(true);
        }
    }

    public void increaseScore(float amount)
    {
        score = score + amount + 1;
        scoreText.text = "Score: " + score.ToString();
    }

    public void DecreaseLives()
    {
        livesLeft--;
        lives[livesLeft].SetActive(false);
    }

    public void EndGame()
    {
        gameOverMenu.GameOver();
    }
}
