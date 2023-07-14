using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMov: MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento del enemigo en este caso la plataforma
    private float frequency = Mathf.PI * 2; // Frecuencia de oscilación multiplicada por 2 que se usa mas adelante, con esto definimos el rango de la curva que vamos a usar
    public float amplitude;  // Amplitud de oscilación de la plataforma
    public float number; // Valor que asignamos para aumentar la frecuencia
    private float startTime; // Tiempo inicial para calcular el desplazamiento
    private Matrix4x4 transformationMatrix; // Matriz de transformación para el movimiento

    private void Start()
    {
        startTime = Time.time; // se inicializa el tiempo y se establece el valor "StartTime" con el tiempo actual
    }

    private void Update()
    {
        float Y = frequency * number; // multiplicamos la frecuencia por un valor para poder darle el movimiento a la plataforma
        // Calcular el desplazamiento en el eje Y basado en el tiempo
        float displacementY = Mathf.Cos((Time.time - startTime) * Y) * amplitude;

        // Crear la matriz de traslación con el desplazamiento vertical 
        Vector3 translation = new Vector3(0.0f, displacementY, 0.0f); // crea el vector de traslacion en el eje Y 
        transformationMatrix = Matrix4x4.Translate(translation); // crea la matriz de transformacion utilizado en el vector de traslacion

        // Aplicar la matriz de transformación al enemigo
        transform.position += transformationMatrix.MultiplyPoint(Vector3.zero) * speed * Time.deltaTime; // se aplica la matriz de transformacion al punto de origen, esto produce un nuevo vector que representa la transformacion aplicada al punto de origen

        // Si el objeto ha alcanzado la amplitud máxima, invertir la dirección del movimiento
        if (Mathf.Abs(displacementY) >= amplitude)
        {
            frequency *= -1f; // Invertir la frecuencia para cambiar la dirección del movimiento
           
        }
    }
}