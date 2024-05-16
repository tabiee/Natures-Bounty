using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    [SerializeField] private string levelScene = "Room";
    public void BeginGame()
    {
        SceneManager.LoadScene(levelScene);
    }
}
