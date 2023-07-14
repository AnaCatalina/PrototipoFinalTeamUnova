using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxMoveSpeed = 10f; // Velocidad máxima del movimiento
    [SerializeField] private float acceleration = 5f; // Aceleración del movimiento
    [SerializeField] private float jumpForce = 10f; // Fuerza de salto (empleado como magnitud de un vector)
    [SerializeField] private float gravityForce = 9.81f; // Fuerza de gravedad (empleado como magnitud de otro vector)

    private Rigidbody rb;
    private bool isGrounded = true;

    private float currentMoveSpeed = 0f; // Velocidad actual del movimiento

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calcula la DIRECCION de movimiento en el plano X y Z
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        // Calcula la VELOCIDAD de movimiento utilizando la función lineal
        currentMoveSpeed = Mathf.Lerp(currentMoveSpeed, moveDirection.magnitude * maxMoveSpeed, Time.deltaTime * acceleration);

        // Calcula la FUERZA de movimiento en el plano X y Z
        Vector3 moveForce = moveDirection * currentMoveSpeed;

        // Aplica la fuerza de movimiento
        rb.velocity = new Vector3(moveForce.x, rb.velocity.y, moveForce.z);

        // Aplica la fuerza de salto si el jugador está en el suelo y presiona la Barra Espaciadora
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Aplica una fuerza Rigidbody del objeto, utilizando el vector Vector3.up (hacia arriba) multiplicado por el valor jumpForce que repesenta la magnitud del vector, con una aplicación de fuerza instantánea (Impulse). Esto simulará un salto del objeto en el eje Y.
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        // Aplica la fuerza de gravedad constante
        rb.AddForce(Vector3.down * gravityForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el jugador ha tocado el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}