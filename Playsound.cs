using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Playsound : MonoBehaviour 

{
    
    public static int count = 0;
    private string password;
    public static string guess = "";
    // Use this for initialization

    AudioSource correctAudio;
    AudioSource errorAudio;

	public Button[] arr;

    void Start()
    {
        password = "12345";
        count = 0;
		arr = GameObject.FindObjectsOfType<Button> ();
    }

    // Update is called once per frame
    void Update()
    {
		if ((OVRInput.Get (OVRInput.Axis1D.PrimaryIndexTrigger)) > 0.0f) {
			exitQuiz ();
		}
    }
	public void OnPointer()
	{
		Debug.Log("Pointer over!");
	}
	public void Clicky(GameObject gameObj)
    {
        count += 1;
        if (gameObj == GameObject.FindGameObjectWithTag("1"))
        {
            
            GetComponent<AudioSource>().Play();
            guess += 1;
        }
        else if (gameObject == GameObject.FindGameObjectWithTag("2"))
        {
            GetComponent<AudioSource>().Play();
            guess += 2;
        }
        else if (gameObject == GameObject.FindGameObjectWithTag("3"))
        {
            GetComponent<AudioSource>().Play();
            guess += 3;
        }
        else if (gameObject == GameObject.FindGameObjectWithTag("4"))
        {
            GetComponent<AudioSource>().Play();
            guess += 4;
        }
        else if (gameObject == GameObject.FindGameObjectWithTag("5"))
        {
            GetComponent<AudioSource>().Play();
            guess += 5;
        }
        else if (gameObject == GameObject.FindGameObjectWithTag("6"))
        {
            GetComponent<AudioSource>().Play();
            guess += 6;
        }
        else if (gameObject == GameObject.FindGameObjectWithTag("7"))
        {
            GetComponent<AudioSource>().Play();
            guess += 7;
        }
        else if (gameObject == GameObject.FindGameObjectWithTag("8"))
        {
            GetComponent<AudioSource>().Play();
            guess += 8;
        }
        else if (gameObject == GameObject.FindGameObjectWithTag("9"))
        {
            GetComponent<AudioSource>().Play();
            guess += 9;
        }
        else if (gameObject == GameObject.FindGameObjectWithTag("0"))
        {
            GetComponent<AudioSource>().Play();
            guess += 0;
        }
        if (gameObject == GameObject.FindGameObjectWithTag("sumit"))
        {
            AudioSource[] audios = GetComponents<AudioSource>();
            errorAudio = audios[1];
            correctAudio = audios[0];
            if(count != 6)
            {
                print("count!=5");
                errorAudio.Play(); //wrong
                count = 0;
                guess = "";
            }
            else if (count == 6 && guess != password)
            {
                print("wrongpass");
                errorAudio.Play(); //wrong
                count = 0;
                guess = "";
            }
            else if (count == 6 && guess == password)
            {
                correctAudio.Play(); //win
                Initiate.Fade("Classroom", Color.black, 2.0f);
            }
            
        }
        else if (gameObject == GameObject.FindGameObjectWithTag("clear"))
        {
            Initiate.Fade("Classroom", Color.black, 2.0f);
        }

    }

    public void wrong()
    {

    }
	public void exitQuiz()
	{
		Initiate.Fade("Classroom", Color.black, 2.0f);
	}

}
