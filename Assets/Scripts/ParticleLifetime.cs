using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLifetime : MonoBehaviour
{
    [SerializeField] private float lifetime = 0.25f;
    void OnEnable()
    {
        Destroy(gameObject, lifetime);
    }
}
