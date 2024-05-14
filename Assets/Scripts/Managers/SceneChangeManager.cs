using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public string MainMenuScene = "MainMenu";
    public string LevelScene = "2DAapo";

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
