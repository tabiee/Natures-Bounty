using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossZoomPan : MonoBehaviour
{
    private CinemachineVirtualCamera virtualcam;
    private float currentsize;

    private void Awake()
    {
        virtualcam = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        virtualcam.m_Lens.OrthographicSize = currentsize;

    }

    private void Start()
    {
        virtualcam.m_Lens.OrthographicSize = currentsize + 10 * Time.deltaTime;
    }
}
