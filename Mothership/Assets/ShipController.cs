using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
	public bool online { get; private set; }

	public void enable() {
		online = true;
		Turret [] turrs = transform.GetComponentsInChildren<Turret> ();
		foreach (Turret t in turrs) {
			t.activate();
		}

		TurretSlot[] tslots = transform.GetComponentsInChildren<TurretSlot> ();
		foreach (TurretSlot t in tslots) {
			t.hide ();
		}
	}

	public void disable() {
		online = false;
		Turret [] turrs = transform.GetComponentsInChildren<Turret> ();
		foreach (Turret t in turrs) {
			t.deactivate();
		}
		
		TurretSlot[] tslots = transform.GetComponentsInChildren<TurretSlot> ();
		foreach (TurretSlot t in tslots) {
			t.show ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (online) {
			rigidbody2D.velocity = transform.TransformDirection(Vector2.up) * Input.GetAxis("Vertical");
			rigidbody2D.angularVelocity = -Input.GetAxis("Horizontal") * 90;
		}
	}
}
