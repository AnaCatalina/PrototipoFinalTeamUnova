using UnityEngine;

public class MatrixZ : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento del enemigo
    public float frequency = 1.0f; // Frecuencia de oscilaci�n
    public float amplitude = 2.0f; // Amplitud de oscilaci�n

    private float startTime; // Tiempo inicial para calcular el desplazamiento
    private Matrix4x4 transformationMatrix; // Matriz de transformaci�n para el movimiento

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        // Calcular el desplazamiento en el eje Z basado en el tiempo
        float displacementZ = Mathf.Tan((Time.time - startTime) * frequency) * amplitude;

        // Crear la matriz de traslaci�n con el desplazamiento horizontal
        Vector3 translation = new Vector3(0, 0.0f, displacementZ);
        transformationMatrix = Matrix4x4.Translate(translation);

        // Aplicar la matriz de transformaci�n al enemigo
        transform.position += transformationMatrix.MultiplyPoint(Vector3.zero) * speed * Time.deltaTime;

        // Si el objeto ha alcanzado la amplitud m�xima, invertir la direcci�n del movimiento
        if (Mathf.Abs(displacementZ) >= amplitude)
        {
            frequency *= -1.0f; // Invertir la frecuencia para cambiar la direcci�n del movimiento
            startTime = Time.time; // Reiniciar el tiempo inicial para el nuevo ciclo de movimiento
        }
    }
}