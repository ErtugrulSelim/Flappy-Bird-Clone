using UnityEngine.UI;
using UnityEngine;

public class MusicSlider : MonoBehaviour
{
    public Slider GameMusicSlider;
    public Image targetImage;
    private const string MusicKey = "VolumeLevel";

    public Color baseColor;
    public Color ClosedColor;
    void Start()
    {
        GameMusicSlider.onValueChanged.AddListener(OnVolumeChanged);
        GameMusicSlider.onValueChanged.AddListener(UpdateColor);

        float savedVolume = PlayerPrefs.GetFloat("VolumeLevel", 1f);
        GameMusicSlider.value = savedVolume;
    }

    void OnVolumeChanged(float value)
    {
        AudioManager.instance.SetVolumeMusic(value);
        PlayerPrefs.SetFloat(MusicKey, value);

    }

    void UpdateColor(float value)
    {
        float t = Mathf.InverseLerp(GameMusicSlider.minValue, GameMusicSlider.maxValue, value);
        targetImage.color = Color.Lerp(baseColor, ClosedColor, t);
    }
}
