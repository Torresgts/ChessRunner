using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField]
    private GameObject _greatGO;
    public bool great;

    [SerializeField]
    private GameObject _fantasticGO;
    public bool fantastic;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoDestroy());

        if(great)
        {
            _greatGO.gameObject.SetActive(true);
        }
        else if (fantastic)
        {
            _fantasticGO.gameObject.SetActive(true);
        }
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
