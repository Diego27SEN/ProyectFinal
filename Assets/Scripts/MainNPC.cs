using UnityEngine;

public class MainNPC : MonoBehaviour
{
    [SerializeField] protected int ID;
    [SerializeField] protected float speed = 2.0f;
    [SerializeField] protected float Contador;
    [SerializeField] protected bool llegoAlPuntoA = false;
    [SerializeField] protected bool llegoAlPuntoB = false;
    [SerializeField] protected bool entregaPedido = false;
    [SerializeField] protected bool sillOcupada = false;
}