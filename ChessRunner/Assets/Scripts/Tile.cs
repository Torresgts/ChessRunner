using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{

    private Button TileButton;
    //public static Image TileButtonImage;
    Animator TileAnim;



    private void Awake()
    {
        TileConfigs();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Horse"))
        {
            TileButton.enabled = true;
            TileAnim.SetBool("PossibleMove", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Horse"))
        {
            TileButton.enabled = false;
            TileAnim.SetBool("PossibleMove", false);
        }
    }
    #endregion

    void HorseToThisPosition()
    {
        Horse.horse.transform.position = this.gameObject.transform.position;
    }

    private void TileConfigs()
    {
        TileButton = this.gameObject.GetComponentInChildren<Button>();
        TileButton.enabled = false;

        TileButton.onClick.AddListener(() => HorseToThisPosition()); //Add the HorseToThisPosition() to this tile Button (TileButton)

        TileAnim = TileButton.GetComponent<Animator>();

        TileAnim.SetBool("PossibleMove", false);
    }

    

}
