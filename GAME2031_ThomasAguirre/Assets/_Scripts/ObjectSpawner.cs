using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fallingObjPf;
    [SerializeField] private Vector2 xSpawnRange;
    [SerializeField] private float ySpawn;
    [SerializeField] private Vector2 spawnTimeRange;

    void Start()
    {
        StartCoroutine(SpawnFallingObject());
    }

    private IEnumerator SpawnFallingObject()
    {
        while(true)
        {
            Instantiate(fallingObjPf, GetSpawnPos(), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(spawnTimeRange.x, spawnTimeRange.y));
        }
    }

    private Vector3 GetSpawnPos()
    {
        return new Vector3(Random.Range(xSpawnRange.x, xSpawnRange.y), ySpawn, 0.0f);
    }
}
