using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;
    public Button exitGameButton;
    public Button optionsReturnButton;
    public string LevelScene = "2DAapo";
    public GameObject optionItems;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        optionsButton.onClick.AddListener(Options);
        optionsReturnButton.onClick.AddListener(ReturnOptions);
        exitGameButton.onClick.AddListener(ExitGame);
        optionItems.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        SceneManager.LoadScene(LevelScene);

    }

    void Options()
    {
        optionItems.SetActive(true);
    }
    void ReturnOptions()
    {
        optionItems.SetActive(false);

    }

    void ExitGame()
    {
        Application.Quit();
        EditorApplication.ExitPlaymode();

    }
}
