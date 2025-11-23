using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mesero : MonoBehaviour
{
    [SerializeField] private ControllerMesero controllerMesero;
    [SerializeField] protected float contador;

    private void Update()
    {
<<<<<<< HEAD
        Cooldawn();
=======
        controllerMesero.MovePlayer();
>>>>>>> e6d524187421686bc29df751077e817bae0078b9
        Contador();
        Cooldawn();
    }

    public void Contador()
    {
        contador += Time.deltaTime;
        contador = Mathf.Min(contador, 40f);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision is IShowDialog)
        {
            collision.GetComponent<IShowDialog>().ShowDialog();
        }
    }

    public void Cooldawn()
    {

        if (contador >= 40f && controllerMesero.MoveSpeed == 2)
        {
            controllerMesero.MoveSpeed++;
            contador = 0;
        }
    }

}