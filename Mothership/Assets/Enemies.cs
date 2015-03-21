using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {

	public Enemy[] list { get { return _list; } }

	private Enemy[] _list = new Enemy[0];

	void Update() {

	}

	void LateUpdate() {
		_list = transform.GetComponentsInChildren<Enemy> ();
	}

	public void add(Enemy enemy) {
		enemy.transform.parent = transform;
	}
}
