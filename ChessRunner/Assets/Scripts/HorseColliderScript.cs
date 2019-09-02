using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseColliderScript : MonoBehaviour
{
    [SerializeField]
    private Horse horseGO;

    private void Awake()
    {
        horseGO = FindObjectOfType<Horse>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Piece") && !horseGO.isMoving)
        {
            Destroy(collision.gameObject);
            GameplayManager.score = GameplayManager.score + 3;
        }
    }
}
