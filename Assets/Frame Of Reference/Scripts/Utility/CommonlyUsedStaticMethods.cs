using UnityEngine;
using UnityEngine.SceneManagement;
namespace PrototypingPlayground.UsefulScripts
{
    public static class CommonlyUsedStaticMethods
    {
        /// <summary>
        /// In build - Quits the game
        /// In playmode - Ends the playmode 
        /// </summary>
        public static void QuitGame()
        {
            Debug.Log($"Quitting Game");
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
        }
        
        /// <summary>
        /// This will reset the current scene.
        /// </summary>
        public static void ResetCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        /// <summary>
        /// This will load a scene based on a build index.
        /// </summary>
        /// <param name="buildIndex">Build index of the scene to load.</param>
        public static void OpenSceneFromBuildIndex(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex);
        }
        
        /// <summary>
        /// This will load the next scene in the build (based off scene index).
        /// </summary>
        public static void OpenNextSceneInBuild()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        /// <summary>
        /// This will load a scene based on a scene name in the build.
        /// </summary>
        /// <param name="sceneName">Name of the scene to load.</param>
        public static void OpenSceneWithSceneName(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
