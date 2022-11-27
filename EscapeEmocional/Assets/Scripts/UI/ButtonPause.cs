using UnityEngine;

public class ButtonPause : MonoBehaviour
{
    public GameObject panel;


    void Awake()
    {
        SairPause();
    }
    
    public void UpdatePanelVisibility()
    {
        bool isGamePaused = GameManager.Instance.CurrentState == GameManager.GameState.Pausa;
        Debug.Log(isGamePaused);
        panel.SetActive(isGamePaused);
    }

    public void Pause()
    {
        if (GameManager.Instance.CurrentState == GameManager.GameState.Morreu)
            return;

        Time.timeScale = 0;
        GameManager.Instance.CurrentState = GameManager.GameState.Pausa;
        UpdatePanelVisibility();
    }
    
    public void SairPause()
    {
        Time.timeScale = 1;
        GameManager.Instance.CurrentState = GameManager.GameState.Jogando;
        UpdatePanelVisibility();
    }
}
