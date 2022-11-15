using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    
    public enum GameState { Jogando, Morreu, Pausa }
    private GameState _currentState;
    public GameState CurrentState { 
        get { return _currentState; } 
        set { 
            _currentState = value;
            
            switch (_currentState) {
                case GameState.Jogando:
                    break;
                case GameState.Morreu:
                    HandleMorreuState();
                    break;
                case GameState.Pausa:
                    break;
            }
        } 
    }



    public Text _Text;
    private int points = 0;
    public int maxPoints = 10;

    public bool isImortal = false;


    private void Awake() {
        Instance = this;
    }

    private void Start() {
        _currentState = GameState.Jogando;
        SetPoints(0);
    }

    // Handle de estados

    void HandleMorreuState() {
        Debug.Log("Morreu");
        Invoke("LoadScenePerdeu", 1f);
    }

    public void LoadScenePerdeu() {
        SceneManager.LoadScene("Derrota");
    }


    // Controle de pontuação

    public void AddPoints(int p) {
        points += p;
        _Text.text = $"{points}/{maxPoints}";

        if (points >= 10)
            SceneManager.LoadScene("Vitoria");
    }

    public void SetPoints(int p) {
        points = p;
        _Text.text = $"{points}/{maxPoints}";

        if (points >= 10)
            SceneManager.LoadScene("Vitoria");
    }


    public int GetPoints() {
        return points;
    }
}
