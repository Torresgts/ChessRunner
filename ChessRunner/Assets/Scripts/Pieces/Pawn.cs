using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pawn : MonoBehaviour
{
    public GameObject CanvasPanel;

    RectTransform rt;

   // public Collider2D[] col;

    // Start is called before the first frame update
    void Start()
    {
        rt = this.gameObject.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(250, 250);

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //It's a solution to the pieces positions get local.
    //    //This is not the better solution.. but works.
    //    if (collision.gameObject.CompareTag("Tile"))
    //    {
    //        this.gameObject.transform.parent = collision.gameObject.transform;
    //    }

    //    if (collision.gameObject.CompareTag("PlayerCollider"))
    //    {
    //        iTween.MoveTo(this.gameObject, new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z), 1f);

    //        Horse.horse.gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
            
    //        Horse.playerIsDead = true;

    //        BlockHandler.ShakeBlocks();
    //    }
    //}

}
