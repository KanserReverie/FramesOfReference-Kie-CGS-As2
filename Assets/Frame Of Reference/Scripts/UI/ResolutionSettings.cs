using UnityEngine;
using UnityEngine.UI;

/// <summary> Basically will have all the resolutions in the dragged in dropdown. </summary>
public class ResolutionSettings : MonoBehaviour
{
    public Dropdown resolutionsDropdown;

    private Resolution[] allowedRes;

    public void Start()
    {
        allowedRes = Screen.resolutions;    // <--- Shows all avaliable resolutions

        resolutionsDropdown.onValueChanged.AddListener(delegate { Screen.SetResolution(allowedRes[resolutionsDropdown.value].width, allowedRes[resolutionsDropdown.value].height, Screen.fullScreen); });

        // resolutionsDropdown.onValueChanged.AddListener(delegate 
        // { 
        //     Screen.SetResolution(
        //         allowedRes[resolutionsDropdown.value].width, 
        //         allowedRes[resolutionsDropdown.value].height, 
        //         false); 
        // });

        for (int i = 0; i < allowedRes.Length; i++)
        {
            resolutionsDropdown.options[i].text = ResToString(allowedRes[i]);
            resolutionsDropdown.value = i;
            resolutionsDropdown.options.Add(new Dropdown.OptionData(resolutionsDropdown.options[i].text));

        }

        string ResToString(Resolution res)
        {
            return res.width + " x " + res.height;
        }

    }

    public void ResolutionValueChanged(int resolutionIndex)
    {
        Resolution resolution = allowedRes[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
