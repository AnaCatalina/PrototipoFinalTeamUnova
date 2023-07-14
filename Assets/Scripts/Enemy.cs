using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float distance;
    [SerializeField]
    private float speedMultiplier;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private string status;
    [SerializeField]
    private float detectionRadius;
    [SerializeField]
    private float attackRadius;
    Renderer rend;
    private int m=1; //pendiente
    private int c=0; //termino independiente
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 direction = new Vector3(3f, 0f, 4f);
        Vector3 normalizedDirection = direction.normalized;
        rend = GetComponent<Renderer>();
        detectionRadius = 20;
        attackRadius = 18;
        status = "normal";
        rotationSpeed = 10;
        speedMultiplier = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        // D = (A^2 + B^2 + C^2)^(1/2) 
        distance =      //Para calcular la distancia D
            Mathf.Sqrt(         //Sacamos la raíz cuadrada de 
            (Mathf.Pow((player.transform.position.x - transform.position.x),2 )) + //A^2 = (Pxf - Pxi)^2 //Punto final X menos punto inicial X
            (Mathf.Pow((player.transform.position.y - transform.position.y),2 )) + //B^2 = (Pyf - Pyi)^2 //Punto final Y menos punto inicial Y
            (Mathf.Pow((player.transform.position.z - transform.position.z),2 ))   //C^2 = (Pzf - Pzi)^2 //Punto final Z menos punto inicial Z
        );
        //distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance > detectionRadius)
        {
            status = "normal";
        }
        if (distance < detectionRadius && distance > attackRadius)
        {
            status = "alert";

        }
        if (distance < attackRadius)
        {
            status = "attack";
        }
        switch (status)
        {
            case "normal":
                rend.material.color = Color.cyan;
                //print(status);
                break;
            case "alert":
                rend.material.color = Color.yellow;
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), rotationSpeed * Time.deltaTime);

                //Obtenemos el vector dirección normalizada hacia el objetivo
                direction = (player.transform.position - transform.position).normalized; ;
                //Giramos segun la dirección obtenida, en este caso decidimos omitir el eje Y y se escrito en forma de V3(f,f,f)                
                //transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)), rotationSpeed * Time.deltaTime);
                break;
            case "attack":
                rend.material.color = Color.red;

                //Obtenemos el vector dirección normalizada hacia el objetivo
                direction = (player.transform.position - transform.position).normalized; ;
                //Giramos segun la dirección obtenida, en este caso decidimos omitir el eje Y y se escrito en forma de V3(f,f,f)                
                //transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)), rotationSpeed * Time.deltaTime);

                //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

                //Usando la función lineal calculamos la velocidad 
                float speed = m * speedMultiplier + c;
                //Se movera al enemigo en la direccion asignada a la velocidad asignada
                transform.position += direction * speed * Time.deltaTime;
                //print(status);
                break;
        }
    }
}
