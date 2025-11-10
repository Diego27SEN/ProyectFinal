using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public float ContadorPuntos;
    public float cooldown;

    public enum GameState { None, Start, Playing, Win, Lose }
    public GameState state = GameState.Start;

    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject gameUI;
    public GameObject winScreen;
    public GameObject loseScreen;

    void Start()
    {
        UpdateGameState();
    }

    public void SetGameState(GameState newState)
    {
        state = newState;
        UpdateGameState();
    }

    void UpdateGameState()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        gameUI.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);


        switch (state)
        {
            case GameState.Start:
                mainMenu.SetActive(true);
                break;

            case GameState.Playing:
                gameUI.SetActive(true);
                break;

            case GameState.Win:
                winScreen.SetActive(true);
                break;

            case GameState.Lose:
                loseScreen.SetActive(true);
                break;
        }
    }

    //  botones
    public void StartGame()
    {
        SetGameState(GameState.Playing);
    }
    public void OpenMenu()
    {
        SetGameState(GameState.Start);
    }
    public void WinGame()
    {
        SetGameState(GameState.Win);
    }
    public void LoseGame()
    {
        SetGameState(GameState.Lose);
    }
}