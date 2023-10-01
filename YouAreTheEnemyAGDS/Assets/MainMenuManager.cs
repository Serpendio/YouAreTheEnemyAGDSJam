using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject SettingsMenu;
    [SerializeField] AudioMixer MainVolumeMixer;
    [SerializeField] Slider slider;
    float a, _volumePercent, _volumeSliderValue;
    private const string volumePlayerPrefKey = "Volume";


    private const string volumePercentPlayerPrefKey = "VolumePercent";

    protected float Volume
    {
        get
        {
            float volume;
            MainVolumeMixer.GetFloat("Vol", out volume);
            ////Debug.Log("Volume is now : " + volume + "  dB.");
            return volume;
        }
        set
        {
            MainVolumeMixer.SetFloat("Vol", value);
            ////Debug.Log("Volume Set! to : " + value + "  dB.");
        }
    }

    private void OnEnable()
    {
        LoadSettings();
    }

    private void Start()
    {
        
    }

    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    public void Settings()
    {
        SettingsMenu.SetActive(true);
        //slider.value = GetVolume();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Close()
    {
        SettingsMenu?.SetActive(false);
    }

    public void Save()
    {
        SetVolume(slider.value);
        Close();
    }


    private void SetVolume(float Volumepercentage)
    {
        float LinearVolume = 0f;
        Volumepercentage = (float)(Mathf.Round(Volumepercentage * 100) * 0.01);
        PlayerPrefs.SetFloat(volumePercentPlayerPrefKey, Volumepercentage);
        LinearVolume = DecibelToLinear(0.0f);
        LinearVolume *= Volumepercentage;
        Volume = LinearToDecibel(LinearVolume);
        ////Debug.Log("Volume  LEvel: " + LinearVolume);
        PlayerPrefs.SetFloat(volumePlayerPrefKey, Volume);
    }


    public void LoadSettings()
    {
        
        _volumeSliderValue = PlayerPrefs.GetFloat(volumePercentPlayerPrefKey, 1f);
        if (slider != null)
            slider.value = _volumeSliderValue;
    }

    public void SetVolumeSlider(float Volumepercentage)
    {
        _volumePercent = Volumepercentage;
    }

    public float GetVolume()
    {
        MainVolumeMixer.SetFloat("Vol", PlayerPrefs.GetFloat("volume", 0f));
        MainVolumeMixer.GetFloat("Vol", out a);
        return a;
    }

    private float LinearToDecibel(float linear)
    {
        float dB;

        if (linear != 0)
            dB = 20.0f * Mathf.Log10(linear);
        else
            dB = -144.0f;

        return dB;
    }

    private float DecibelToLinear(float dB)
    {
        float linear = Mathf.Pow(10.0f, dB / 20.0f);
        ////Debug.Log("Volume : "+ linear);
        return linear;
    }

}
