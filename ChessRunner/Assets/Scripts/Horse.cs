﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    public static GameObject horse;

    public static bool playerIsDead = false;

    public bool isMoving = false;

    public Collider2D playerCol;
    //public Collider2D playerColAux;

    public Collider2D[] moveHints;

    public ParticleSystem particle;

    public List<Collider2D> hintList = new List<Collider2D>();

    private void Awake()
    {
        horse = this.gameObject;

        GetAllMoveHintColliders();
    }

    private void GetAllMoveHintColliders()
    {
        foreach (Collider2D col in moveHints)
        {
            hintList.Add(col);
        }

        //playerCol = playerColAux;
    }

    void Update()
    {
        DestroyHorseOnLimit();
    }

    private void DestroyHorseOnLimit() //If this block get to a Y (vertex) limit, it's destroyed. 
    {
        float limit = -5.8f;

        if (this.gameObject.transform.position.y <= limit)
        {
            //Score save here
            Score.GetBestScore();
            playerIsDead = true;
           // Destroy(this.gameObject);
            Handheld.Vibrate();
            //this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 1);
        }
    }

    public void ShakeBlocks()
    {
        iTween.ShakePosition(BlockHandler.BlockHandlerGO, new Vector3(0.1f, 0.2f, 0.3f), 0.1f);
        Debug.Log("Shake");
    }
}
