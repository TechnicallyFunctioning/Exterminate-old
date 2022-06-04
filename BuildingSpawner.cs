using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] smallApts;
    [SerializeField] private GameObject[] stores;
    [SerializeField] private int minSwitchTime;
    [SerializeField] private int maxSwitchTime;
    private GameObject[] currentArray;
    private GameObject spawnedBuilding;
    private BoxCollider buildingCollider;
    private bool waitingToSwitch;

    private void Start()
    {
        if(currentArray == null)
        {
            currentArray = smallApts;
        }
    }

    private void Update()
    {
        if (spawnedBuilding == null) { SpawnBuilding(); }
        else if ((spawnedBuilding.transform.position.x - transform.position.x) > (buildingCollider.size.x * transform.localScale.x)) { SpawnBuilding(); }
    }

    private void SpawnBuilding()
    {
        spawnedBuilding = Instantiate(currentArray[Random.Range(0, currentArray.Length)], transform.position, transform.rotation);
        buildingCollider = spawnedBuilding.GetComponent<BoxCollider>();
        spawnedBuilding.transform.SetParent(gameObject.transform);
        StartCoroutine(ArraySwitch());
    }

    private IEnumerator ArraySwitch()
    {
        if(waitingToSwitch == false)
        {
            int arrayRoll = Random.Range(0, 10);
            if (arrayRoll < 5) { currentArray = smallApts; }
            else if (arrayRoll > 4) { currentArray = stores; }
            waitingToSwitch = true;
            yield return new WaitForSeconds(Random.Range(minSwitchTime, maxSwitchTime));
            waitingToSwitch = false;
        }
    }
}
