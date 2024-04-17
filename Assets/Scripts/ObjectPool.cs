using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private Dictionary<GameObject, Queue<GameObject>> pooledObjects = new Dictionary<GameObject, Queue<GameObject>>();

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);

            Debug.LogWarning("There was more than one ObjectPool in the scene");
        }
        instance = this;
    }

    public GameObject GetObject(GameObject prefab)
    {
        if (pooledObjects.ContainsKey(prefab) && pooledObjects[prefab].Count > 0)
        {
            GameObject obj = pooledObjects[prefab].Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(prefab);
            if (!pooledObjects.ContainsKey(prefab))
            {
                pooledObjects[prefab] = new Queue<GameObject>();
            }

            return obj;
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);

        foreach (var kvp in pooledObjects)
        {
            if (kvp.Value.Contains(obj))
            {
                kvp.Value.Enqueue(obj);
                return;
            }
        }
    }
}