using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform ObjSeguir;
    public float speed;
    public Vector3 vel;

    private void FixedUpdate()
    {       
        transform.position = Vector3.SmoothDamp(transform.position, ObjSeguir.position, ref vel, speed);
    }
}
