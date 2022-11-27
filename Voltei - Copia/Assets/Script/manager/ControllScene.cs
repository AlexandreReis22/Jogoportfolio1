using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllScene : MonoBehaviour
{
    public PlayerManeger pManeger;
    public inventario inv;
    public GameObject Menu;
    public string[] chaves;
    public int vida;
    public bool passar;
    public VidaBoss vidaBoss;

    void Update()
    {
        vida = vidaBoss.vida;
        PlayerMorte();
        if (chaves[0].Equals(inv.list[0]) && chaves.Length == 1)
        {            
            SceneManager.LoadScene("fase2");            
        }
        if (chaves[1].Equals(inv.list[1]) && chaves[2].Equals(inv.list[2]) && chaves.Length == 3 && !passar)
        {
            SceneManager.LoadScene("fase3");
            passar = true;
        } 
        else if (chaves.Length == 3 && inv.list[1] != chaves[1] && inv.list[2] != chaves[2])
        {
            RecarregarCena();
        }
        if(vida == 0)
        {
            SceneManager.LoadScene("fase4");
        }
    }
    public void RecarregarCena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
        Menu.SetActive(false);        
    }
    void PlayerMorte()
    {
        if (pManeger.vida == 0)
        {
            Time.timeScale = 0;
            Menu.SetActive(true);
            pManeger.invOpen = false;
        }
        else
        {
            Time.timeScale = 1;
        }
    }    
}
