using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogeManager : MonoBehaviour {
    public GameObject player;
    public GameObject[] doges = new GameObject[2];

    public float range = 10.0f;
    public int dogeCount = 0;
    public int maxDoges = 10;

    private List<GameObject> spawnedDoges = new List<GameObject>();
    private bool dogeLocked = false;

	// Use this for initialization
	void Start () {
        StartCoroutine(DogeSpawnWait());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        if(dogeCount < maxDoges && dogeLocked)
        {
            dogeLocked = false;
        }
    }

    private void FixedUpdate()
    {
        foreach(GameObject doge in spawnedDoges)
        {
            if (Vector3.Distance(doge.transform.position, player.transform.position) < 10)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    private void InstantiateDoge()
    {
        dogeCount++;
        GameObject dogeChoice = doges[Random.Range(0, 1)];
        Vector3 dogeSpawn = new Vector3(player.transform.position.x + Random.Range(-50, 50), player.transform.position.y, player.transform.position.z + Random.Range(-50, 50));
        GameObject newDoge = Instantiate(dogeChoice, dogeSpawn, Quaternion.Euler(0, Random.Range(-90, 90), 0), transform);
        spawnedDoges.Add(newDoge);
    }

    private IEnumerator DogeSpawnWait()
    {
        yield return new WaitForSeconds(Random.Range(5.0f, 17.5f));
        InstantiateDoge();
        if(dogeCount < maxDoges)
        {
            StartCoroutine(DogeSpawnWait());
        }
        else
        {
            dogeLocked = true;
        }
    }

    public void RemoveDoge(GameObject doge)
    {
        dogeCount--;
        spawnedDoges.Remove(doge);
    }
}
