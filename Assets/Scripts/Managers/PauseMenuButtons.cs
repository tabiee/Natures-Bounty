using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;




public class PauseMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    bool menuIsOpen;
   [SerializeField] private ControllerHandler controllerHandler;
    public Button continueButton;
    public Button restartButton;
    public Button exitButton;
    private InputAction pauseInput;
   [SerializeField] private PlayerInput input;
    public string MainMenuScene = "MainMenu";
    public string FirstLevel = "Room 0";


 



    // Start is called before the first frame update
    void Start()
    {
        pauseInput = input.actions["PauseMenu"];
        Menu.SetActive(false);
        menuIsOpen = false;
        Time.timeScale = 1;
        continueButton.onClick.AddListener(ContinueGame);
        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitGame);

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

        if (controllerHandler.controllerIsConnected)
        {
            if (Gamepad.current.startButton.wasPressedThisFrame)
            {
                if (!menuIsOpen)
                {
                    PauseGame();
                    
                }

                else
                    ContinueGame();
            }

           
        }

        if (!controllerHandler.controllerIsConnected)
        {
            if (pauseInput.triggered)
            {
                if (!menuIsOpen)
                {
                    Debug.Log("Pausemenu");
                    PauseGame();
                    Cursor.visible = false;
                }

                else
                    ContinueGame();
                Cursor.visible = true;

            }

        }
       

    }

    public void PauseGame()
    {
        Debug.Log("Game paused");
        Menu.SetActive(true);
        menuIsOpen = true;
        Time.timeScale = 0;
        

    }

    public void ContinueGame()
    {
        Debug.Log("Game Continued");
        Menu.SetActive(false);
        menuIsOpen = false;
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        Debug.Log("Game Restarted");
        SceneManager.LoadScene(FirstLevel);
        Menu.SetActive(false);
        menuIsOpen = false;
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Debug.Log("Game Exited");
        SceneManager.LoadScene(MainMenuScene);
        Menu.SetActive(false);
        menuIsOpen = false;
        Time.timeScale = 1;
    }
}
