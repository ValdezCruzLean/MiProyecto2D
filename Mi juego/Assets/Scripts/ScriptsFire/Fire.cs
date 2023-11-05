using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{   /*Variable privada que almacena la posición en el eje Y a la que se eliminará el GameObject. */
    private float posicionEliminarY = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*Este método se llama una vez por fotograma del juego.
     * Se llama al método EliminateFire() para verificar si el GameObject debe ser eliminado.*/
    void Update()
    {
        EliminateFire();

        
    }
    /*Este método se llama cuando el GameObject colisiona con otro objeto en 2D. En este caso, se comprueba los siguiente:
    *Si el objeto con el que colisiona tiene la etiqueta "Player," se llama al método PerderVida() de la instancia de ScriptGameManager 
    para reducir la vida del jugador y se destruye el GameObject actual.
    *Si el objeto con el que colisiona tiene la etiqueta "Mapa," "Pikes" o "Slime," 
    se destruye el GameObject actual en respuesta a la colisión.*/
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            ScriptGameManager.instance.PerderVida();
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Mapa"))
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Pikes"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Slime"))
        {
            Destroy(this.gameObject);
        }
    }
    /* Este método se encarga de verificar si el GameObject debe ser eliminado según su posición en el eje Y.
     Si la posición en el eje Y del GameObject es menor o igual a cero o igual a posicionEliminarY, el GameObject se destruye.*/

    private void EliminateFire ()
    {
        
        if (this.transform.position.y <= posicionEliminarY)
        {
            Destroy(this.gameObject);
        }
    }
}
