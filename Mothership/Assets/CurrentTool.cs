using UnityEngine;
using System.Collections;

public class CurrentTool : MonoBehaviour {
	public static CurrentTool instance {get; private set; }

	void Awake() {
		if (instance != null)
			Debug.LogError ("Multiple CurrentTool Objects!");
		instance = this;
	}

	public Turret current { get; private set; }

	public void selectTurret(Turret t) {
		current = t;
	}

	public void deselect() {
		current = null;
	}
}
