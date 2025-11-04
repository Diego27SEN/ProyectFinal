using UnityEngine;

public class NPC : MainNPC
{
    public Transform PUNTOA;
    public Transform PUNTOB;
    private float distanciaMinima = 0.1f;
    private int ultimoNivelMostrado = 0; // Guarda el último nivel mostrado

    void Update()
    {
        accionMovimiento();
        ActualizarNivelPorReputacion();
    }
    private void accionMovimiento()
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
            //print("Llego al punto A");
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
            
            //print("Llego al punto B");
        }
    }
    private void GestionContador()
    {
        Contador += Time.deltaTime;
        Contador = Mathf.Min(Contador, 60f);
    }
    private void ActualizarNivelPorReputacion()
    {
        if (Contador <= 20f)
            nivel = 1;
        else if (Contador <= 40f)
            nivel = 2;
        else if (Contador <= 60f)
            nivel = 3;
        GestionarPorNivel();
        GestionContador();
    }
    private void GestionarPorNivel()
    {
        if (nivel != ultimoNivelMostrado) // Solo actualiza si el nivel ha cambiado
        {
            switch (nivel)
            {
                case 1:
                    print("Reputacion: Feliz");
                    break;
                case 2:
                    print("Reputacion: Media");
                    break;
                case 3:
                    print("Reputacion: Baja");
                    break;
            }
            ultimoNivelMostrado = nivel; // Actualiza el nivel mostrado
        }
    }

    private void EntregarPedido()
    {
        entregaPedido = true;
        //print("Pedido entregado por el NPC.");

    }
}

