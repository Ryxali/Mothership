using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
[ExecuteInEditMode]
public class Turret : MonoBehaviour {

	public float radius_L { get; private set; }
	public float radius_R { get; private set; }

	public float maxAttackRadius = 30.0f;
	public float maxAttackRadius_L = 0;
	public float maxAttackRadius_R = 0;
	public int maxTargets = 1;
	public TurretSize size;

	public bool instantiated { get; private set; }
	public bool online { get; private set; }

	protected Enemy[] targets;

	public void instantiate(TurretSlot s) {
		radius_L = Mathf.Min(s.maxAttackRadius + s.maxAttackRadius_L, maxAttackRadius + maxAttackRadius_L);
		radius_R = Mathf.Min(s.maxAttackRadius + s.maxAttackRadius_R, maxAttackRadius + maxAttackRadius_R);
		instantiated = true;
	}

	void Update () {
		if (Application.isEditor) {
			maxAttackRadius = Mathf.Max((Mathf.Min(maxAttackRadius*2 + maxAttackRadius_L + maxAttackRadius_R, 360) - maxAttackRadius_L - maxAttackRadius_R)/2, 0);
			maxAttackRadius_L = Mathf.Max(Mathf.Min(maxAttackRadius_L, 180-maxAttackRadius), 0);
			maxAttackRadius_R = Mathf.Max(Mathf.Min(maxAttackRadius_R, 180-maxAttackRadius), 0);

			Vector3 l = transform.TransformDirection(Vector3.up);
			Vector3 r = transform.TransformDirection(Vector3.up);
			Quaternion ql = Quaternion.AngleAxis((-maxAttackRadius - maxAttackRadius_L), Vector3.back);
			Quaternion qr = Quaternion.AngleAxis((maxAttackRadius + maxAttackRadius_R), Vector3.back);
			l = ql * l;
			r = qr * r;

			Vector3 l2 = transform.TransformDirection(Vector3.up);
			Vector3 r2 = transform.TransformDirection(Vector3.up);
			Quaternion ql2 = Quaternion.AngleAxis((-radius_L), Vector3.back);
			Quaternion qr2 = Quaternion.AngleAxis((radius_R), Vector3.back);
			l2 = ql2 * l2;
			r2 = qr2* r2;

			Debug.DrawLine(transform.position, transform.position + l, Color.yellow);
			Debug.DrawLine(transform.position, transform.position + r, Color.yellow);

			Debug.DrawLine(transform.position, transform.position + l2, Color.red);
			Debug.DrawLine(transform.position, transform.position + r2, Color.red);
		}
		if (Application.isPlaying) {
			if(online) {
				targets = findTargets (maxTargets);
				if(targets != null && targets.Length > 0) {
					fire();
				}
			}
		}
	}

	protected virtual void fire() {

	}

	public Enemy[] findTargets(int count) {
		Enemy[] enemies = GameController.instance.enemies.list;

		List<Enemy> candidates = new List<Enemy> ();
		Enemy candidate = null;
		float candidateDist = 100000.0f;
		foreach(Enemy e in enemies) {

			Vector3 x = Vector3.Cross(transform.up, Vector3.back);
			//Debug.Log("Cross: " + x);
			/*Debug.Log("dir: " + transform.up);/*
			float angle =  Vector3.Dot( x, e.transform.position - transform.position);*/
			float side = Vector3.Dot( x, e.transform.position - transform.TransformPoint(transform.localPosition));
			float angle = Vector3.Angle(transform.up, (e.transform.position - transform.position).normalized);

			//Debug.Log("ANGLE: " + angle);
			if(side < 0) {
				if(angle < radius_L) {
					candidates.Add(e);
					/*float dist = Vector3.Distance(transform.position, e.transform.position);
					if(dist < candidateDist) {
						candidate = e;
						candidateDist = dist;
					}*/
				}
			} else {
				if(angle < radius_R) {
					candidates.Add(e);
					/*float dist = Vector3.Distance(transform.position, e.transform.position);
					if(dist < candidateDist) {
						candidate = e;
						candidateDist = dist;
					}*/
				}
			}

		}

		candidates = candidates.OrderBy (o => Vector3.Distance (transform.position, o.transform.position)).ToList ();
		Enemy[] result = new Enemy[Mathf.Min(candidates.Count, count)];
		for (int i = 0; i < result.Length; ++i) {
			result[i] = candidates[i];
		}
		return result;
	}

	public void activate() {
		online = true;
	}

	public void deactivate() {
		online = false;
	}

}
