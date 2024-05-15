using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PauseMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    bool menuIsOpen;
    [SerializeField] private ControllerHandler controllerHandler;
    public Button continueButton;
    public Button restartButton;
    public Button exitButton;
    private InputAction pauseInput;
    private PlayerInput input;
    public string MainMenuScene = "MainMenu";
    public string LevelScene = "2DAapo";

    private void Awake()
    {
        input = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
    }

   

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
        SceneManager.LoadScene(LevelScene);

    }

    public void ExitGame()
    {
        Debug.Log("Game Exited");
        SceneManager.LoadScene(MainMenuScene);
    }
}