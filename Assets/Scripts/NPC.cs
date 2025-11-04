using UnityEngine;

public class NPC : MainNPC
{
    public Transform PUNTOA;
    public Transform PUNTOB;
    private float distanciaMinima = 0.1f; // Distancia para considerar que llegó

    void Update()
    {
        if (!llegoAlPuntoA && PUNTOA != null)
        {
            MoverHaciaPuntoA();
        }
        else if (!llegoAlPuntoB && llegoAlPuntoA && PUNTOA != null)
        {
            MoverHaciaPuntoB();
        }
        else if (llegoAlPuntoA && llegoAlPuntoB && !entregaPedido)
        {
            EntregarPedido();
        }
    }

    private void MoverHaciaPuntoA()
    {
        Vector3 direccionA = (PUNTOA.position - transform.position).normalized;
        float distancia = Vector3.Distance(transform.position, PUNTOA.position);

        if (distancia > distanciaMinima)
        {
            transform.position += direccionA * speed * Time.deltaTime;
        }
        else
        {
            llegoAlPuntoA = true;
            print("Llego al punto A");
        }
    }
    private void MoverHaciaPuntoB()
    {
        Vector3 direccionB = (PUNTOB.position - transform.position).normalized;
        float distancia = Vector3.Distance(transform.position, PUNTOB.position);
        if (distancia > distanciaMinima)
        {
            transform.position += direccionB * speed * Time.deltaTime;
        }
        else
        {
            llegoAlPuntoB = true;
            
            print("Llego al punto B");
        }
    }

    private void EntregarPedido()
    {
        entregaPedido = true;
        print("Pedido entregado por el NPC.");

    }
}

