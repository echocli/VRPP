using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class input : MonoBehaviour {
    public GameObject userin;
    public InputField inin;
    public GameObject but;
    GameObject canvas;
    Image win;
    public Sprite key;
    public GameObject wrongmsg;

    // Use this for initialization
    void Start () {

        canvas = GameObject.FindGameObjectWithTag("login");
        win = canvas.GetComponent<Image>();
        userin = GameObject.FindGameObjectWithTag("logininput");
        but = GameObject.FindGameObjectWithTag("loginbutton");
        inin = GameObject.FindObjectOfType<InputField>();

        //wrongmsg = GameObject.FindGameObjectWithTag("crywrong");
        wrongmsg.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if ((OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger)) > 0.0f)
        {
            exitQuiz();
        }
        if ((Event.current.type == EventType.KeyUp) && (Event.current.keyCode == KeyCode.Return))
        {
            submit();
        }
    }

    public void submit()
    {
        string s = inin.text.ToString();
        if (s == "gilb025")
        {
            win.sprite = key;
            userin.SetActive(false);
            but.SetActive(false);
            wrongmsg.SetActive(false);
        }
        else
        {
            wrongmsg.SetActive(true);
        }
    }

    public void exitQuiz()
    {
        Initiate.Fade("Classroom", Color.black, 2.0f);
    }

}
