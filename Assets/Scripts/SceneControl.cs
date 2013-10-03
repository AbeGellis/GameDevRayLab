using UnityEngine;
using System.Collections;

public class SceneControl : MonoBehaviour {
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1))
			Application.LoadLevel("NPCBot");
		if (Input.GetKeyDown(KeyCode.Alpha2))
			Application.LoadLevel("ClickToMove");
		if (Input.GetKeyDown(KeyCode.Alpha3))
			Application.LoadLevel("Platformer");
	}
}
