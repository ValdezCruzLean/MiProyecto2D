using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*Este m�todo se llama cuando el GameObject en el que se encuentra este script colisiona con otro objeto que tiene un Collider2D
     *Se verifica si el objeto con el que colision� tiene la etiqueta "Player"
     *Se llama al m�todo GanarVida() de la instancia de ScriptGameManager para intentar aumentar una vida del jugador.
     *Se almacena un valor booleano, vidaRecuperada, que indica si se pudo ganar una vida.
     *Si vidaRecuperada es verdadero se destruye el GameObject actual,que otorga vidas adicionales.*/
    private void OnTriggerEnter2D(Collider2D other1)
    {
        if (other1.gameObject.CompareTag("Player"))
        {
            bool vidaRecuperada = ScriptGameManager.instance.GanarVida();

            if (vidaRecuperada)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
