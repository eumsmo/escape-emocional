using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState { Jogando, Morreu, Pausa }

    private GameState currentState;

    public GameObject obstacle;
    public GameObject coin;

    public Text _Text;
    private int points = 0;
    public int maxPoints = 10;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentState = GameState.Jogando;
        GetPoints(0);
        // o Invoke Repeating abaixo chama o método SummonObstacles() depois de 1 segundo
        // e o chama de novo a cada 3 segundos 
        InvokeRepeating("SummonObstacles", 1, 3);
        InvokeRepeating("SummonCoins", 2.5f, 3);
    }

    public void ChangeGameState(GameState state)
    {
        currentState = state;
    }

    public GameState CurrentGameState()
    {
        return currentState;
    }

    public void SummonObstacles()
    {
        Vector3 pos = new Vector3(Random.Range(-1, 2), 1, 15);
        Instantiate(obstacle, pos, transform.rotation);
    }

    public void SummonCoins()
    {
        Vector3 pos = new Vector3(Random.Range(-1, 2), Random.Range(1, 3), 15);
        Instantiate(coin, pos, transform.rotation);
    }

    public void StopGame()
    {
        CancelInvoke();
        //ChangeGameState(GameState.Morreu);
    }

    public void GetPoints(int p)
    {
        points += p;
        _Text.text = $"{points}/{maxPoints}";
    }
}
