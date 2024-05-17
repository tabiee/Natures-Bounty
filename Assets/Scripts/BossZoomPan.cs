using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossZoomPan : MonoBehaviour
{
    private CinemachineVirtualCamera virtualcam;
    private float currentsize = 8f;
    private float targetValue = 20f;
    private float increaseSpeed = 1f; // Change this to control the speed of the increase


    private void Awake()
    {
        virtualcam = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        virtualcam.m_Lens.OrthographicSize = currentsize;

    }

    private void Start()
    {
        StartCoroutine(IncreaseValueOverTime());
    }

    private IEnumerator IncreaseValueOverTime()
    {
        while (currentsize < targetValue)
        {
            currentsize += increaseSpeed * Time.deltaTime;
            yield return null;
        }

        currentsize = targetValue; // Ensure the value is exactly the target value at the end
        
    }

    private void Update()
    {
        virtualcam.m_Lens.OrthographicSize = currentsize;

    }
}
