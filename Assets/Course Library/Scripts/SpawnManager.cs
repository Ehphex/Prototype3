using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private float startDelay = 2;
    private float repeatRate = 2;

    private PlayerController PlayerControllerScript;

    public GameObject obstaclePrefab;
    private Vector3 spawnPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {

        if (!PlayerControllerScript.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
