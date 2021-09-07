using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Basic
{
    public class UIFunctions : MonoBehaviour
    {
        public void PlayButton()
        {
            SceneManager.LoadScene(1);
        }
        public void PauseButton()
        {
            Time.timeScale = 0;
        }
        public void ContinueButton()
        {
            Time.timeScale = 1;
        }
        public void RetryButton()
        {
            Time.timeScale = 1;
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
        public void QuitButton()
        {
            Time.timeScale = 1;

            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}