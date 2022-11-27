using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlataformaInvisivel : MonoBehaviour
{
    public Animator anim;
    public Transform point11, point2;
    private Rigidbody2D rb;
    public float speed, time;
    public bool checkPlayer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("vel", time, time);
    }
    private void Update()
    {
        checkPlayer = Physics2D.Linecast(point11.transform.position, point2.transform.position, 1 << LayerMask.NameToLayer("Player"));
        transform.Translate(speed * Time.deltaTime,0,0);
        anim.SetBool("checkPlayer", checkPlayer);
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
