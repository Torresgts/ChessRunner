using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{

    private Button TileButton;
    //public static Image TileButtonImage;
    Animator TileAnim;

    BlockHandler blockHandler;

    public static Horse horseGO;

    bool hasPiece = false;

    private void Awake()
    {
        TileConfigs();

        horseGO = FindObjectOfType<Horse>();
    }

    #region OnTrigger Functions

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Horse"))
        {
            TileButton.enabled = true;
            TileAnim.SetBool("PossibleMove", true);
        }

        if (collision.gameObject.CompareTag("Piece"))
        {
            hasPiece = true;
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
        AddPoint();

        if(blockHandler == null) blockHandler = GameObject.FindObjectOfType<BlockHandler>();
        blockHandler.StartMoving();
        //When Start

        OnStartHorseMove();

        Horse.horse.transform.parent = this.gameObject.transform;

        iTween.MoveTo(Horse.horse,
            iTween.Hash(
            "position", new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 45f, this.gameObject.transform.position.z),
            "time", 0.8f,
            "easetype", iTween.EaseType.easeInQuad,
            "islocal", true,
            "oncomplete", "OnFinishedHorseMove",
            "oncompletetarget", gameObject
            ));

       
        iTween.ShakePosition(BlockHandler.BlockHandlerGO,
            iTween.Hash(
                "amount", new Vector3(0.02f, 0.03f, 0.04f),
                "time", 0.08f
                ));

        //When Finishes
        iTween.ShakePosition(BlockHandler.BlockHandlerGO,
            iTween.Hash(
                "amount", new Vector3(0.04f, 0.06f, 0.08f),
                "time", 0.2f,
                "delay", 0.8f
                ));

    }

    private void TileConfigs()
    {
        TileButton = this.gameObject.GetComponentInChildren<Button>();
        TileButton.enabled = false;

        TileButton.onClick.AddListener(() => HorseToThisPosition()); //Add the HorseToThisPosition() to this tile Button (TileButton)

        TileAnim = TileButton.GetComponent<Animator>();

        TileAnim.SetBool("PossibleMove", false);
    }

    private void AddPoint()
    {
        GameplayManager.score++;
    }


    public void OnStartHorseMove()
    {
        TurnAllHorseColliderOff();
        horseGO.isMoving = true;
    }

    public void OnFinishedHorseMove()
    {
        //COLOCAR SOM DO CAVALO TERMINANDO MOVIMENTO AQUI

        TurnAllHorseColliderOn();
        horseGO.isMoving = false;
        horseGO.particle.Play();

        GameObject FloatText = Instantiate(Resources.Load("FloatingText"), new Vector3(0,0,0), Quaternion.identity, UIAux.aux.gameObject.transform.parent) as GameObject;
        if(hasPiece)
        {
            FloatText.gameObject.GetComponent<FloatingText>().fantastic = true;
        }
        else
        {
            FloatText.gameObject.GetComponent<FloatingText>().great = true;
        }
        
    }

    private static void TurnAllHorseColliderOn()
    {

        foreach (Collider2D colHint in horseGO.hintList)
        {
            colHint.enabled = true;
        }

        horseGO.playerCol.enabled = true;
    }

    private static void TurnAllHorseColliderOff()
    {
        foreach (Collider2D colHint in horseGO.hintList)
        {
            colHint.enabled = false;
        }

        horseGO.playerCol.enabled = false;
    }
}
