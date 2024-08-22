
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Collections.LowLevel.Unsafe;


public class CanvasScalerSingleton : MonoBehaviour
{
    public CanvasScaler GameMenuCanvaScaler;
    public CanvasScaler MainMenuCanvaScaler;

    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "MainMenu")
        {
            PlayerPrefs.DeleteAll();
        }
        if (GameMenuCanvaScaler == null && MainMenuCanvaScaler == null)
        {
            GameMenuCanvaScaler = GetComponent<CanvasScaler>();
            MainMenuCanvaScaler = GetComponent<CanvasScaler>();
        }
        Vector2 screenResolution = new Vector2(Screen.width, Screen.height);
        MainMenuCanvaScaler.referenceResolution = screenResolution;
        Vector2 referenceResolution = MainMenuCanvaScaler.referenceResolution;
        PlayerPrefs.SetFloat("mainMenuReferenceResoulution.x", referenceResolution.x);
        PlayerPrefs.SetFloat("mainMenuReferenceResoulution.y", referenceResolution.y);

    }

    void Update()
    {
       

        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "MainMenu") 
        {
            MainMenuScale();
        }
        else if (currentSceneName == "Game") 
        {
            GameMenuScale();
        }
            
    }
      void GameMenuScale()
    {
        Vector2 screenResolution = new Vector2(Screen.width, Screen.height);
        float referenceResolutionx = PlayerPrefs.GetFloat("mainMenuReferenceResoulution.x");
        float referenceResoulutiony = PlayerPrefs.GetFloat("mainMenuReferenceResoulution.y");
        Vector2 referenceResolution = new Vector2(referenceResolutionx, referenceResoulutiony);

        float widthRatio = screenResolution.x / referenceResolution.x;
        float heightRatio = screenResolution.y / referenceResolution.y;

        float scaleFactor = Mathf.Min(widthRatio, heightRatio);

        GameMenuCanvaScaler.scaleFactor = scaleFactor;
    }

    void MainMenuScale()
    {
        Vector2 screenResolution = new Vector2(Screen.width, Screen.height);
        float referenceResolutionx = PlayerPrefs.GetFloat("mainMenuReferenceResoulution.x");
        float referenceResoulutiony = PlayerPrefs.GetFloat("mainMenuReferenceResoulution.y");
        Vector2 referenceResolution = new Vector2(referenceResolutionx, referenceResoulutiony);

        float widthRatio = screenResolution.x / referenceResolution.x;
        float heightRatio = screenResolution.y / referenceResolution.y;

        float scaleFactor = Mathf.Min(widthRatio, heightRatio);

        MainMenuCanvaScaler.scaleFactor = scaleFactor;

    }
}
