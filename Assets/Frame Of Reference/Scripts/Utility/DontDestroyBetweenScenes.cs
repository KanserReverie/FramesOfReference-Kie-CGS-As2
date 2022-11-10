using UnityEngine;

namespace PrototypingPlayground.UsefulScripts
{
    /// <summary>
    /// Add this to any GameObjects you want to persist between scenes.
    /// </summary>
    public class DontDestroyBetweenScenes : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
        private void Start()
        {
            DontDestroyOnLoad(this);
        }
        private void OnEnable()
        {
            DontDestroyOnLoad(this);
        }
    }
}
