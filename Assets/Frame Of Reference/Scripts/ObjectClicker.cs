using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectClicker : MonoBehaviour
{
	/// <summary> This is the camera this will be moving.</summary>
	private Camera cam;

	/// <summary> This is the new transform that the player will lerp to.</summary>
	public Transform lerpTo;
	
	/// <summary>This will get all the components in the hierarchy. </summary>
	private void Awake()
	{
		cam = GetComponent<Camera>();
	}

	/// <summary> Mainly called to get the clicker or relaad the scene. </summary>
	private void Update()
	{
		// Checks the clicker.
		RayCastClicker();
		
		// Reloads the scene if R pressed.
		if(Input.GetKeyDown(KeyCode.R))
		{
			ReloadScene();
		}
	}

	/// <summary> Reloads the current scene. </summary>
	private void ReloadScene()
	{
		// Gets the current Scene Number.
		Scene scene = SceneManager.GetActiveScene();
		// Reloads this scene.
		SceneManager.LoadScene(scene.name);
	}

	/// <summary> This is used to check if something is clicked to move to it or go to the next level. </summary>
	private void RayCastClicker()
	{
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction * 100f,Color.magenta);
		
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			
			if(Physics.Raycast(ray, out hit))
			{
				Debug.Log(hit.transform.tag);
				
				if(hit.transform.CompareTag("Finish"))
				{
					NextLevel();
				}
				
				CameraTarget hitCam = hit.transform.GetComponentInChildren<CameraTarget>();
				if(hitCam != null)
				{
					lerpTo = hitCam.transform;
					transform.parent = null;
				}
			}
		}

		if(lerpTo != null)
		{
			cam.transform.position = Vector3.Lerp(cam.transform.position, lerpTo.position, Time.deltaTime * 5);
			cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, lerpTo.rotation, Time.deltaTime);

			if(Vector3.Distance(cam.transform.position, lerpTo.position) < Time.deltaTime * 5
				&& Quaternion.Angle(cam.transform.rotation, lerpTo.rotation) < 1f)
			{
				cam.transform.position = lerpTo.transform.position;
				cam.transform.rotation = lerpTo.rotation;
				transform.parent = lerpTo;
				lerpTo = null;
			}
		}
	}

	/// <summary> Goto the next level. </summary>
	private void NextLevel()
	{
		int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
		if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
		{
			SceneManager.LoadScene(nextSceneIndex);
		}
	}
}
