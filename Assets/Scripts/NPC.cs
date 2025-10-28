using UnityEngine;

public class NPC : MainNPC
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("El jugador pidio la orden del cliente");
            Contador += Time.deltaTime;
            Contador = Mathf.Min(Contador, 10f);
        }

    }
    public void Interaccion()
    {
        if (Contador == 10f)
        {
            print("Orden completada");
            Destroy(gameObject);
        }
    }
    public void Update()
    {
        Interaccion();
    }     
}

