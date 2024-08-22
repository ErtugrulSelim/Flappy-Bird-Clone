using UnityEngine.UI;
using UnityEngine;

public class SoundSlider : MonoBehaviour
{
    public Slider SFXSlider;
    public Image targetImage;
    private const string SFXKey = "VolumeLevel";

    public Color baseColor;
    public Color ClosedColor;
    void Start()
    {
        SFXSlider.onValueChanged.AddListener(OnVolumeChanged);
        SFXSlider.onValueChanged.AddListener(UpdateColor);

        float savedVolume = PlayerPrefs.GetFloat("VolumeLevel", 1f);
        SFXSlider.value = savedVolume;
    }

    void OnVolumeChanged(float value)
    {
        AudioManager.instance.SetVolumeSFX(value);
        PlayerPrefs.SetFloat(SFXKey, value);

    }

    void UpdateColor(float value)
    {
        float t = Mathf.InverseLerp(SFXSlider.minValue, SFXSlider.maxValue, value);
        targetImage.color = Color.Lerp(baseColor, ClosedColor, t);
    }
}
