using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemie : MainEnemy
{
    public GameObject Mesero;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Mesero.GetComponent<Mesero>().moveSpeed -= 1;
            Destroy(gameObject);
        }

    }
    public void Update()
    {
        Vector3 dir = (Mesero.transform.position - transform.position).normalized; //: Calcular la direccion desde el enemigo hacia el jugador
        transform.position += dir * speed * Time.deltaTime; //: Mover el enemigo hacia el jugador
    }

}
