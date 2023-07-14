using UnityEngine;

public class CubosFuncionLineal : MonoBehaviour
{
    [SerializeField]
    private float velocidad = 5f;
    private float m = 1f; //pendiente
    private float c = 1f; //termino independiente
    [SerializeField]
    private float extremoLadoDerecho;
    [SerializeField]
    private float extremoLadoIzquierdo;
    [SerializeField]
    private bool banderaA = true;
    [SerializeField]
    private bool banderaB = false;
    private void Update()
    {
        if ((transform.position.x > extremoLadoDerecho) && (banderaA))
        {
            m *= -1;
            banderaA = false;
            banderaB = true;
        }
        if ((transform.position.x < extremoLadoIzquierdo) && (banderaB))
        {
            m *= -1;
            banderaB = false;
            banderaA = true;
        }

        // Se calcula el desplazamiento en el eje X en función del tiempo        
        float elapsedtime = Time.time;
        float speedX = m * elapsedtime + c;

        // Definimos la dirección y la normalizamos segun el eje donde se va a mover
        Vector3 direccion = new Vector3(speedX, 0f, 0f).normalized;

        // Movemos el objeto en la dirección y velocidad deseada
        transform.position += direccion * velocidad * Time.deltaTime;
    }
}
