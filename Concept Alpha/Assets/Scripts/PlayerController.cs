using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour {
    private JSONDataRetriever dataReceiver = new JSONDataRetriever();
    public Text ballTxt, treatTxt, pill1Txt, pill2Txt, pill3Txt, food1Txt, food2Txt, food3Txt;

    public bool isMoving = false;

    // Use this for initialization
    void Start () {
        Globals.playerBalls = 5;
        Globals.playerTreats = 2;
        Globals.playerPills["Red"] = 1;
        Globals.playerPills["Green"] = 1;
        Globals.playerPills["Blue"] = 1;
        Globals.playerFoods["Cake"] = 1;
        Globals.playerFoods["Drink"] = 1;
        Globals.playerFoods["Pizza"] = 1;
        ballTxt.text = Globals.playerBalls.ToString();
        treatTxt.text = Globals.playerTreats.ToString();
        dataReceiver.ReadData();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 lookDirection = Camera.main.transform.position - transform.position;
        transform.rotation = new Quaternion(transform.rotation.x, lookDirection.y, transform.rotation.z, transform.rotation.w);
        RaycastHit touchHit = new RaycastHit();
        if(Input.touchCount > 0)
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out touchHit))
            {
                Debug.Log(touchHit.collider.name);
            }
        }

        /*if (isMoving && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Warrior_Walk"))
        {
            Debug.Log("Starting");
            GetComponent<Animator>().Play("Warrior_Walk");
        }
        else if (!isMoving && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Warrior_Idle")) 
        {
            Debug.Log("Stopping");
            GetComponent<Animator>().Play("Warrior_Idle");
        }*/
    }
}
