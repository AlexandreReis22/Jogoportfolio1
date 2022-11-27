using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciarQuit : MonoBehaviour
{    
    public void IniciarJogo()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void sairJogo()
    {
        Application.Quit();
    }
}
