using UnityEngine;

public class PlayerController : MonoBehaviour {
    enum PlayerPos { Left, Right, Middle };

    PlayerPos currentPos;
    Vector3 targetPosition;
    public float laneSwitchSpeed;

    public GameObject player, playerDown;

    GestosController controladorGestos = new GestosController();

    public Vector3 jump = new Vector3(0.0f, 2.0f, 0.0f);
    public Vector3 down = new Vector3(0.0f, -2.0f, 0.0f);
    public float jumpForce = 2.0f, downForce = 4.0f, downTime = 0f, downTimer = 1.0f;
    Rigidbody rb;
    public float groundPos;

    public bool isGrounded() {
        return transform.position.y <= groundPos;
    }
    
    void Start() {
        //currentPos = PlayerPos.Middle;
        rb = GetComponent<Rigidbody>();
        groundPos = transform.position.y;
    }

    void PlayerDown(bool estado) {
        if (estado) {
            player.SetActive(false);
            playerDown.SetActive(true);
            downTime = downTimer;
        } else {
            player.SetActive(true);
            playerDown.SetActive(false);
            downTime = 0;
        }
    }

    void Update() {
        if (GameManager.Instance.CurrentGameState() == GameManager.GameState.Jogando && controladorGestos.ChecaGestos()) {
            string movimento = controladorGestos.movimento;
            Debug.Log(movimento);

            if (movimento == "cima" && isGrounded()) {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                PlayerDown(false);
            } else if (movimento == "baixo") {
                PlayerDown(true);
                if (!isGrounded())
                    rb.AddForce(down * downForce, ForceMode.Impulse);
            }

            if (movimento == "esquerda" && currentPos != PlayerPos.Left) {
                if (currentPos == PlayerPos.Right) {
                    targetPosition = new Vector3(0, transform.position.y, transform.position.z);
                    currentPos = PlayerPos.Middle;
                } else {
                    targetPosition = new Vector3(-1, transform.position.y, transform.position.z);
                    currentPos = PlayerPos.Left;
                }
            }

            if (movimento == "direita" && currentPos != PlayerPos.Right) {
                if (currentPos == PlayerPos.Left) {
                    targetPosition = new Vector3(0, transform.position.y, transform.position.z);
                    currentPos = PlayerPos.Middle;
                } else {
                    targetPosition = new Vector3(1, transform.position.y, transform.position.z);
                    currentPos = PlayerPos.Right;
                }
            }
            
        }
    }

    void FixedUpdate() {
        targetPosition.y = transform.position.y;
        targetPosition.z = transform.position.z;
        this.gameObject.transform.position = Vector3.Lerp(transform.position, targetPosition, laneSwitchSpeed * Time.fixedDeltaTime);

        if (downTime > 0) {
            downTime -= Time.fixedDeltaTime;
        } else if (downTime < 0) {
            PlayerDown(false);
        }
    }
}
