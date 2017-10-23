using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class textboxManager : MonoBehaviour {
    public GameObject textbox;
    public Text theText;
    //public TextAsset[] textFile;
	public TextAsset one;
	public TextAsset two;
	public TextAsset three;
	public TextAsset four;
	public TextAsset five;

    public string[] textLines;

    public int currentLine;
    //public int endLine;

    public GameObject player;

    public GameObject dialogue;
    // Use this for initialization
	public int pe;
    GameObject person;
	private float lastButtonpressed = -9999f;
	public float interval = 1f;

    public GameObject t;

    public OVRCameraRig camera;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dialogue = GameObject.FindGameObjectWithTag("dialog"); //canvas
		//speak(2);
       
        //if (endLine == 0)
        //{
           //endLine = textLines.Length - 1;
        //}
		currentLine = 0;
        t = GameObject.FindGameObjectWithTag("dialog");
        t.SetActive(false);
        camera = GameObject.FindObjectOfType<OVRCameraRig>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = camera.transform.position - transform.position;
        v.x = v.z = 0.0f;
        t.transform.LookAt(camera.transform.position - v);
        t.transform.Rotate(0, 180, 0);
        if (person != null && OVRInput.Get(OVRInput.Button.Two) && currentLine < textLines.Length && Time.time > lastButtonpressed + interval)
		{
			
			currentLine++;
			speak(pe, person);
			lastButtonpressed = Time.time;
		}

    }
	public void speak(int p, GameObject person)
    {
		if (currentLine >= textLines.Length)
		{
			currentLine = 0;
			dialogue.SetActive(false);
		}
        pe = p;
        this.person = person;
		print ("entered speak");
        t.transform.position = new Vector3(this.person.transform.position.x, this.person.transform.position.y + 10, this.person.transform.position.z);
        if (p == 1) {
            textLines = (one.text.Split ('\n'));
		} else if (p == 2) {
			textLines = (two.text.Split ('\n'));
		} else if (p == 3) {
			textLines = (three.text.Split ('\n'));
		} else if (p == 4) {
			textLines = (four.text.Split ('\n'));
		} else if (p == 5) {
			textLines = (five.text.Split ('\n'));
		}
        //dialogue.SetActive(true);
        theText.text = textLines[currentLine];
        t.SetActive(true);

    }

}
