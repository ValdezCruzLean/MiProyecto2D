using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{ /* Variable privada llamada animator del tipo Animator.Se utiliza para acceder 
   al componente Animator adjunto al GameObject en el que se encuentra este script.*/
    private Animator animator;

    // Start is called before the first frame update
    /*M�todo que se llama autom�ticamente al comienzo del juego. En este m�todo, 
     se le asigna el componente Animator del GameObject actual al campo animator.*/
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    /*M�todo que se llama una vez por cada fotograma del juego. */
    /* Si el jugador est� presionando alguna tecla de movimiento (eje horizontal no es igual a cero), 
     se establece un par�metro de animaci�n llamado "isRunning" en el componente Animator como true. 
     Si no se est� presionando ninguna tecla de movimiento, se establece "isRunning" en false.*/
    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {

            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }


    }
    /*Este m�todo se llama cuando el GameObject entra en colisi�n con otro objeto en 2D.*/
    /*Se establece el par�metro de animaci�n "isJumping" en false cuando el personaje colisiona con otro objeto.
     Esto indica que el personaje no est� saltando en ese momento.*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("isJumping", false);
    }
    /*Este m�todo se llama cuando el GameObject sale de la colisi�n con otro objeto en 2D*/
    /*En este caso, se establece el par�metro de animaci�n "isJumping" en true cuando el personaje sale de una colisi�n. 
     Esto indica que el personaje est� en el aire despu�s de saltar.*/
    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("isJumping", true);
    }
}
