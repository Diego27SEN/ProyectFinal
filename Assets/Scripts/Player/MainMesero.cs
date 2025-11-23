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
   

    public void Contador()
    {
        contador += Time.deltaTime;
        contador = Mathf.Min(contador, 40f);
    }
}
