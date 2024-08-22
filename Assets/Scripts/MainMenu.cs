using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    public AudioClip GameMusic;
    public void PlayGame () 
    {
        SceneManager.LoadScene("Game");
        AudioManager.instance.StopMusic();
        AudioManager.instance.PlayMusic(GameMusic);
        gameOverMenu.SetActive(false);
    }
    public void QuitGame()
    {

        Application.Quit();
    }
}
