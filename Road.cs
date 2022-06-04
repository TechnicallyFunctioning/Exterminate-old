using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private float speed;
    private BoxCollider boxCollider;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(transform.position.x > (boxCollider.size.x * transform.localScale.x) / 2)
        {
            transform.position = startPos;
        }
    }
}
