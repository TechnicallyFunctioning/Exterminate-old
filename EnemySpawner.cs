using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 2);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
