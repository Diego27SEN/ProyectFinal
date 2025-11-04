using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public float ContadorPuntos;
    public float cooldown;

    public enum GameState { None, Start, Playing, Win, Lose }
    public GameState state = GameState.Start;

    public GameObject MainMenu;
    public GameObject gameUI;
    public GameObject WinScreen;
    public GameObject GameOver;

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
        // Oculta todo al inicio
        MainMenu.SetActive(false);
        gameUI.SetActive(false);
        WinScreen.SetActive(false);
        GameOver.SetActive(false);

        switch (state)
        {
            case GameState.Start:
                MainMenu.SetActive(true);
                break;

            case GameState.Playing:
                gameUI.SetActive(true);
                break;

            case GameState.Win:
                WinScreen.SetActive(true);
                break;

            case GameState.Lose:
                GameOver.SetActive(true);
                break;
        }
    }

    // Ejemplo de botones
    public void PlayGame()
    {
        SetGameState(GameState.Playing);
    }

    public void WinGame()
    {
        SetGameState(GameState.Win);
    }

    public void LoseGame()
    {
        SetGameState(GameState.Lose);
    }

    public void ReturnToMenu()
    {
        SetGameState(GameState.Start);
    }
}