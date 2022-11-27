using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerManeger pManeger;    

    void Update()
    {            
        //input para realizar o pulo
        if (Input.GetKeyDown(KeyCode.Z) && pManeger.CheckChao && !pManeger.pulando)
        {
            pManeger.pular();
            pManeger.doubleJump = 1;
        } 
        else if (pManeger.CheckChao && pManeger.pulando)
        {
            pManeger.pulando = false;            
        }
        //input para realizar o segundo pulo
        if (Input.GetKeyDown(KeyCode.Z) && !pManeger.CheckChao && pManeger.doubleJump == 1)
        {
            pManeger.pularDouble();
        }
        //input para interagir com objtos no mapa
        if(Input.GetKeyDown(KeyCode.X) && pManeger.inter)
        {
            pManeger.adicinarItem();           
        }
        //input para abrir e fechar inventario
        if (Input.GetKeyDown(KeyCode.C) && !pManeger.invOpen)
        {
            pManeger.invOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && pManeger.invOpen) 
        {
            pManeger.invOpen = false;
        }
    }
    void FixedUpdate()
    {
        //input para realizar o movimento
        pManeger.h = Input.GetAxisRaw("Horizontal");        
    } 
}
