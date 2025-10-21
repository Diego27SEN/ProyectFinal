using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mesero : MonoBehaviour
{
    public InputSystem_Actions inputs;
    public Rigidbody2D rb;


    public Vector2 moveInput;
    public float contador;
    public float moveSpeed;
    public float PlayerHp;
    public float KnockbackForce;

    private void Awake()
    {
        inputs = new InputSystem_Actions();
    }
    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Move.started += OnMove;
        inputs.Player.Move.performed += OnMove;
        inputs.Player.Move.canceled += OnMove;
    }



    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    private void OnDisable()
    {
        inputs.Player.Move.started -= OnMove;
        inputs.Player.Move.performed -= OnMove;
        inputs.Player.Move.canceled -= OnMove;
        inputs.Disable();
    }

    void Start()
    {

    }

    void Update()
    {
        transform.position += (Vector3)moveInput * moveSpeed * Time.deltaTime;
        Cooldawn();
        contador += Time.deltaTime;
        contador = Mathf.Min(contador, 10f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    public void TakeDamage(int damage, Vector3 origin)
    {
        PlayerHp = Math.Max(0, PlayerHp - damage);

        Vector2 knockBackDir = (transform.position - origin).normalized;

        rb.AddForce(knockBackDir * KnockbackForce, ForceMode2D.Impulse);

        print("Le sirvo comida al cliente");
    }

    public void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }

    public void Cooldawn()
    {

        if (contador >= 10f && moveSpeed == 2)
        {
            moveSpeed++;
            contador = 0;
        }
    }
}