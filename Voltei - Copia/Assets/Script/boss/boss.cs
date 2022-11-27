using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public Rigidbody2D rb;
    public float vel, forceJump;
    public int moveSet;
    public bool fMoveSet, chao, flip;
    public Transform Trans, checkChao;
    public GameObject fMove1, fMove2;
    public int fMoveS;    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        fMoveSet = Physics2D.Linecast(transform.position, Trans.transform.position, 1 << LayerMask.NameToLayer("plat"));
        chao = Physics2D.Linecast(transform.position, checkChao.transform.position, 1 << LayerMask.NameToLayer("chao"));
                
        if(moveSet == 0 && chao)
        {
            moveSet = Random.Range(1, 100);
        }

        if (fMoveS == 1)
        {
            fMove1.SetActive(true);
            fMove2.SetActive(false);
        } 
        else if(fMoveS == -1)
        {
            fMove1.SetActive(false);
            fMove2.SetActive(true);
        }        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(vel * Time.deltaTime, rb.velocity.y);
        if(fMoveSet && moveSet >= 30)//moveSet > 25 &&  moveSet < 80)
        {
            Jump();
        }        
    }
    public void flipar()
    {      
        vel *= -1;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        fMoveS *= -1;
        moveSet = 0;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("flip"))
        {
            flipar();
        }
    }

    public void Jump()
    {  
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
        moveSet = 0;
       
    }
}
