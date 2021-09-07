using System.Linq;	// <--- SQL but for your code.
using UnityEngine;

public class Settings : MonoBehaviour
{
    // Need to limit frame rate in game.
    void LimitFramrate(int target)
    {
        // This is if you want to make it equal target.
        // Application.targetFrameRate = target;

        Application.targetFrameRate = 120;  // Default Number normally

        // Will go to systems default framerate.
        // -1 normally is a special case in prograamming.
        //		Application.targetFrameRate = -1;
    }

    void vSyncCount()
    {
        // The number of vSync's that should pass for each frame.
        // 0 - 4
        // If this setting is set to a value other than 'Don't Sync' (0),
        // the value of Application.targetFrameRate will be ignored.
        QualitySettings.vSyncCount = 0;
        // 0 is Don't Sync.
        //QualitySettings.vSyncCount = 1;		// Will have one frame for 1 sync.

        // 4 is the higher quality.
        // It will make 4 frames per sync.
        // It will be for frames behine.
    }

    void ChangeResolution()
    {
        Resolution[] allowedRes = Screen.resolutions;   // <--- Shows all avaliable resolutions

        var example = from s in allowedRes
                      where s.refreshRate == 30
                      select s.height;

        // var example = allowedRes.
        // Use allowedRes to fill up a dropdown in Unity.

        Resolution res = new Resolution();

        res.height = 1080;
        res.width = 1920;
        res.refreshRate = 60;

        // Fill a dropdown in Unity will allowedRes.
        // When the user selects a dropdown.
        // Change the resolution to that value.

        int selectedFromDropdown = 5;
        Screen.SetResolution(allowedRes[selectedFromDropdown].height,
            allowedRes[selectedFromDropdown].width,
            true, // Full Screen or not
        allowedRes[selectedFromDropdown].refreshRate);
    }
}
