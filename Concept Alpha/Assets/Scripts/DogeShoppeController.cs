using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DogeShoppeController : MonoBehaviour {
    bool canPurchase = true;
    private EventSystem eventSystem;
    private GraphicRaycaster graphicRay;
    private PointerEventData pointEventData;
    // Use this for initialization
    void Start () {
        Globals.playerCash = 50.00f;
        graphicRay = GetComponent<GraphicRaycaster>();
        eventSystem = FindObjectOfType<EventSystem>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0)
        {
            pointEventData = new PointerEventData(eventSystem) { position = Input.GetTouch(0).position };
            List<RaycastResult> results = new List<RaycastResult>();
            graphicRay.Raycast(pointEventData, results);
            foreach(RaycastResult result in results)
            {
                Debug.Log("Hit: " + result.gameObject.name);
                
                if(result.gameObject.name == "BuyTreats" && canPurchase) { PurchaseTreat(); }
                else if(result.gameObject.name == "BuyBalls" && canPurchase) { PurchaseBall(); }
            }
        }
	}

    void PurchaseBall()
    {
        Debug.Log("Bought a ball");
        if(Globals.playerCash < 1.50f || !canPurchase)
        {
            return;
        }
        canPurchase = false;
        Globals.playerBalls++;
        Globals.playerCash -= 1.50f;
        StartCoroutine(BuyWait());
    }

    void PurchaseTreat()
    {
        Debug.Log("Bought a treat");
        if(Globals.playerCash < 3.00f || !canPurchase)
        {
            return;
        }
        canPurchase = false;
        Globals.playerTreats++;
        Globals.playerCash -= 3.00f;
        StartCoroutine(BuyWait());
    }

    private IEnumerator BuyWait()
    {
        yield return new WaitForSeconds(1);
        canPurchase = true;
    }
}
