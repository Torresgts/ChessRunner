using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{

    Button TileButton;
    Animator TileAnim;

    private void Awake()
    {
        TileButton = this.gameObject.GetComponentInChildren<Button>();
        TileButton.enabled = false;

        TileButton.onClick.AddListener(() => HorseToThisPosition());

        TileAnim = TileButton.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region OnTrigger Functions

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Horse"))
        {
            TileButton.enabled = true;
            TileAnim.SetBool("PossibleMove", true);
            //TileAnim.Play("PossibleMove", -1,0f );
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Horse"))
        {
            TileButton.enabled = false;
            TileAnim.SetBool("PossibleMove", false);
            //TileAnim.StopPlayback();
        }
    }
    #endregion

    void HorseToThisPosition()
    {
        Horse.horse.transform.position = this.gameObject.transform.position;
    }
}
