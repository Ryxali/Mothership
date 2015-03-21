using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {

	public void add(Projectile projectile) {
		projectile.transform.parent = transform;
	}
}
