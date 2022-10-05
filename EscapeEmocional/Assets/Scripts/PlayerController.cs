using UnityEngine;

public class PlayerController : MonoBehaviour {
    enum PlayerPos { Left, Right, Middle };

    public GameObject cameraObj;
    public float offsetCam;
    Vector3 originalCamPos, cameraTarget;

    PlayerPos currentPos;
    Vector3 targetPosition;
    public float laneSwitchSpeed;

    public int activePlayerIndex = 0;
    public GameObject[] players;
    GameObject player;

    GestosController controladorGestos = new GestosController();

    public Vector3 jump = new Vector3(0.0f, 2.0f, 0.0f);
    public Vector3 down = new Vector3(0.0f, -2.0f, 0.0f);
    public float jumpForce = 2.0f, downForce = 4.0f, downTime = 0f, downTimer = 1.0f;
    Rigidbody rb;
    public float groundPos;

    public ChaoDetecter chaoDetecter;
    public bool usarTeclado = false;
    public bool isInGround = false;

    public bool isGrounded() {
        return chaoDetecter.isOnFloor; //transform.position.y <= groundPos;
    }

    public void EscolhePersonagem(int personagemId) {
        activePlayerIndex = personagemId;
        if (player != null)
            player.SetActive(false);

        player = players[activePlayerIndex];
        player.SetActive(true);
    }
    
    void PlayerDown(bool estado) {
        GameObject playerUp = player.transform.Find("EmPe").gameObject;
        GameObject playerDown = player.transform.Find("Deitado").gameObject;

        if (estado) {
            playerUp.SetActive(false);
            playerDown.SetActive(true);
            downTime = downTimer;
        } else {
            playerUp.SetActive(true);
            playerDown.SetActive(false);
            downTime = 0;
        }
    }

    void Start() {
        //currentPos = PlayerPos.Middle;
        rb = GetComponent<Rigidbody>();
        groundPos = transform.position.y;
        originalCamPos = cameraObj.transform.position;
        cameraTarget = originalCamPos;
        currentPos = PlayerPos.Middle;
        EscolhePersonagem(FaseMaster.faseId);
    }

    void Update() {
        bool ocorreuInput = usarTeclado ? controladorGestos.InputTeclado() : controladorGestos.ChecaGestos();
        isInGround = chaoDetecter.isOnFloor;

        if (GameManager.Instance.CurrentGameState() == GameManager.GameState.Jogando && ocorreuInput) {
            string movimento = controladorGestos.movimento;

            if (movimento == "cima" && isGrounded()) {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                PlayerDown(false);
                chaoDetecter.isOnFloor = false;
            } else if (movimento == "baixo") {
                PlayerDown(true);
                if (!isGrounded())
                    rb.AddForce(down * downForce, ForceMode.Impulse);
            }

            if (movimento == "esquerda" && currentPos != PlayerPos.Left) {
                if (currentPos == PlayerPos.Right) {
                    targetPosition = new Vector3(0, transform.position.y, transform.position.z);
                    cameraTarget = originalCamPos;
                    currentPos = PlayerPos.Middle;
                } else {
                    targetPosition = new Vector3(-1, transform.position.y, transform.position.z);
                    cameraTarget = originalCamPos;
                    cameraTarget.x -= offsetCam;
                    currentPos = PlayerPos.Left;
                }
            }

            if (movimento == "direita" && currentPos != PlayerPos.Right) {
                if (currentPos == PlayerPos.Left) {
                    targetPosition = new Vector3(0, transform.position.y, transform.position.z);
                    cameraTarget = originalCamPos;
                    currentPos = PlayerPos.Middle;
                } else {
                    targetPosition = new Vector3(1, transform.position.y, transform.position.z);
                    cameraTarget = originalCamPos;
                    cameraTarget.x += offsetCam;
                    currentPos = PlayerPos.Right;
                }
            }
            
        }
    }

    void FixedUpdate() {
        targetPosition.y = transform.position.y;
        targetPosition.z = transform.position.z;
        this.gameObject.transform.position = Vector3.Lerp(transform.position, targetPosition, laneSwitchSpeed * Time.fixedDeltaTime);
        
        cameraObj.transform.position = Vector3.Lerp(cameraObj.transform.position, cameraTarget, laneSwitchSpeed * Time.fixedDeltaTime);


        if (downTime > 0) {
            downTime -= Time.fixedDeltaTime;
        } else if (downTime < 0) {
            PlayerDown(false);
        }
    }
}
