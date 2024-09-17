using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Salud:")]
    public int maxVida = 10;
    public int vidaActual;
    private Rigidbody _rigidbody;
    [Header("Movimiento:")]
    public float speed;
    private Vector3 movementInput;
    [Header("Salto:")]
    private bool isJumping = false;
    public float jumpForce;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        vidaActual = maxVida;
    }
    public void Damage(int cantidad)
    {
        vidaActual = vidaActual - cantidad;
        if (vidaActual <= 0)
        {
            vidaActual = 0;
            Destroy(this.gameObject);
        }
    }

    public void ReadDirection(InputAction.CallbackContext context)
    {
      movementInput = context.ReadValue<Vector2>();
    }
    public void ReadJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isJumping = true;
        }
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y) * speed;
        movement.y = _rigidbody.velocity.y;

        _rigidbody.velocity = movement;

        if (isJumping)
        {
                _rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
        isJumping = false;
    }
    private void OnCollisionEnter(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemigo"))
        {
            Damage(1);
        }
    }
}

