using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitGameButton;
    [SerializeField] private Button optionsReturnButton;
    [SerializeField] private string LevelScene = "2DAapo";
    [SerializeField] private GameObject optionItems;


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
        GameObject selected = EventSystem.current.currentSelectedGameObject;
        if (selected != null)
        {
            Selectable selectable = selected.GetComponent<Selectable>();
            if (selectable != null)
            {
                ColorBlock colors = selectable.colors;
                colors.selectedColor = Color.white; // Change this to your desired highlight color
                selectable.colors = colors;
            }
        }
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

    }
}
