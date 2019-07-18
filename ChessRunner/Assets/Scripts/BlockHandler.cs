﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    Vector3 direction = new Vector3(0, -1, 0);

    public static int numberOfBlocks = 1; //A int to keep knwlege of how many blocks were instancied in the scene

    public float vel = 2f;

    bool blockCanMove = false;
    float waitToMove = 3f;

    private void Start()
    {
        StartCoroutine(MoveConfig());
    }

    // Update is called once per frame
    void Update()
    {
        
        //MoveBlocks(); 
    }

    private void MoveBlocks()
    {
        //transform.position += direction * vel * Time.deltaTime;

        //if (blockCanMove)
        //{
        //    transform.position += direction * vel * Time.deltaTime;
        //}



    }

    IEnumerator MoveConfig()
    {
        yield return new WaitForSeconds(waitToMove);
        iTween.MoveAdd(this.gameObject, new Vector3(0, -5, 0), 2f);
        //yield return new WaitForSeconds(waitToMove);

        StartCoroutine(MoveConfig());



    }
}
