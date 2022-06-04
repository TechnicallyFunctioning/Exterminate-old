using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeS : MonoBehaviour
{
    void Start()
    {
        Vector3 scale = new Vector3(Random.Range(1f, 2f), Random.Range(1f, 2f), Random.Range(1f, 2f));
        transform.localScale = scale;

        transform.Rotate(Vector3.up * Random.Range(0,360));
    }
}
