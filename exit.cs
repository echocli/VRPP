using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ((OVRInput.Get (OVRInput.Axis1D.PrimaryIndexTrigger)) > 0.0f) {
			exitQuiz ();
		}
	}
    public void exitQuiz()
    {
        Initiate.Fade("Classroom", Color.black, 2.0f);
    }
}
