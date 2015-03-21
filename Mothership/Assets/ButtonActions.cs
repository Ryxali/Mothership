using UnityEngine;
using System.Collections;

public class ButtonActions : MonoBehaviour {

	public void enterScene(string name) {
		Global.addToHistory (Application.loadedLevelName);
		Application.LoadLevel (name);
	}

	public void goBack(int count = 1) {
		string s = "null";
		for(int i = 0; i < count; ++i) {
			string t = Global.popFromHistory ();
			if(t != null)
				s = t; 
		}
		if(!s.Equals("null"))
			Application.LoadLevel (s);
	}

	public void goBackOne() {
		goBack (1);
	}

	public void exit() {
		Application.Quit ();
	}

}
