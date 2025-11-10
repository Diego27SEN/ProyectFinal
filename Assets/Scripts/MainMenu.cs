using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject optionsMenu;
    public GameObject mainMenu;

    public void OpenOptionsPanel()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void OpenMainMenuPanel()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void PlayGame()
    {
        gameManager.StartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}