using UnityEngine;
using UnityEngine.UI;
using System.Collections;
[RequireComponent(typeof(Text))]
public class Tooltip : MonoBehaviour {
	private Text t;
	void Awake() {
		t = GetComponent<Text> ();
	}
	public void setText(string text) {
		t.text = text;
	}
}
