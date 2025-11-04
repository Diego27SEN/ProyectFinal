using UnityEngine;
using UnityEngine.InputSystem;

public class MainMesero : MonoBehaviour
{
    public InputSystem_Actions inputs;
    public Rigidbody2D rb;


    public Vector2 moveInput;
    [SerializeField] protected float contador;
    [SerializeField] protected float moveSpeed = 3f;
    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }

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
    public void MovePlayer()
    {
        transform.position += (Vector3)moveInput * moveSpeed * Time.deltaTime; // Mover el jugador segun la entrada
    }
    public void Contador()
    {
        contador += Time.deltaTime;
        contador = Mathf.Min(contador, 40f);
    }
}
