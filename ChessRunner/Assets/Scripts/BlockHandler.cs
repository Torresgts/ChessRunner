using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour
{

    public static GameObject BlockHandlerGO;
    Vector3 direction = new Vector3(0, -1, 0);

    public static int numberOfBlocks = 1;
    
    [HideInInspector] public int typeColor;
    public ColorTypeListScriptableObject colorTypeList;

    public float vel = 2f;

    bool blockCanMove = false;
    float waitToMove = 2f;

    bool gameCanMove = false;
    bool playerDied = false;

    private void Awake()
    {
        BlockHandlerGO = this.gameObject;
    }

    private void Start()
    {
        //StartCoroutine(MoveConfig());
    }
    
    void Update()
    {
        // StartCoroutine(MoveConfig());
        //MoveBlocks(); 

        if(Input.GetMouseButton(0))
        {
            //StartCoroutine(MoveConfig());
           // Debug.Log("Player Died?: " + playerDied);
        }
    }

    private void MoveBlocks()
    {
        transform.position += direction * vel * Time.deltaTime;
        
    }

    public void StartMoving()
    {
        if(!gameCanMove){
            StartCoroutine(MoveConfig());
            gameCanMove = true;
        }
    }

    public void StopMoving()
    {
        playerDied = true;
    }

    IEnumerator MoveConfig()
    {
        yield return new WaitForSeconds(waitToMove);
        //iTween.MoveAdd(this.gameObject, new Vector3(0, -4, 0), 2);

        if (!Horse.playerIsDead)
        {
            iTween.MoveAdd(this.gameObject,
                        iTween.Hash(
                        "amount", new Vector3(0, +4, 0),
                        "time", 2f,
                        "easetype", iTween.EaseType.easeInOutQuad
                        ));

        }
        else
        {
            // Do nothing
        }

        yield return new WaitForSeconds(waitToMove);
        
        //if(!playerDied)
            StartCoroutine(MoveConfig());
    }

    public static void ShakeBlocks()
    {
        iTween.ShakePosition(BlockHandler.BlockHandlerGO, new Vector3(0.1f, 0.2f, 0.3f), 0.3f);
    }
}
