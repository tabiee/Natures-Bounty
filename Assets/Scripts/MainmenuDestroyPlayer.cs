using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainmenuDestroyPlayer : MonoBehaviour
{
   [SerializeField] private Transform player;
   [SerializeField] private GameObject mainCam;
   [SerializeField] private GameObject eventsys;
   [SerializeField] private GameObject gamemanager;
 

    private void Start()
    {
        if(player != null)
        {
            player = Player.instance.gameObject.transform.parent;
            Destroy(player);
        }
        if (mainCam != null)
        {
            mainCam = GameObject.Find("Main Camera");
            Destroy(mainCam);
        }
        if (eventsys != null)
        {
            eventsys = GameObject.Find("EventSystem");
            Destroy(eventsys);

        }
        if (gamemanager != null)
        {
            gamemanager = GameObject.Find("GameManager");
            Destroy(gamemanager);

        }

  
    }

   
}
