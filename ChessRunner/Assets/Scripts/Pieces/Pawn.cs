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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // col[0].IsTouching(collision.gameObject.);


        if(collision.gameObject.CompareTag("PlayerCollider"))
        {
            //this.gameObject.transform.position = collision.gameObject.transform.position;
            iTween.MoveTo(this.gameObject, new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z), 1f);

            this.gameObject.transform.parent = collision.gameObject.transform;

            Horse.horse.gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
            
            Horse.playerIsDead = true;

            BlockHandler.ShakeBlocks();
        }
    }

}
