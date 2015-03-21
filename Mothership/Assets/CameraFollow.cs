using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	Transform target;
	// Use this for initialization
	void Awake () {
		target = FindObjectOfType<ShipController> ().transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target != null) {
			transform.position = Vector3.Lerp(transform.position, target.position, 0.2f);
		}
	}
}
