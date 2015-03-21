using UnityEngine;
using System.Collections;

public class CameraPan : MonoBehaviour {
	public Rect bounds = new Rect(-2, -2, 4, 4);
	[Range(10, 1)]
	public float maxZoom = 2;
	[Range(20, 10)]
	public float minZoom = 10;
	private float baseSize;
	private float curZoom = 10;

	private bool moving = false;
	private Vector3 movePoint;
	private Vector3 anchor;
	private Camera cam;


	// Use this for initialization
	void Awake () {
		cam = GetComponentInChildren<Camera> ();
		baseSize = cam.orthographicSize;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		curZoom -= Input.GetAxis ("Mouse ScrollWheel") * 4;
		curZoom = Mathf.Clamp (curZoom, maxZoom, minZoom);
		cam.orthographicSize = baseSize * curZoom / 10.0f;
		if (moving) {
			transform.position = anchor + (movePoint - Input.mousePosition) * 0.01f * (curZoom / 10.0f);
		}
	}

	void Update() {
		if (Input.GetMouseButtonDown (2)) {
			movePoint = Input.mousePosition;
			anchor = transform.position;
			moving = true;
			
		}
		if (Input.GetMouseButtonUp (2)) {
			moving = false;
		}
	}
}
