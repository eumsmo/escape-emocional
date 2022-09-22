using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = -3.0f;
    public int pontos = 1;

    void Update()
    {
        if (GameManager.Instance.CurrentGameState() == GameManager.GameState.Jogando)
        {
            transform.Translate(Vector3.forward * (speed) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Ryco");
            GameManager.Instance.GetPoints(pontos);
            Destroy(this.gameObject);
        }
    }
}
