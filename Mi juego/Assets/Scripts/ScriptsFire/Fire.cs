using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{   /*Variable privada que almacena la posici�n en el eje Y a la que se eliminar� el GameObject. */
    private float posicionEliminarY = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*Este m�todo se llama una vez por fotograma del juego.
     * Se llama al m�todo EliminateFire() para verificar si el GameObject debe ser eliminado.*/
    void Update()
    {
        EliminateFire();

        
    }
    /*Este m�todo se llama cuando el GameObject colisiona con otro objeto en 2D. En este caso, se comprueba los siguiente:
    *Si el objeto con el que colisiona tiene la etiqueta "Player," se llama al m�todo PerderVida() de la instancia de ScriptGameManager 
    para reducir la vida del jugador y se destruye el GameObject actual.
    *Si el objeto con el que colisiona tiene la etiqueta "Mapa," "Pikes" o "Slime," 
    se destruye el GameObject actual en respuesta a la colisi�n.*/
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
    /* Este m�todo se encarga de verificar si el GameObject debe ser eliminado seg�n su posici�n en el eje Y.
     Si la posici�n en el eje Y del GameObject es menor o igual a cero o igual a posicionEliminarY, el GameObject se destruye.*/

    private void EliminateFire ()
    {
        
        if (this.transform.position.y <= posicionEliminarY)
        {
            Destroy(this.gameObject);
        }
    }
}
