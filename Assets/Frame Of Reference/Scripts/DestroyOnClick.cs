using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    /// <summary> Destroy on Click. </summary>
    void OnMouseDown()
    {
        // This object was clicked - do something.
        Destroy(this.gameObject);
    }
}
