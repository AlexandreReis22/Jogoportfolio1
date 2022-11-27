using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MochilaSeguir : MonoBehaviour
{    
    public float dir;
    public GameObject player;
    
    void Update()
    {        
        transform.position = new Vector3 (player.transform.position.x - dir, player.transform.position.y, player.transform.position.z);
    }
}
