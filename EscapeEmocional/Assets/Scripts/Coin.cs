using UnityEngine;

public class Coin : MonoBehaviour {
    public int pontos = 1;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            
            if (GetComponent<AudioSource>() != null) {
                AudioSource audio = GetComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            }

            GameManager.Instance.GetPoints(pontos);
            Destroy(this.gameObject);
        }
    }
}
