﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollider"))
        {
            this.gameObject.transform.position = collision.gameObject.transform.position;
            //Destroy(collision.gameObject);
            Horse.playerIsDead = true;

        }
    }
}