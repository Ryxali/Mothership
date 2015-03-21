using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance { get; private set; }

	public Enemies enemies { get; private set; }
	public ShipController ship { get; private set; }
	public Projectiles projectiles { get; private set; }
	// Use this for initialization
	void Awake () {
		if (instance != null)
			Debug.LogError ("Multiple controllers!");
		instance = this;
		enemies = GetComponentInChildren<Enemies> ();
		projectiles = GetComponentInChildren<Projectiles> ();
		ship = FindObjectOfType<ShipController> ();
		ship.enable ();
	}
}
