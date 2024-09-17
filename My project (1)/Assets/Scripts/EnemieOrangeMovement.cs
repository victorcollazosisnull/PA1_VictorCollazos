using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieOrangeMovement : MonoBehaviour
{
    [Header("Movimiento Enemigo")]
    public Vector3 puntoA;
    public Vector3 puntoB;
    public Vector3 puntoC;
    public Vector3 puntoD;
    public Vector3 z;
    private Vector3 direccion;
    public float speed = 2f;
    private bool punto = true;
    void Start()
    {
        direccion = puntoB;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, direccion, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, direccion) < 0.1f)
        {
            if (punto)
            {
                direccion = puntoA;
            }
            else if (direccion == puntoA)
            {
                direccion = puntoB;
            }
            else if (direccion == puntoB)
            {
                direccion = puntoC;
            }
            else if (direccion == puntoC)
            {
                direccion = puntoD;
            }
            else if (direccion == puntoD)
            {
                direccion = puntoA;
            }
            punto = !punto;
        }
    }
}
