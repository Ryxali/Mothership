using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	public string targetSceneName;
	// Use this for initialization
	void Awake () {
		if(targetSceneName != "main")
			Application.LoadLevel (targetSceneName);
	}
}
