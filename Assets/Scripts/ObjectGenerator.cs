using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabPool;
    [SerializeField] private int amount = 1;
    [SerializeField] private float spawnRange = 2f;
    [SerializeField] private float bounceForce = 0.3f;
    [SerializeField] private bool spawnOnStart = true;
    [SerializeField] private bool applyBounce = false;
    void Start()
    {
        if (spawnOnStart)
        {
            SpawnPrefab();
        }
    }
    public void SpawnPrefab()
    {
        for (int i = 0; i < amount; i++)
        {
            Spawning();
        }
    }
    private void Spawning()
    {
        GameObject spawnedObject;

        Vector3 randomOffset = Random.insideUnitCircle * spawnRange;
        Vector3 spawnPosition = transform.position + randomOffset;

        if (prefabPool.Length > 0)
        {
            GameObject prefabToSpawn = prefabPool[Random.Range(0, prefabPool.Length)];
            spawnedObject = ObjectPool.instance.GetObject(prefabToSpawn, spawnPosition, Quaternion.identity);

            Rigidbody2D spawnedRigidbody = spawnedObject.GetComponent<Rigidbody2D>();
            if (spawnedRigidbody != null && applyBounce)
            {
                Vector2 bounceDirection = spawnedObject.transform.position - transform.position;
                spawnedRigidbody.AddRelativeForce(bounceDirection.normalized * bounceForce, ForceMode2D.Impulse);
            }
        }
    }
}
