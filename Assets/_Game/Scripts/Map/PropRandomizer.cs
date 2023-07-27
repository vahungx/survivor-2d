using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    public List<GameObject> propSpawnPoints;
    public List<GameObject> propPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        SpawnProps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnProps()
    {
        foreach(GameObject spawnPoint in propSpawnPoints)
        {
            int random = Random.Range(0, propPrefabs.Count);
            Instantiate(propPrefabs[random], spawnPoint.transform.position,Quaternion.identity, spawnPoint.transform);
        }
    }
}
