using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviorGenerated : MonoBehaviour
{
    [SerializeField]
    private float speedX; // Velocidad a la que se moverá la plataforma (en este caso en el eje X)
    [SerializeField]
    private float destroyDelay = 5f; // Tiempo antes de destruir la plataforma
    private float destroyTimer; // Temporizador para controlar el tiempo transcurrido

    void Start()
    {
        destroyTimer = 0f; // Se inicializa el temporizador en 0
    }

    void Update()
    {
        transform.Translate(speedX * Time.deltaTime, 0, 0); // La plataforma se moverá en el eje X
        destroyTimer += Time.deltaTime; // Se incrementa el temporizador en 1
        DestroyPlatformAfterDelay();
    }

    private void DestroyPlatformAfterDelay()
    {
        if (destroyTimer >= destroyDelay) // Cuando el temporizador alcanza o supera el valor de destroyDelay
        {
            Destroy(gameObject); // Se destruye la plataforma
        }
    }
}
