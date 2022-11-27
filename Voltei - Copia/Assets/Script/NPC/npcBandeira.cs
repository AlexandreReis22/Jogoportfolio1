using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcBandeira : MonoBehaviour
{
    public bool player;
    public PlayerManeger pManeger;
    public GameObject fala;
    public Transform checkPlayer;

    private void Update()
    {
        player = Physics2D.Linecast(transform.position, checkPlayer.transform.position, 1 << LayerMask.NameToLayer("Player"));
        if (player)
        {
            fala.SetActive(true);
        }else
        {
            fala.SetActive(false);
        }
    }


}
