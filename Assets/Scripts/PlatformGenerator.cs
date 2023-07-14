using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    private GameObject[,] matriz;

    [SerializeField]
    private GameObject platform1;
    [SerializeField]
    private GameObject platform2;
    [SerializeField]
    private GameObject platform3;
    [SerializeField]
    private GameObject platform4;

    private float timer = 0f; // Se inicializa el temporizador en 0
    [SerializeField]
    private float interval; // Intervalo de tiempo de generado la plataforma

    private void Start()
    {
        matriz = new GameObject[2, 2];
        matriz[0, 0] = platform1;
        matriz[0, 1] = platform2;
        matriz[1, 0] = platform3;
        matriz[1, 1] = platform4;
    }

    private void Update()
    {
        timer += Time.deltaTime; // Se incrementa el temporizador en 1
        if (timer >= interval) // Si el temporizador supera o iguala el intervalo de generado
        {
            GenerateRandomPlatform(); // Se llama al método generar plataforma
            timer = 0f;
        }
    }

    private void GenerateRandomPlatform()
    {
        int randomRow = Random.Range(0, matriz.GetLength(1)); // Genera un número aleatorio entre 0 y 1
        int randomCol = Random.Range(0, matriz.GetLength(1)); // Genera un número aleatorio entre 0 y 1

        GameObject randomPlatform = matriz[randomRow, randomCol]; // Obtiene la plataforma aleatoria de la matriz

        if (randomPlatform != null)
        {
            Instantiate(randomPlatform, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogError("Error: No se encontró la plataforma en la matriz");
        }
    }
}
