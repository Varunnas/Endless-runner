using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 30.0f;
    private PlayerController playerControllerScript;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false )
        {
            if(playerControllerScript.doubleSpeed == true)
               transform.Translate(Vector3.left * Time.deltaTime * speed* 2.0f);
            else if(playerControllerScript.doubleSpeed == false)
                transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
        if (transform.position.x < -10 && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
   ;
    }


}
