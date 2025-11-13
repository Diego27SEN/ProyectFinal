using UnityEngine;

public class Sillas : MonoBehaviour
{
    [SerializeField]private bool ocupado = false;

    public bool Ocupado
    {
        get => ocupado;
        set => ocupado = value;
    }
}
