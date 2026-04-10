using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fallingObjPf;
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
            GameObject randomPrefab = fallingObjPf[Random.Range(0, fallingObjPf.Length)];
            Instantiate(randomPrefab, GetSpawnPos(), Quaternion.Euler(new Vector3(0.0f, 0.0f, 180.0f)));
            yield return new WaitForSeconds(Random.Range(spawnTimeRange.x, spawnTimeRange.y));
        }
    }

    private Vector3 GetSpawnPos()
    {
        return new Vector3(Random.Range(xSpawnRange.x, xSpawnRange.y), ySpawn, 0.0f);
    }
}
