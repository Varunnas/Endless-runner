using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] obstacles;
    public int obstaclelement;
    private PlayerController playerControllerScript;
    void Start()
    {
        playerControllerScript =  GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", 2.0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if(playerControllerScript.gameOver ==  false) 
        {
            obstaclelement = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[obstaclelement], new Vector3(30, 0, 0), obstacles[obstaclelement].transform.rotation);
        }
        
    }
}
