using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    Vector3 direction = new Vector3(0, -1, 0);

    public static int numberOfBlocks = 1;
    
    public int typeColor;
    public ColorTypeListScriptableObject colorTypeList;

    public float vel = 208f;

    bool blockCanMove = false;
    float waitToMove = 3f;

    // Update is called once per frame
    void Update()
    {
       // StartCoroutine(MoveConfig());
        MoveBlocks(); 
    }

    private void MoveBlocks()
    {
        transform.position += direction * vel * Time.deltaTime;

        //if (blockCanMove)
        //{
        //    transform.position += direction * vel * Time.deltaTime;
        //}
        
    }

    //IEnumerator MoveConfig()
    //{
    //    yield return new WaitForSeconds(waitToMove);
    //    blockCanMove = true;
    //    yield return new WaitForSeconds(waitToMove);
    //    blockCanMove = false;
    //    StartCoroutine(MoveConfig());
    //}
}
