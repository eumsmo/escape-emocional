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

    public Animator[] m_Animator;

    GestosController controladorGestos = new GestosController();

    public Vector3 jump = new Vector3(0.0f, 2.0f, 0.0f);
    public Vector3 down = new Vector3(0.0f, -2.0f, 0.0f);
    public float jumpForce = 2.0f, downForce = 4.0f, downTime = 0f, downTimer = 1.0f;
    Rigidbody rb;

    public bool usarTeclado = false;

    public LayerMask groundLayerMask;
    public bool taNoChao;
    BoxCollider currentCollider;

    public static PlayerController instance;

    void UpdateCurrentCollider() {
        string estadoPlayer = downTime == 0 ? "EmPe" : "Deitado";
        currentCollider = player.transform.Find(estadoPlayer).gameObject.GetComponent<BoxCollider>();
    }

    public Vector3 playerBottom {
        get { return currentCollider.bounds.center - new Vector3(0, currentCollider.bounds.extents.y, 0); }
    }


    public void EscolhePersonagem(int personagemId) {
        activePlayerIndex = personagemId;
        if (player != null)
            player.SetActive(false);

        player = players[activePlayerIndex];
        player.SetActive(true);

        UpdateCurrentCollider();
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

        UpdateCurrentCollider();
    }

    public void PlayerDie() {
        m_Animator[activePlayerIndex].SetTrigger("Die");
    }

    void Start() {
        //currentPos = PlayerPos.Middle;
        instance = this;
        rb = GetComponent<Rigidbody>();
        originalCamPos = cameraObj.transform.position;
        cameraTarget = originalCamPos;
        currentPos = PlayerPos.Middle;
        EscolhePersonagem(FaseMaster.faseId);
    }


    void Update() {
        // Caso o jogo esteja pausado ou o jogador tenha morrido, não faz nada
        if (GameManager.Instance.CurrentState != GameManager.GameState.Jogando)
            return;

        // Checa se houve algum input e se o jogador está no chão
        bool ocorreuInput = usarTeclado ? controladorGestos.InputTeclado() : controladorGestos.ChecaGestos();
        taNoChao = IsGrounded();

        // Caso tenha ocorrido algum input, atualiza a posição do jogador
        if (ocorreuInput) {
            string movimento = controladorGestos.movimento;

            if (movimento == "cima" && taNoChao) {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                m_Animator[activePlayerIndex].SetTrigger("Jump");
                PlayerDown(false);
            } else if (movimento == "baixo") {
                PlayerDown(true);
                m_Animator[activePlayerIndex].SetTrigger("Slide");
                if (!taNoChao)
                    rb.AddForce(down * downForce, ForceMode.Impulse);
            }


            if (movimento == "esquerda" && currentPos != PlayerPos.Left) {
                if (currentPos == PlayerPos.Right) {
                    targetPosition = new Vector3(0, transform.position.y, transform.position.z);
                    cameraTarget = originalCamPos;
                    currentPos = PlayerPos.Middle;
                }
                else {
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
                }
                else {
                    targetPosition = new Vector3(1, transform.position.y, transform.position.z);
                    cameraTarget = originalCamPos;
                    cameraTarget.x += offsetCam;
                    currentPos = PlayerPos.Right;
                }
            }
        }
    }

    void FixedUpdate() {
        // Caso o jogo esteja pausado ou o jogador tenha morrido, não faz nada
        if (GameManager.Instance.CurrentState != GameManager.GameState.Jogando)
            return;
        
        // Atualiza a posição horizontal do jogador
        targetPosition.y = transform.position.y;
        targetPosition.z = transform.position.z;
        gameObject.transform.position = Vector3.Lerp(transform.position, targetPosition, laneSwitchSpeed * Time.fixedDeltaTime);
        
        // Atualiza a posição da câmera
        cameraObj.transform.position = Vector3.Lerp(cameraObj.transform.position, cameraTarget, laneSwitchSpeed * Time.fixedDeltaTime);

        // Atualiza o tempo de deitado
        if (downTime > 0) {
            downTime -= Time.fixedDeltaTime;
        } else if (downTime < 0) {
            PlayerDown(false);
        }
    }



    public bool IsGrounded() {
        Vector3 bottom = playerBottom;
        Vector3 halfExtends = currentCollider.bounds.extents;
        halfExtends.y = 0.1f;

        // Check if box below player is grounded
        if (Physics.CheckBox(bottom, halfExtends, Quaternion.identity, groundLayerMask)) {
            return true;
        }

        return false;
    }

}
