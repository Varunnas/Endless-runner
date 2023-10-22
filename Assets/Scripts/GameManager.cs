using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerController pc;
    private int score;
    public Transform startingPoint;
    void Start()
    {
        pc=GameObject.Find("Player").GetComponent<PlayerController>();
        pc.gameOver = true;
        StartCoroutine(PlayIntro());
    }

    // Update is called once per frame
    void Update()
    {
        if(pc.gameOver == false)
        {
            if (!pc.doubleSpeed)
                score += 1;
            else if (pc.doubleSpeed)
                score += 2;
            Debug.Log("Score is : " +  score);
        }
    }

    IEnumerator PlayIntro()
    {
        Vector3 startPos = pc.transform.position;
        Vector3 endPos = startingPoint.position;
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;
        float distanceCovered = (Time.time - startTime) * 5;
        float fractionOfJourney = distanceCovered / journeyLength;
        pc.GetComponent<Animator>().SetFloat("Speed_Multiplier",0.5f);
        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * 5;
            fractionOfJourney = distanceCovered / journeyLength;
            pc.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            yield return null;
        }
        pc.GetComponent<Animator>().SetFloat("Speed_Multiplier",1.0f);
        pc.gameOver = false;
    }

}

