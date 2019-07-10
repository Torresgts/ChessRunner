using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    Vector3 direction = new Vector3(0, -1, 0);
    float vel = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * vel * Time.deltaTime;
    }
}
