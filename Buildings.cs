using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int maxDistance;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(transform.position.x > maxDistance) { Destroy(gameObject); }
    }
}
