using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PikesMovementY : MonoBehaviour
{ /*Esto declara una variable privada que almacena la posici�n en el eje Y a la que se eliminar� el GameObject. 
   Si la posici�n en el eje Y del GameObject supera este valor, se destruir�.*/
    private float posicionEliminarY = 25;
    /*Esto declara una variable privada que representa la velocidad de desplazamiento del GameObject.*/
    private float velocidad = 1.65f;
    /*Esto declara una variable privada que representa la direcci�n de movimiento del GameObject. 
     * Lo que significa que el GameObject se mueve hacia abajo por defecto.*/
    private Vector3 direccion = Vector3.down; 
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per framea
    /*Este m�todo se llama una vez por fotograma del juego. En �l, se realiza lo siguiente:
   * Si la escena es "Level2" y la posici�n en el eje Y del GameObject es mayor o igual a posicionEliminarY, se destruye el GameObject actual.
   * Luego, se calcula un desplazamiento basado en la direcci�n y la velocidad, y se aplica ese desplazamiento al GameObject utilizando transform.Translate.*/
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
    /*Este m�todo se llama cuando el GameObject colisiona con otro objeto en 2D.
     * Se verifica si el objeto con el que colisiona tiene la etiqueta "Player". Si es as�:
     * Se llama al m�todo PerderVida() de la instancia de ScriptGameManager.
     * Se llama al m�todo AplicarGolpe() en el componente CharacterController del objeto con el que colisiona (other.gameObject).*/
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) { 
        
            ScriptGameManager.instance.PerderVida();


            other.gameObject.GetComponent<CharacterController>().AplicarGolpe();
        }
    }
}