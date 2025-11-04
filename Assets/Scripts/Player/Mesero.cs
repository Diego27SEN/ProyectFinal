using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mesero : MainMesero
{


    void Update()
    {
        MovePlayer();
        Cooldawn();
        Contador();
    }

    public void Cooldawn()
    {

        if (contador >= 40f && moveSpeed == 2)
        {
            moveSpeed++;
            contador = 0;
        }
    }
}