using System;
using UnityEngine;

public class SelfCleanup : MonoBehaviour {
    public float destroyDelay = 15.0f;
    private Action<GameObject> deathAction;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, destroyDelay);
        deathAction = FindObjectOfType<DogeManager>().RemoveDoge;
	}

    private void OnDestroy()
    {
        deathAction(gameObject);
    }
}
