using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(GraphicRaycaster))]
public class EncounterController : MonoBehaviour {
    private EventSystem eventSystem;
    private GraphicRaycaster graphicRay;
    private PointerEventData pointEventData;

    public Sprite[] opponentSprites = new Sprite[2];
    public Sprite[] pacifiedSprites = new Sprite[2];

    public Image character, opponent;
    public Text ballText, treatText, actionText;

    public bool isTurn = true;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        ballText.text = Globals.playerBalls.ToString();
        treatText.text = Globals.playerTreats.ToString();
        opponent.sprite = opponentSprites[Random.Range(0, 1)];
        graphicRay = GetComponent<GraphicRaycaster>();
        eventSystem = FindObjectOfType<EventSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void FixedUpdate()
    {
        if(Globals.playerBalls <= 0 && Globals.playerTreats <= 0)
        {
            actionText.text = "You need to stock up next time!";
            StartCoroutine(LeaveWait());
            Globals.storeOffset += Random.Range(0.01f, 0.05f);
            return;
        }

        if (Input.touchCount > 0 && isTurn)
        {
            Debug.Log("Touching");
            isTurn = false;
            pointEventData = new PointerEventData(eventSystem) { position = Input.GetTouch(0).position };
            List<RaycastResult> results = new List<RaycastResult>();
            graphicRay.Raycast(pointEventData, results);

            foreach (RaycastResult result in results)
            {
                Debug.Log("Hit: " + result.gameObject.name);
                if (result.gameObject.name == "Balls" && Globals.playerBalls > 0) { ThrowBall(); break; }
                else if (result.gameObject.name == "Treats" && Globals.playerTreats > 0) { ThrowTreat(); break; }
            }
        }
    }

    private void ThrowTreat()
    {
        Debug.Log("throwing treat");
        FindObjectOfType<EncounterOpponent>().Pacify(Random.Range(17, 31), "treat");
        Globals.playerTreats--;
        treatText.text = Globals.playerTreats.ToString();
        StartCoroutine(TriggerWait());
    }

    private void ThrowBall()
    {
        Debug.Log("throwing ball");
        FindObjectOfType<EncounterOpponent>().Pacify(Random.Range(14, 21), "ball");
        Globals.playerBalls--;
        ballText.text = Globals.playerBalls.ToString();
        StartCoroutine(TriggerWait());
    }

    private IEnumerator LeaveWait()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(0);
    }

    private IEnumerator TriggerWait()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Done waiting");
        isTurn = true;
    }

    private void OnLevelWasLoaded(int level)
    {
        ballText.text = Globals.playerBalls.ToString();
        treatText.text = Globals.playerTreats.ToString();
    }
}
