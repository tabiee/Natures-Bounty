using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToBoss : MonoBehaviour
{
    [SerializeField] private string bossScene; // The array of scene names
    private BoxCollider2D collider2D;
    // Start is called before the first frame update
    private void Start()
    {
       
        collider2D = GetComponent<BoxCollider2D>();
        collider2D.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(bossScene);
        }
    }
   
}
