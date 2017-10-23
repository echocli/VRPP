using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clicked : MonoBehaviour {
    public TextAsset file;
    public string[] textLines;
    // Use this for initialization
    void Start () {
		if(file != null)
        {
            textLines = (file.text.Split('\n'));
        }
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    void OnMouseDown()
    {
        
    }
}
