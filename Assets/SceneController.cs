using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class SceneController : MonoBehaviour {
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
		InvokeRepeating("toggle", 5f, 5f);
	}

	void toggle() 
	{
		if (vrMode == VRMode.VROn)
		{
			Debug.Log("Starting Non-VR");
			VRSettings.LoadDeviceByName("None");
			vrMode = VRMode.VROff;
		}
		else
		{ 
			Debug.Log("Starting VR");
			VRSettings.LoadDeviceByName("daydream");
			vrMode = VRMode.VROn;
		}
	}
}
