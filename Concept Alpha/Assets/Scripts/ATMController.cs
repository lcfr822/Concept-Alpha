using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMController : MonoBehaviour {
    bool isUsed = false;
    Color origColor;

	// Use this for initialization
	void Start () {
        origColor = GetComponent<Renderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ApplyPowerUp()
    {
        Globals.playerBalls++;
        StartCoroutine(DisableATM());
    }

    private IEnumerator DisableATM()
    {
        GetComponent<Renderer>().material.color = Color.grey;
        isUsed = true;
        yield return new WaitForSeconds(30);
        isUsed = false;
        GetComponent<Renderer>().material.color = origColor;
    }
}
