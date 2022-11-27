using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed, time;   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("vel", time, time);
        
    }
    private void Update()
    {             
        transform.Translate(speed * Time.deltaTime,0,0);
    }     
    void vel()
    {
        speed *= -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }  
    }
}
