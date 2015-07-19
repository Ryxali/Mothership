using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {
	[Range(10, 1)]
	public float maxZoom = 2;
	[Range(20, 10)]
	public float minZoom = 10;
	private float baseSize;
	private float curZoom = 10;
	// Use this for initialization
	void Start () {
		baseSize = GetComponent<Camera>().orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		curZoom -= Input.GetAxis ("Mouse ScrollWheel") * 4;
		curZoom = Mathf.Clamp (curZoom, maxZoom, minZoom);
		GetComponent<Camera>().orthographicSize = baseSize * curZoom / 10.0f;
	}
}
