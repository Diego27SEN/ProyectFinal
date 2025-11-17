using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mesero : MainMesero
{
    private float range = 1.5f;
    private Vector2 dir;
    private float degree = 90;

    void Update()
    {
        MovePlayer();
        Cooldown();
        Contador();
        Interaccion();
        HandleMovement();
    }

    public void Cooldown()
    {

        if (contador >= 40f && moveSpeed == 2)
        {
            moveSpeed++;
            contador = 0;
        }
    }
    public void HandleMovement()
    {
        MovePlayer();

        if (moveInput != Vector2.zero)
            dir = moveInput.normalized;
    }

    public void Interaccion()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("Interaccionando");
            Collider2D[] NPCS = Physics2D.OverlapCircleAll(transform.position, range);
            foreach(Collider2D NPC in NPCS)
            {
                if(NPC.tag == "NPC")
                {
                    Vector2 npcDir = (NPC.transform.position - transform.position).normalized;
                    float producto = Vector2.Dot(npcDir, dir);
                    float toRadiasn = Mathf.Acos(producto);
                    float toDegrees = toRadiasn * Mathf.Rad2Deg;
                    if (toDegrees <= degree) 
                    {
                        print("Interaccion con " + "el NPC");
                    }
                }
            }
        }
    }
}