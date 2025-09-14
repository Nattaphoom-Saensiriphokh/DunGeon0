using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveControls : MonoBehaviour
{
    public float speed = 5f;
    private GatherInput GatherInput;
    private new Rigidbody2D rigidbody2D;
    private int direction = 1; // to right-hand side
    private Vector3 originalScale;
    private Animator Players;
    public float jumpForce = 7f;
    public float rayLength;
    public LayerMask groundLayer;
    public Transform leftPoint;
    public Transform rightPoint;
    private bool grounded = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GatherInput = GetComponent<GatherInput>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        Players = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckStatus();
        Move();
        JumpPlayer();
        SetAnimatorValues();
    }
    private void SetAnimatorValues()
    {
        Players.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));
        Players.SetFloat("vSpeed", rigidbody2D.velocity.y);
        Players.SetBool("Grounded", grounded);
    }
    private void Move()
    {
        Flip();
        rigidbody2D.velocity = new Vector2(speed * GatherInput.valueX, rigidbody2D.velocity.y);
    }

    private void Flip()
    {
        if (GatherInput.valueX * direction < 0)
        {
            direction *= -1;
            transform.localScale = new Vector3(originalScale.x * direction, originalScale.y, originalScale.z);
        }
    }
    private void JumpPlayer()
    {
        if (GatherInput.jumpInput && grounded)
        {
            rigidbody2D.velocity = new Vector2(GatherInput.valueX * speed, jumpForce);
        }
        GatherInput.jumpInput = false;
    }
    private void CheckStatus()
    {
        RaycastHit2D leftCheckHit = Physics2D.Raycast(leftPoint.position, Vector2.down, rayLength, groundLayer);
        RaycastHit2D rightCheckHit = Physics2D.Raycast(rightPoint.position, Vector2.down, rayLength, groundLayer);

        // ถ้าฝั่งซ้ายหรือขวาแตะพื้น ให้ถือว่าติดพื้น
        grounded = (leftCheckHit || rightCheckHit);
    }
}
