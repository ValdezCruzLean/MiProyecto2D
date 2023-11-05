using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PikesMovementY : MonoBehaviour
{ /*Esto declara una variable privada que almacena la posición en el eje Y a la que se eliminará el GameObject. 
   Si la posición en el eje Y del GameObject supera este valor, se destruirá.*/
    private float posicionEliminarY = 25;
    /*Esto declara una variable privada que representa la velocidad de desplazamiento del GameObject.*/
    private float velocidad = 1.65f;
    /*Esto declara una variable privada que representa la dirección de movimiento del GameObject. 
     * Lo que significa que el GameObject se mueve hacia abajo por defecto.*/
    private Vector3 direccion = Vector3.down; 
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per framea
    /*Este método se llama una vez por fotograma del juego. En él, se realiza lo siguiente:
   * Si la escena es "Level2" y la posición en el eje Y del GameObject es mayor o igual a posicionEliminarY, se destruye el GameObject actual.
   * Luego, se calcula un desplazamiento basado en la dirección y la velocidad, y se aplica ese desplazamiento al GameObject utilizando transform.Translate.*/
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            if (this.transform.position.y >= posicionEliminarY)
            {
                Destroy(this.gameObject);
            }
        }
        // Calcula el desplazamiento basado en la direcci0n y la velocidad
        Vector3 desplazamiento = direccion * velocidad * Time.deltaTime;

        // Aplica el desplazamiento al objeto usando Transform.Translate
        transform.Translate(desplazamiento);
    }
    /*Este método se llama cuando el GameObject colisiona con otro objeto en 2D.
     * Se verifica si el objeto con el que colisiona tiene la etiqueta "Player". Si es así:
     * Se llama al método PerderVida() de la instancia de ScriptGameManager.
     * Se llama al método AplicarGolpe() en el componente CharacterController del objeto con el que colisiona (other.gameObject).*/
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) { 
        
            ScriptGameManager.instance.PerderVida();


            other.gameObject.GetComponent<CharacterController>().AplicarGolpe();
        }
    }
}