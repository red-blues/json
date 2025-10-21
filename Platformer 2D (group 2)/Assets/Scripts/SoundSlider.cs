using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private string mixerParameterName;
    [SerializeField] private AudioMixer audioMixer;

    private void Awake()
    {
        volumeSlider.onValueChanged.AddListener(UpdateMixerVolume);
    }

    private void Start()
    {
        UpdateMixerVolume(volumeSlider.value);
    }

    private void UpdateMixerVolume(float value)
    {
        float volume = value == 0 ? -80f : Mathf.Log10(value) * 20;
        audioMixer.SetFloat(mixerParameterName, volume);
    }
}
