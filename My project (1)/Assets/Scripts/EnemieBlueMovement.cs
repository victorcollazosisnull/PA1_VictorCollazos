using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieBlueMovement : MonoBehaviour
{
    [Header("Movimiento Enemigo")]
    public Vector3 puntoA;
    public Vector3 puntoB;
    public Vector3 puntoZ;
    public float speed = 2f;
    private Vector3 direccion;
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
            else
            {
                direccion = puntoB;
            }
            punto = !punto;
        }
    }
}
