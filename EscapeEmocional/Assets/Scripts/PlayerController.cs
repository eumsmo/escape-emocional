using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum PlayerPos { Left, Right, Middle };

    PlayerPos currentPos;

    private Vector3 jump;
    public float jumpForce = 2.0f;
    Rigidbody rb;
    public float groundPos;

    public bool isGrounded()
    {
        if (transform.position.y <= groundPos)
            return true;
        else
            return false;
    }
    
    void Start()
    {
        //currentPos = PlayerPos.Middle;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        groundPos = transform.position.y;
    }

    void Update()
    {
        if (GameManager.Instance.CurrentGameState() == GameManager.GameState.Jogando)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {

                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && currentPos != PlayerPos.Left)
            {
                if (currentPos == PlayerPos.Right)
                {
                    this.gameObject.transform.position = new Vector3(0, transform.position.y, transform.position.z);
                    currentPos = PlayerPos.Middle;
                }
                else
                {
                    this.gameObject.transform.position = new Vector3(-1, transform.position.y, transform.position.z);
                    currentPos = PlayerPos.Left;
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && currentPos != PlayerPos.Right)
            {
                if (currentPos == PlayerPos.Left)
                {
                    this.gameObject.transform.position = new Vector3(0, transform.position.y, transform.position.z);
                    currentPos = PlayerPos.Middle;
                }
                else
                {
                    this.gameObject.transform.position = new Vector3(1, transform.position.y, transform.position.z);
                    currentPos = PlayerPos.Right;
                }
            }
        }
    }
}
