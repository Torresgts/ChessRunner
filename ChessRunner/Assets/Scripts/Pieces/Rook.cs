using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rook : MonoBehaviour
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
            iTween.MoveTo(this.gameObject, new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z), 1f);

            this.gameObject.transform.parent = collision.gameObject.transform;

            Horse.horse.gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 0);

            Horse.playerIsDead = true;

            BlockHandler.ShakeBlocks();
        }
    }
}
