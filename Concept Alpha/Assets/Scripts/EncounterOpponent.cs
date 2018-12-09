using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EncounterOpponent : MonoBehaviour {
    public float aggressionRating = 100f;
    public float passifyPoint;
    private float resistance;

    private int passifyAttemps = 3;
    private float passifyRating;

    public Text actionText;

	// Use this for initialization
	void Start () {
        resistance = Random.Range(-1.0f, 3.5f);
        passifyPoint = Random.Range(15.0f, 35.0f);
        passifyRating = Random.Range(15.0f, 65.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Pacify(int amount, string type)
    {
        if(aggressionRating < passifyPoint)
        {
            actionText.text = "Time to use a treat!";
            aggressionRating -= amount - (amount * (resistance / 100));
            if (type == "treat")
            {
                float passifyAttempt = Random.Range(10, 70);
                if(passifyAttempt > passifyRating)
                {
                    actionText.text = "You've earned the dog's loyalty!";
                    Globals.playerDogs++;
                    Globals.playerCash += Random.Range(3, 5);
                    Globals.playerBalls += passifyAttemps;
                    StartCoroutine(LeaveWait());
                }
                else
                {
                    passifyAttemps--;
                    if(passifyAttemps <= 0)
                    {
                        actionText.text = "The dog ran off!";
                        Globals.storeOffset += Random.Range(0.05f, 0.07f);
                        StartCoroutine(LeaveWait());
                    }
                }
            }
        }
        else
        {
            aggressionRating -= amount - (amount * (resistance / 100));
        }

        if(aggressionRating <= 0)
        {
            actionText.text = "You made the dog happy and it walked off!";
            StartCoroutine(LeaveWait());
        }

        Debug.Log(amount + ", " + type + ": " + aggressionRating);
    }

    private IEnumerator LeaveWait()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(0);
    }
}
