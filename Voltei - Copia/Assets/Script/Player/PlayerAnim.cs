using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void setSpeedY(float speed)
    {
        anim.SetFloat("SpeedY", speed);
    }
    public void setCheckChao(bool checkchao)
    {
        anim.SetBool("CheckChao", checkchao);
    }
    public void setMoviment(float h)
    {
        anim.SetBool("walk", h != 0);
    }
}
