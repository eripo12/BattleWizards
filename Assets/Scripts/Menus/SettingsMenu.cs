using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start ()
    {
        resolutions = Screen.resolutions;
        //Clear out resolution options in dropdown
        resolutionDropdown.ClearOptions();
        //Create list of new options
        List<string> options = new List<string>();
        //Move through each element and create a resolution

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
           string option = resolutions[i].width + " x " + resolutions[i].height;
           options.Add(option); 

           if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
           {
                currentResolutionIndex = i;
           }
        }
        //Add resolution
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume (float volume)
    {
       audioMixer.SetFloat("volume", volume);
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
