using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBoss : MonoBehaviour
{
    public int vida = 3;
    public float time;
    public bool invecivel;
    public SpriteRenderer sprite;
    public GameObject boss;

    private void Update()
    {
        time += 1 * Time.deltaTime;
        if (time > 3)
        {
            sprite.color = Color.white;
            invecivel = false;
            time = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            if (!invecivel)
            {
                vida--;
                invecivel = true;
                sprite.color = Color.red;
            }
        }        
    }
}
