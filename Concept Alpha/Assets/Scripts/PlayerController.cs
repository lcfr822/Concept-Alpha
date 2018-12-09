using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour {
    public bool isMoving = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 lookDirection = Camera.main.transform.position - transform.position;
        transform.rotation = new Quaternion(transform.rotation.x, lookDirection.y, transform.rotation.z, transform.rotation.w);

        if (isMoving && !GetComponent<Animation>().isPlaying)
        {
            GetComponent<Animator>().Play(0);
        }
        else
        {
            GetComponent<Animator>().StopPlayback();
        }
	}
}
