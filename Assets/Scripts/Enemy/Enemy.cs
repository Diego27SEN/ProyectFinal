using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy : MainEnemy
{
    private float moveSpeed = 2f;
    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }
    public GameObject Mesero;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Mesero.GetComponent<Mesero>().MoveSpeed -= 1;
            Destroy(gameObject);
        }

    }
    

    public void MotionEnemy()
    {
        Vector3 dir = (Mesero.transform.position - transform.position).normalized; //: Calcular la direccion desde el enemigo hacia el jugador
        transform.position += dir * speed * Time.deltaTime; //: Mover el enemigo hacia el jugador
    }
    public void Update()
    {
        MotionEnemy();
    }

}
