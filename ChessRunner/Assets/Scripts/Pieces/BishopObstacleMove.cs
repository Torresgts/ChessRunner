using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopObstacleMove : MonoBehaviour
{
    public bool hasPiece = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Piece") && !hasPiece)
        {
            hasPiece = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Piece"))
        {
            hasPiece = false;
        }
    }
}
