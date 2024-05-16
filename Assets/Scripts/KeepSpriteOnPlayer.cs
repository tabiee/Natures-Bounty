using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepSpriteOnPlayer : MonoBehaviour
{
    void Update()
    {
        transform.position = Player.instance.gameObject.transform.position;
    }
}
