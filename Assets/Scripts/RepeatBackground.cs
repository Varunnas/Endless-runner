using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startPos;
    private float widthSize;
    void Start()
    {
        startPos= transform.position;
        widthSize=GetComponent<BoxCollider>().size.x /2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - widthSize)
        { 
            transform.position=startPos; 
        }  
    }
}
