using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPlayer : MonoBehaviour
{
    [SerializeField]
    private float posX;
    [SerializeField]
    private float posY;
    [SerializeField]
    private float posZ;
    [SerializeField]
    private float angulo;

    private void Start()
    {
        posX = 0f;
        posY = 2f;
        posZ = -21.4f;
        angulo = 0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = new Vector3(posX, posY, posZ); // Devuelve al personaje al principio
            other.transform.localRotation = Quaternion.Euler(0, angulo, 0);
        }
    }
}
