using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pikes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*Este método se llama cuando el GameObject al que está adjunto el script colisiona con otro objeto en 2D.
     Si el objeto con el que colisiona tiene la etiqueta "Player," se realizan las siguientes acciones:
    *Se llama al método PerderVida() de la instancia de ScriptGameManager.Cuando el objeto colisiona con el jugador, se reduce la vida del jugador en el juego.
    *Se llama al método AplicarGolpe() en el componente CharacterController del objeto con el que colisiona (other.gameObject). .
    */
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            ScriptGameManager.instance.PerderVida();


          other.gameObject.GetComponent<CharacterController>().AplicarGolpe();
        }
    }
}
