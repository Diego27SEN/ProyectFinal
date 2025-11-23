using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimation : MonoBehaviour
{
    public Animator controller;
    public SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        PlayerController.Instance
            .InputManager.OnMoveChange
            += SetMoveAnimation;
    }

    private void SetMoveAnimation(Vector2 move)
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * Time.fixedDeltaTime * PlayerController.Instance.playerMovement.moveSpeed);
    }
}