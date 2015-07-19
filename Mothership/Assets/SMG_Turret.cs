using UnityEngine;
using System.Collections;

public class SMG_Turret : Turret {
	public Projectile bullet;
	public Transform spawnPoint;
	public Transform axis;
	public float cooldown = 0.6f;
	public float projectileSpeed;
	private float lastShot;
	protected override void fire() {
		/*axis.LookAt (target.transform.position, Vector3.forward);
		Vector3 rot = axis.transform.eulerAngles;
		rot.z = 0;
		axis.transform.eulerAngles = rot;*/
		Enemy target = targets [0];
		if (Util.LookTowards (axis, target.transform)) {
			if (lastShot + cooldown < Time.time) {
				lastShot = Time.time;
				Projectile p = (Projectile)Instantiate (bullet);
				p.transform.position = spawnPoint.position;
				p.tag = tag;
				p.GetComponent<Rigidbody2D>().velocity = (target.transform.position - spawnPoint.position).normalized * projectileSpeed;
				GameController.instance.projectiles.add (p);

			}
		}
	}

}
