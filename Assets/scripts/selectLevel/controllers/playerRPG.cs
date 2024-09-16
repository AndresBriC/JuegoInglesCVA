using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRPG : MonoBehaviour
{
    public float moveSpeed = 10f;  // Incrementa la velocidad de movimiento del jugador
    private Rigidbody2D rb;
    private Animator animator;

    private bool isGrounded = true; // El personaje siempre estará "en el suelo" en este contexto
    private bool moving = false;    // Variable para controlar si el jugador se está moviendo
    private bool facingRight = true; // Para controlar la dirección hacia la que mira el personaje

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();       // Asigna el Rigidbody2D del jugador
        animator = GetComponent<Animator>();    // Asigna el Animator del jugador
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // Movimiento en el eje X (izquierda/derecha)
        float moveY = Input.GetAxisRaw("Vertical");   // Movimiento en el eje Y (arriba/abajo)

        // Controla el movimiento del jugador usando Rigidbody2D para evitar problemas de colisión
        Vector2 movement = new Vector2(moveX, moveY).normalized;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        // Verifica si el jugador se está moviendo
        moving = movement != Vector2.zero;

        // Actualiza los parámetros del Animator
        animator.SetBool("moving", moving);
        animator.SetBool("isGrounded", isGrounded);

        // Cambia la dirección del sprite cuando se mueve a la izquierda o derecha
        if (moveX > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveX < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;  // Invierte la escala en el eje X para voltear el sprite
        transform.localScale = theScale;
    }
}