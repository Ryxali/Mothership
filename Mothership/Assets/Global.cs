using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Global : MonoBehaviour {

	private static Stack<string> sceneHistory = new Stack<string>();

	public static void addToHistory(string scene) {
		sceneHistory.Push (scene);
	}

	public static string popFromHistory() {
		return sceneHistory.Pop ();
	}

	public static string peekFromHistory() {
		return sceneHistory.Peek ();
	}
}
