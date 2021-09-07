using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary> Will limit the framerate. </summary>
public class FrameRateLimiter : MonoBehaviour
{
    public TMP_Text frameRateLimiterText;
    public Slider frameRateLimiterSlider;

    private void Start()
    {
        Application.targetFrameRate = 120; // Default Number normally
        UpdateFrameText(120);
    }

    void vSyncCount()
    {
        // The number of vSync's that should pass for each frame.
        // 0 - 4
        // If this setting is set to a value other than 'Don't Sync' (0),
        // the value of Application.targetFrameRate will be ignored.
        QualitySettings.vSyncCount = 0;
        // 0 is Don't Sync.

        // 4 is the higher quality.
        // It will make 4 frames per sync.
        // It will be for frames behine.

        //QualitySettings.vSyncCount = 1;		// Will have one frame for 1 sync.
    }

    public void LimitFramerate(float _frameValue)
    {
        vSyncCount();
        int frameValue = Mathf.RoundToInt(_frameValue);
        Application.targetFrameRate = frameValue;
        UpdateFrameText(frameValue);
    }

    private void UpdateFrameText(int _currentFrameRate)
    {
        frameRateLimiterText.text = $"Current Frame Rate = {_currentFrameRate}";
        frameRateLimiterSlider.value = _currentFrameRate;
    }
}
