using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{ /* Variable privada llamada animator del tipo Animator.Se utiliza para acceder 
   al componente Animator adjunto al GameObject en el que se encuentra este script.*/
    private Animator animator;

    // Start is called before the first frame update
    /*Método que se llama automáticamente al comienzo del juego. En este método, 
     se le asigna el componente Animator del GameObject actual al campo animator.*/
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    /*Método que se llama una vez por cada fotograma del juego. */
    /* Si el jugador está presionando alguna tecla de movimiento (eje horizontal no es igual a cero), 
     se establece un parámetro de animación llamado "isRunning" en el componente Animator como true. 
     Si no se está presionando ninguna tecla de movimiento, se establece "isRunning" en false.*/
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
    /*Este método se llama cuando el GameObject entra en colisión con otro objeto en 2D.*/
    /*Se establece el parámetro de animación "isJumping" en false cuando el personaje colisiona con otro objeto.
     Esto indica que el personaje no está saltando en ese momento.*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("isJumping", false);
    }
    /*Este método se llama cuando el GameObject sale de la colisión con otro objeto en 2D*/
    /*En este caso, se establece el parámetro de animación "isJumping" en true cuando el personaje sale de una colisión. 
     Esto indica que el personaje está en el aire después de saltar.*/
    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("isJumping", true);
    }
}
