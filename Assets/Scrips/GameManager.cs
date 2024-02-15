using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    int score;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Pause();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        score = 0;
        scoreText.text= score.ToString();
        gameOver.SetActive(false);
        playButton.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        Pipe[] pipes = FindObjectsOfType<Pipe>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }

    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        player.enabled = false;
        playButton.SetActive(true);

    }
    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
