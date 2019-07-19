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
    float waitToMove = 2f;

    private void Start()
    {
        StartCoroutine(MoveConfig());
    }

    // Update is called once per frame
    void Update()
    {
       // StartCoroutine(MoveConfig());
        //MoveBlocks(); 
    }

    private void MoveBlocks()
    {
        transform.position += direction * vel * Time.deltaTime;
        
    }

    IEnumerator MoveConfig()
    {
        yield return new WaitForSeconds(waitToMove);
        iTween.MoveAdd(this.gameObject, new Vector3(0, -4, 0), 2);
        yield return new WaitForSeconds(waitToMove);
        
        StartCoroutine(MoveConfig());
    }
}
