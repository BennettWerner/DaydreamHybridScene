using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class SceneController : MonoBehaviour {
	public GameObject VRGroup;
	public enum VRMode 
	{ 	
		VROn,
		VROff
	}
	VRMode vrMode;
	// Use this for initialization
	void Awake () 
	{
		vrMode = VRMode.VROff;
		DontDestroyOnLoad(gameObject);
		InvokeRepeating("toggle", 10f, 10f);
	}

	void toggle() 
	{
		if (vrMode == VRMode.VROn)
		{
			Debug.Log("Starting Non-VR");
			VRGroup.SetActive(false);
			vrMode = VRMode.VROff;
		}
		else
		{ 
			Debug.Log("Starting VR");
			vrMode = VRMode.VROn;
			VRGroup.SetActive(true);
		}
		StartCoroutine(switchVRMode());
	}

	IEnumerator switchVRMode()
	{ 
		VRSettings.LoadDeviceByName(vrMode==VRMode.VROn?"daydream":"");
		yield return null;
		VRSettings.enabled = vrMode==VRMode.VROn;
	}
}
