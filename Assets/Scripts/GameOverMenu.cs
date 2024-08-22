using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public ColumnManager columnManager;
    public GameObject gameOverMenu;
    private bool gameended;
    [SerializeField] int lastScore;
    public TextMeshProUGUI LastScore;
    public AudioClip GameMusic;

    public void Start()
    {
        gameOverMenu.SetActive(false);
    }
     void Update()
    {
        GameOver();
        lastScore = Collision.score;
    }
    public void GameOver()
    {
        gameended = Collision.gameend;
        if (gameended == true)
        {
            gameOverMenu.SetActive(true);
            columnManager.StopTimeBasedMovement();
            LastScore.text = "Score: " + lastScore;
        }

    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
        AudioManager.instance.StopMusic();
        AudioManager.instance.PlayMusic(GameMusic);
        gameOverMenu.SetActive(false);
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
