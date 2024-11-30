using UnityEngine;
using UnityEngine.UI;

public class OptionScreen : MonoBehaviour
{

    public Toggle fullscreenTog, vsyncTog;
    public ResItem[] resolution;
    public int selectedResolution;
    public Text resolutionLabel;

    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = true;
        }
        else
        {
            vsyncTog.isOn = false;
        }

        //search for resolution on list...
        bool foundRes = false;

        for (int i = 0; i<resolution.Length || foundRes == true; i++)
        {
            if(Screen.width == resolution[i].horizontal && Screen.width == resolution[i].vertical)
            {
                foundRes = true;

                selectedResolution = i;
                UpdateResLabel();
            }
        }

        if (!foundRes){
            resolutionLabel.text = Screen.width.ToString()+" X "+Screen.height.ToString();
        }

    }

    public void ResLeft()
    {
        selectedResolution--;
        if(selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        UpdateResLabel();
    }
    public void ResRight()//cuidado com erro de logica...
    {
        selectedResolution++;
        if(selectedResolution > resolution.Length - 1)
        {
            selectedResolution = resolution.Length - 1;
        }
        UpdateResLabel();
    }

    public void UpdateResLabel(){
        resolutionLabel.text = resolution[selectedResolution].horizontal.ToString()+" X "+resolution[selectedResolution].vertical.ToString();
    }

    public void applyGhraphics()
    {
        //Apply Fullscreen...
        //Screen.fullScreen = fullscreenTog.isOn;

        //Apply VSYNC....
        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
            Debug.Log("VSYNC is ON");
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            Debug.Log("VSYNC is OFF");
        }

        //set resolution...
        Screen.SetResolution(resolution[selectedResolution].horizontal, resolution[selectedResolution].vertical, fullscreenTog.isOn);
    }
}

[System.Serializable] //permite ver a parte do resolucao no unity...

public class ResItem
{
    public int horizontal, vertical;
}
