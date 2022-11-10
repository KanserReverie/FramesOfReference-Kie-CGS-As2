using UnityEngine;

public class MainMenu : MonoBehaviour
{
    /// <summary> This is the camera this will be moving.</summary>
    private Camera cam;

    /// <summary> This is the new transform that the player will lerp to.</summary>
    public Transform lerpTo;

    /// <summary> The speed the player will jump between people at. </summary>
    [SerializeField] private float jumpMovingSpeed = 5f;

    /// <summary> The speed the player will rotate during jumps between people. </summary>
    [SerializeField] private float jumpRotationSpeed = 3f;

    /// <summary> When player will start jumping between people during the menu scene. </summary>
    [SerializeField] private float jumpStartTime = 0f;

    /// <summary> The time between player will start jumping between people in the menu scene. </summary>
    [SerializeField] private float jumpRepeatTime = 5f;

    /// <summary>This will get all the components in the hierarchy. </summary>
    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    /// <summary> When the game starts invoke the repeating. </summary>
    private void Start()
    {
        // Shoots a ray from the middle of the screen.
        InvokeRepeating("RayCastClick", jumpStartTime, jumpRepeatTime);
    }

    /// <summary> Mainly called to get the clicker or relaad the scene. </summary>
    private void Update()
    {
        // If it is meant to be moving to a target, lerp to it
        if (lerpTo != null)
        {
            MoveToTarget();
        }
    }

    /// <summary> This will lerp the camera to the target.</summary>
    private void MoveToTarget()
    {
        // This will lerp the Cam Position (Vector3) to the new position at deltaTime * jumpMovingSpeed.
        cam.transform.position = Vector3.Lerp(cam.transform.position, lerpTo.position, Time.deltaTime * jumpMovingSpeed);

        // This will lerp the Cam Rotation (Quaternion) to the new position at deltaTime * jumpMovingSpeed.
        cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, lerpTo.rotation, Time.deltaTime * jumpRotationSpeed);

        // If the position and rotation are close enough to the desination and at the correct angle.
        if (Vector3.Distance(cam.transform.position, lerpTo.position) < Time.deltaTime * 5 && Quaternion.Angle(cam.transform.rotation, lerpTo.rotation) < 1f)
        {
            // We are running this just to make sure the parent has made it to the final destination.
            // In all honesty you should know if it has by if it becomes a child of the new target object.
            // Debug.Log("Hit end destination and will now parent to - " + lerpTo.name);
            // Make the position = the target position.
            cam.transform.position = lerpTo.transform.position;
            // Make the rotation = the target rotation.
            cam.transform.rotation = lerpTo.rotation;
            // Make the parent = the destionation
            transform.parent = lerpTo;
            // Removes the target for this Camera to move to by making it = null.
            lerpTo = null;
        }
    }

    /// <summary> This is used to check if something is clicked to move to it or go to the next level. </summary>
    private void RayCastClick()
    {
        // This is a simple null check, thanks Rider.
        if (Camera.main is { })
        {
            // This gets a Ray from the middle of the screen.
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            // Makes a RaycastHit.
            RaycastHit hit;
            // If the Raycast hits an object.
            if (Physics.Raycast(ray, out hit))
            {
                // This will print the tag of the object.
                // Debug.Log(hit.transform.tag);
                // This goes through the children of the said gameObject and finds the one which has the "CameraTarget" on it.
                CameraTarget hitCam = hit.transform.GetComponentInChildren<CameraTarget>();
                // If it does get a target.
                if (hitCam != null)
                {
                    // Will make the "lerpTo" target = the transform of the new GameObject.
                    lerpTo = hitCam.transform;
                    // Deattaches this GameObject from the current parrent and makes it not have any parrent.
                    // It does this by making the parent null and bringing it back to the base layer.
                    transform.parent = null;
                }
            }
        }
    }
}
