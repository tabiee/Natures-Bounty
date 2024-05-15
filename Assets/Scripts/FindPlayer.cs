using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FindPlayer : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;

    private void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }
    // Start is called before the first frame update
    void Start()
    {
        vcam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
