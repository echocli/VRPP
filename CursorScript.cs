using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorScript : MonoBehaviour {
	private Scene currentScene;
	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene ();
		string name = currentScene.name;
		if (name == "quiz") {
			Cursor.visible = true;
			Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
			Cursor.visible = true;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
