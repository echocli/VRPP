using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hand : MonoBehaviour
{
    public enum State
    {
        EMPTY,
        TOUCHING,
        HOLDING
    };

    public OVRInput.Controller Controller = OVRInput.Controller.LTouch;
    public State mHandState = State.EMPTY;
    public Rigidbody AttachPoint = null;
    public bool IgnoreContactPoint = false;
    private Rigidbody mHeldObject;
    private FixedJoint mTempJoint;
    private Vector3 mOldVelocity;
    //mycode
    //public textboxManager tb;
    public GameObject t;
    //
    // Use this for initialization
    void Start()
    {
        if (AttachPoint == null)
        {
            AttachPoint = GetComponent<Rigidbody>();
        }
        //mycode
        t = GameObject.FindGameObjectWithTag("dialog");

    }

    // Update is called once per frame
    void Update()
    {
		
        switch (mHandState)
        {
            case State.TOUCHING:
                if (mTempJoint == null && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, Controller) >= 0.5f)
                {
                    mHeldObject.velocity = Vector3.zero;
                    mTempJoint = mHeldObject.gameObject.AddComponent<FixedJoint>();
                    mTempJoint.connectedBody = AttachPoint;
                    mHandState = State.HOLDING;
                }
                break;
            case State.HOLDING:
                if (mTempJoint != null && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, Controller) < 0.5f)
                {
                    Object.DestroyImmediate(mTempJoint);
                    mTempJoint = null;
                    throwObject();
                    mHandState = State.EMPTY;
                }
                mOldVelocity = OVRInput.GetLocalControllerAngularVelocity(Controller);
                break;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
		print("hi");
		if (mHandState == State.EMPTY)
		{
			GameObject temp = collider.gameObject;
			//mycode
			//print(temp.ToString());

			if (temp == GameObject.FindGameObjectsWithTag("prisscap")[0] || temp == GameObject.FindGameObjectsWithTag("prisscap")[1])
			{
				
				//txtsc = textboxManager;
				textboxManager tb = (textboxManager) t.GetComponent(typeof(textboxManager));
				tb.speak (3, temp);
				print ("cube");
				//
			}

			if (temp == GameObject.FindGameObjectsWithTag("woryguy")[0] || temp == GameObject.FindGameObjectsWithTag("woryguy")[1])
			{
				
				//txtsc = textboxManager;
				textboxManager tb = (textboxManager) t.GetComponent(typeof(textboxManager));
				tb.speak (1, temp);

				//
			}
			if (temp == GameObject.FindGameObjectsWithTag("freeGuy")[0]||temp == GameObject.FindGameObjectsWithTag("freeGuy")[1]||temp == GameObject.FindGameObjectsWithTag("freeGuy")[2]||temp == GameObject.FindGameObjectsWithTag("freeGuy")[3])
			{
				//txtsc = textboxManager;
				textboxManager tb = (textboxManager) t.GetComponent(typeof(textboxManager));
				tb.speak (2, temp);
			
				//
			}
			if (temp == GameObject.FindGameObjectsWithTag("laidback")[0] || temp == GameObject.FindGameObjectsWithTag("laidback")[1])
			{
				
				//txtsc = textboxManager;
				textboxManager tb = (textboxManager) t.GetComponent(typeof(textboxManager));
				tb.speak (4, temp);

				//
			}
			GameObject[] idlec = GameObject.FindGameObjectsWithTag("idleC");
			foreach (GameObject i in idlec){
				if (temp == i)
				{
					
					//txtsc = textboxManager;
					textboxManager tb = (textboxManager) t.GetComponent(typeof(textboxManager));
					tb.speak (5, temp);

					//
				}
				break;
			}


			if (temp == GameObject.FindGameObjectWithTag("keypad"))
			{
				Initiate.Fade("Demo", Color.black, 2.0f);
			}
			GameObject[] pc = GameObject.FindGameObjectsWithTag("PC");
			foreach (GameObject i in pc){
				if (temp == i)
				{
					Initiate.Fade("pc", Color.black, 2.0f);
				}
				break;
			}
			if (temp == GameObject.FindGameObjectWithTag("quiz"))
			{
				//print("quix");
				Initiate.Fade("quiz", Color.black, 2.0f);
			}
			if (temp != null && temp.layer == LayerMask.NameToLayer("grabbable") && temp.GetComponent<Rigidbody>() != null)
			{
				mHeldObject = temp.GetComponent<Rigidbody>();

				mHandState = State.TOUCHING;
			}
		}



   
    }

    void OnTriggerExit(Collider collider)
    {
        if (mHandState != State.HOLDING)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer("grabbable"))
            {
                mHeldObject = null;
                mHandState = State.EMPTY;
            }
        }
    }

    private void throwObject()
    {
        mHeldObject.velocity = OVRInput.GetLocalControllerVelocity(Controller);
        if (mOldVelocity != null)
        {
            mHeldObject.angularVelocity = OVRInput.GetLocalControllerAngularVelocity(Controller);
        }
        mHeldObject.maxAngularVelocity = mHeldObject.angularVelocity.magnitude;
    }
		

}
