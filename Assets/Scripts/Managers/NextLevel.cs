using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private string[] scenes; // The array of scene names
    [SerializeField] private List<GameObject> gameObjects; // The list of game objects
    private BoxCollider2D collider2D;

    private void Start()
    {
        FindGameObjects();
        collider2D = GetComponent<BoxCollider2D>();
        collider2D.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            int index = Random.Range(0, scenes.Length);
            SceneManager.LoadScene(scenes[index]);
        }
    }

    void FindGameObjects()
    {
        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("Enemy");
        gameObjects = new List<GameObject>();

        // Add only the parent game objects to the list
        foreach (GameObject obj in foundObjects)
        {
            if (obj.transform.parent == null)
            {
                gameObjects.Add(obj);
            }
        }
    }

    void Update()
    {
      if(gameObjects.Count > 0)
        {
            // Remove destroyed game objects from the list
            gameObjects.RemoveAll(item => !item.activeSelf);
            if (gameObjects.Count <= 0)
            {
                collider2D.enabled = true;
            }
        }
            
        
            
        
            
        
        
    }
}
