using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public string MainMenuScene;
    public string LevelScene;

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
