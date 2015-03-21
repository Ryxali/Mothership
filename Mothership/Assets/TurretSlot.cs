using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TurretSlot : MonoBehaviour {

	public float maxAttackRadius =  30.0f;
	public float maxAttackRadius_L = 0;
	public float maxAttackRadius_R = 0;
	public Turret turret { get; private set; }
	public GameObject indicator;
	public TurretSize size;

	public bool hidden { get; private set; }
	// Use this for initialization
	void Awake () {
		if (indicator == null) {
			Debug.LogError("indicator is null!");
		}
	}
	
	// Update is called once per frame
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
			Debug.DrawLine(transform.position, transform.position + l, Color.green);
			Debug.DrawLine(transform.position, transform.position + r, Color.green);
		} else {

		}
		

	}



	public void addTurret(Turret t) {
		Debug.Log ("addy");
		if (!fits (t.size))
			return;
		if (turret != null) {
			Destroy(turret.gameObject);
		}
		if (t.instantiated) {
			Debug.LogError("Tried to add an instantiated turret!");
			return;
		}
		turret = (Turret)Instantiate(t);
		turret.transform.parent = transform;
		turret.transform.position = transform.position;
		turret.transform.rotation = transform.rotation;
		turret.tag = tag;
		turret.instantiate (this);
		if (indicator != null)
			indicator.SetActive (false);
	}

	public void removeTurret() {
		if (turret != null) {
			Destroy(turret);
		}
		if (indicator != null)
			indicator.SetActive (true);
	}

	void OnMouseUp() {
		Debug.Log ("FOO");
		if (hidden)
			return;
		if (CurrentTool.instance.current != null) {
			addTurret(CurrentTool.instance.current);
		}
	}

	public bool fits(TurretSize t)  {
		switch (size) {
		case TurretSize.LARGE:
			return true;
			//goto case TurretSize.MEDIUM;
		case TurretSize.MEDIUM:
			if(t == TurretSize.MEDIUM) return true;
			goto case TurretSize.SMALL;
		case TurretSize.SMALL:
			if(t == TurretSize.SMALL) return true;
			goto case TurretSize.TINY;
		case TurretSize.TINY:
			if(t == TurretSize.TINY) return true;
			return false;
		default:
			Debug.LogError("Wierd enum: " + t);
			return false;
		}
	}

	public void hide() {
		hidden = true;
		indicator.SetActive (false);
	}

	public void show() {
		indicator.SetActive (true);
	}
}
