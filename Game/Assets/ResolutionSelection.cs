using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionSelection : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Toggle isFullScreen;

    private Resolution[] resolutions;

    public RectTransform uiCanvas;
    public RectTransform inventoryCanvas;

    void Start() {
        resolutions = Screen.resolutions;
        isFullScreen.isOn = Screen.fullScreen;

        for ( int i = 0; i < resolutions.Length; i++ ) {
            string resString = resolutions[i].width.ToString() + " x " +resolutions[i].height.ToString();
            resolutionDropdown.options.Add(new Dropdown.OptionData(resString));
            if ( resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height ) {
                resolutionDropdown.value = i;
            }
        }
    }

    public void SetResolution() {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width,resolutions[resolutionDropdown.value].height, isFullScreen.isOn);
        uiCanvas.rect.Set(0,0,resolutions[resolutionDropdown.value].width / 160f, resolutions[resolutionDropdown.value].height / 160f);
        inventoryCanvas.rect.Set(0,0,resolutions[resolutionDropdown.value].width / 160f, resolutions[resolutionDropdown.value].height / 160f);
    }
}
