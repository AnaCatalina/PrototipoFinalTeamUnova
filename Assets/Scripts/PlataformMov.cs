using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMov: MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento del enemigo
    private float frequency = Mathf.PI * 2; // Frecuencia de oscilación
    public float amplitude;  // Amplitud de oscilación
    public float number;
    private float startTime; // Tiempo inicial para calcular el desplazamiento
    private Matrix4x4 transformationMatrix; // Matriz de transformación para el movimiento

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        float Y = frequency * number;
        // Calcular el desplazamiento en el eje X basado en el tiempo
        float displacementY = Mathf.Cos((Time.time - startTime) * Y) * amplitude;

        // Crear la matriz de traslación con el desplazamiento horizontal
        Vector3 translation = new Vector3(0.0f, displacementY, 0.0f);
        transformationMatrix = Matrix4x4.Translate(translation);

        // Aplicar la matriz de transformación al enemigo
        transform.position += transformationMatrix.MultiplyPoint(Vector3.zero) * speed * Time.deltaTime;

        // Si el objeto ha alcanzado la amplitud máxima, invertir la dirección del movimiento
        if (Mathf.Abs(displacementY) >= amplitude)
        {
            frequency *= -1f; // Invertir la frecuencia para cambiar la dirección del movimiento
            startTime = Time.time; // Reiniciar el tiempo inicial para el nuevo ciclo de movimiento
        }
    }
}