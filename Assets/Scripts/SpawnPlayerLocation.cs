using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerLocation : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Player.instance.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
