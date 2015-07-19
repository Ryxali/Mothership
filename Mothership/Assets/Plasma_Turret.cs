using UnityEngine;
using System.Collections;

public class Plasma_Turret : Turret {

	public Projectile bullet;
	public float spawnDistance = 0.2f;
	public float cooldown = 1.0f;
	public float projectileSpeed = 4;
	private float lastShot;
	protected override void fire() {
		if (lastShot + cooldown < Time.time) {
			lastShot = Time.time;
			foreach(Enemy target in targets) {
				Projectile p = (Projectile) Instantiate(bullet);
				p.transform.position = transform.position + (target.transform.position - transform.TransformPoint(transform.localPosition)).normalized * spawnDistance;
				p.tag = tag;
				p.GetComponent<Rigidbody2D>().velocity = (target.transform.position - p.transform.position).normalized * projectileSpeed;
				GameController.instance.projectiles.add(p);
			}

			
		}
	}
}
