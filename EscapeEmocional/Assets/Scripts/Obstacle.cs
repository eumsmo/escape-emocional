using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = -3.0f;

    void Update()
    {
        if (GameManager.Instance.CurrentGameState() == GameManager.GameState.Jogando)
        {
            transform.Translate(Vector3.forward * (speed) * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.ChangeGameState(GameManager.GameState.Morreu);
            GameManager.Instance.StopGame();
        }
    }
}
