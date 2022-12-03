using UnityEngine;

public class ButtonPause : MonoBehaviour
{
    public GameObject panel, musica;

    public void SetMusicaGameObject(GameObject musica) {
        this.musica = musica;
    }

    void Awake()
    {
        UpdatePanelVisibility();
    }
    
    public void UpdatePanelVisibility()
    {
        bool isGamePaused = GameManager.Instance.CurrentState == GameManager.GameState.Pausa;
        panel.SetActive(isGamePaused);
    }

    public void Pause()
    {
        if (GameManager.Instance.CurrentState == GameManager.GameState.Morreu)
            return;

        Time.timeScale = 0;
        GameManager.Instance.CurrentState = GameManager.GameState.Pausa;
        UpdatePanelVisibility();

        if (musica != null)
            musica.GetComponent<AudioSource>().Pause();
    }
    
    public void SairPause()
    {
        Time.timeScale = 1;
        GameManager.Instance.CurrentState = GameManager.GameState.Jogando;
        UpdatePanelVisibility();

        if (musica != null)
            musica.GetComponent<AudioSource>().Play();
    }
}
