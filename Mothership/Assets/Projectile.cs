using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour {
	Vector3 start;
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.GetComponentInChildren<Enemy>() != null)
			Destroy (gameObject);
	}

	void Awake() {
		start = transform.position;
	}

	void Update() {
		if(Vector3.Distance(start, transform.position) > 100) {
			Destroy(gameObject);
		}
	}
}
