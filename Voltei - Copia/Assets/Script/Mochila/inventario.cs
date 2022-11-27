using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventario : MonoBehaviour
{
    public List<string> list;
    public Image[] img;
    public ItensLista itensInv;
    public int mBronze, mPrata, mOuro;
    public Text[] textos;
    
    private void Update()
    {                
        if(mBronze == 10)
        {
            mBronze = 0;
            mPrata ++;
        } 
        else if(mPrata == 10)
        {
            mPrata = 0;
            mOuro ++;
        }
        TextMBronze();
        
    }
    void TextMBronze()
    {
        string Bronze = Convert.ToString(mBronze), Prata = Convert.ToString(mPrata), Ouro = Convert.ToString(mOuro);        
        textos[0].text = Bronze;
        textos[1].text = Prata;
        textos[2].text = Ouro;
    }
    public bool TemIten(string NomeItem)
    {
        return list.Contains(NomeItem);
    }
}
