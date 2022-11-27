using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class final : MonoBehaviour
{    
   public void sair()
   {
        Application.Quit();
   }

   public void recomecar()
    {
        SceneManager.LoadScene("Menu");
    } 
}
