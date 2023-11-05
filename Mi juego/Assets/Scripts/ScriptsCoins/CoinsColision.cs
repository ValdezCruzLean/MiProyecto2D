using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsColision : MonoBehaviour
{   /*Variable privada que almacena un valor num�rico. */
    private int valor = 1;
    /*Variable p�blica que representa un clip de sonido que se reproducir� cuando el jugador interact�e con este objeto y lo recoja.*/
    public AudioClip clipRecolectar;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*Este m�todo se llama cuando el GameObject al que est� adjunto el script colisiona con otro objeto que tiene un Collider2D
     *Dentro de este m�todo, se verifica si el objeto con el que colisiona tiene la etiqueta "Player" .
     *Si el objeto con el que colisiona es el jugador, se realizan las siguientes acciones:
     Se llama al m�todo SumarPuntos(valor) de la instancia de ScriptGameManager para sumar puntos al puntaje del jugador.
     Se destruye el GameObject actual (this.gameObject). El objeto recolectable desaparece despu�s de que el jugador lo recoge.
     Se reproduce un clip de sonido almacenado en clipRecolectar utilizando el sistema de sonido del juego 
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScriptGameManager.instance.SumarPuntos(valor);
            Destroy(this.gameObject);
            AudioManager.Instance.ReproducirSonido(clipRecolectar);
        }
    }
}
