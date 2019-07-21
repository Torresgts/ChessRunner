using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    Vector3 direction = new Vector3(0, -1, 0);

    public static int numberOfBlocks = 1;
    
    [HideInInspector] public int typeColor;
    public ColorTypeListScriptableObject colorTypeList;

    public float vel = 2f;

    bool blockCanMove = false;
    float waitToMove = 5f;

    bool gameCanMove = false;
    bool playerDied = false;

    private void Start()
    {
        //StartCoroutine(MoveConfig());
    }
    
    void Update()
    {
       // StartCoroutine(MoveConfig());
        //MoveBlocks(); 
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
        iTween.MoveAdd(this.gameObject, new Vector3(0, -4, 0), 2);
        yield return new WaitForSeconds(waitToMove);
        
        if(!playerDied) StartCoroutine(MoveConfig());
    }
}
