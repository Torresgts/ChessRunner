using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PawnMoves : MonoBehaviour
{
    
    private void Start()
    {
        //Debug.Log(this.gameObject.transform.parent.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollider"))
        {

            this.gameObject.transform.parent.gameObject.transform.parent = collision.gameObject.transform.parent;

            iTween.MoveTo(this.gameObject.transform.parent.gameObject,
            iTween.Hash(
            "position", new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 45f, this.gameObject.transform.position.z),
            "time", 0.4f,
            "easetype", iTween.EaseType.easeInQuad,
            "islocal", true
            ));

            Horse.horse.gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 0);

            Horse.playerIsDead = true;

            BlockHandler.ShakeBlocks();
        }
    }
}
