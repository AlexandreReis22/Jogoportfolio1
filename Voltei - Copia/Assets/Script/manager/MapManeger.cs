using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManeger : MonoBehaviour
{
    public PlayerManeger pManeger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            pManeger.vida = 0;
        }
    }
}
