using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManeger : MonoBehaviour
{
    public int direcao, doubleJump = 0, vida;
    public Rigidbody2D rb;
    public float vel, forcaPulo, h, timeInvencivel;
    public bool CheckChao, pulando, flip, invencivel, inter, invOpen;
    public Transform chao;
    public PlayerAnim pAnin;
    public Sprite[] sVida;
    public Image BarraVida;
    public SpriteRenderer Player;    
    public ItensLista itensInv;
    public inventario inv;
    public GameObject mochila;

    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        Player = GetComponent<SpriteRenderer>();        
    }
    
    void Update()
    {
        //Faz a verificação se o personagem esta no chao
        CheckChao = Physics2D.Linecast(transform.position, chao.transform.position, 1 << LayerMask.NameToLayer("chao"));
        gAnim();
        flipar();
        AtualizarVida(vida);
        pInvencivel();
        inventarioAberto();
    }

    private void FixedUpdate()
    {
        //Realiza o movimento
        movimento(h);
    }

    //Movimentação do personagem
    public void movimento(float h)
    {   //coloca velocidade no rigidbody        
        rb.velocity = new Vector2(h * vel * Time.deltaTime, rb.velocity.y);        
    }

    // função para o flip
    void cflip()
    {  
        flip = !flip;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    //Faz a execução do flip
    public void flipar()
    {
        if (direcao == 0 && h < 0)
        {
            cflip();
            direcao = 1;
        }
        else if (direcao == 1 && h > 0)
        {
            cflip();
            direcao = 0;
        }
    }
    //Função para realizar o pulo
    public void pular()
    {        
        rb.AddForce(Vector2.up * forcaPulo);
        pulando = true;
    }
    //função para realizar o segundo pulo
    public void pularDouble()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * (forcaPulo + 180));
        doubleJump = 0;
    }
    //adicionar o item no inventario
    public void adicinarItem()
    {
        inv.list.Add(itensInv.Item);        
        Destroy(itensInv.obj);        
    }
    //funcao para as animacoes
    void gAnim()
    {       
        pAnin.setMoviment(h);
        pAnin.setCheckChao(CheckChao);
        pAnin.setSpeedY((int)rb.velocity.y);
    }
    void AtualizarVida(int vida)
    {
        //Coloca as sprites da barra de vida
        BarraVida.sprite = sVida[vida];
        //se chegar a 0 o jogador morre
        if(vida == 0)
        {
            Destroy(gameObject);
        }
    }
    //Faz o jogador ficar imortal por algum tempo
    void pInvencivel()
    {
        if (invencivel)
        {
            timeInvencivel += Time.deltaTime * 1;
            if (timeInvencivel >= 0.5)
            {
                invencivel = false;
                timeInvencivel = 0;
                Player.color = Color.white;
            }
        }
    }   
    //abre o fecha o invetario
    void inventarioAberto()
    {
        if (invOpen)
        {
            mochila.SetActive(true);
            //Vector3 Seguir = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        } 
        else
        {
            mochila.SetActive(false);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {   //Colissão contra os espinhos no mapa para realizar o dano
        if(col.collider.CompareTag("espinho") || col.collider.CompareTag("inimigo"))
        {
            if (!invencivel)
            {
                vida--;
                rb.AddForce(Vector2.up * 150);
                invencivel = true;
                Player.color = Color.red;
            }            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   //ativa interacao com objetos no mapa
        if (collision.tag.Equals("interacao"))
        {
            inter = true;
            inv.itensInv = collision.gameObject.GetComponent<ItensLista>();
            itensInv = collision.gameObject.GetComponent<ItensLista>();
        } else if (collision.tag.Equals("mBronze"))
        {
            inv.mBronze++;            
        }     
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {   //destativa interação de objetos no mapa
        if (collision.CompareTag("interacao"))
        {
            inter = false;
        }
    }
}
