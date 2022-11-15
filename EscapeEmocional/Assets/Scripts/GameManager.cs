using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public enum GameState { Jogando, Morreu, Pausa }
    private GameState currentState;
    public static bool isPause = true;
    

    public Text _Text;
    private int points = 0;
    public int maxPoints = 10;

    public bool isImortal = false;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentState = GameState.Jogando;
        GetPoints(0);
    }

    public void ChangeGameState(GameState state)
    {
        currentState = state;
    }

    public GameState CurrentGameState()
    {
        return currentState;
    }

    public void StopGame()
    {
        PlayerController.isAlive = false;
        Invoke("perdeu", 1f);
    }

    public void perdeu()
    {
        SceneManager.LoadScene("Derrota");
    }
    public void GetPoints(int p)
    {
        points += p;
        _Text.text = $"{points}/{maxPoints}";

        if (points >= 10)
            SceneManager.LoadScene("Vitoria");
    }
}
