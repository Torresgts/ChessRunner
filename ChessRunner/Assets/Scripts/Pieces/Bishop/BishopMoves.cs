using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BishopMoves : MonoBehaviour
{
    public int childNumber;

    private Bishop bishop;

    private void Awake()
    {
        bishop = this.gameObject.transform.parent.gameObject.GetComponent<Bishop>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerCollider") && bishop.time == 0 && !Horse.playerIsDead)
        {

            if (childNumber == 1 || childNumber == 3)
            {
                if (this.gameObject.transform.parent.gameObject.GetComponent<Bishop>().possibleMoveGO[childNumber - 1].gameObject.GetComponent<BishopObstacleMove>().hasPiece == false)
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
                    Handheld.Vibrate();
                    Score.GetBestScore();
                }
            }
            else if (childNumber != 1 && childNumber != 3)
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
                Handheld.Vibrate();
                Score.GetBestScore();
            }
        }
    }
}
