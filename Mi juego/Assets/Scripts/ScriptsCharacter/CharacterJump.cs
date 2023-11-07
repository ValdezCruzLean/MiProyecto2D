using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{   /*Variable que representa la fuerza del salto.*/
    //fuerrza de salto sin deltatime es en level1= 11.7 y en level2 11.7
  /* [SerializeField]*/ private float jumpForce = 11.7f;
    /*Variable privada llamada isGrounded, que se utiliza para rastrear si el personaje est� en el suelo o no.*/
    private bool isGrounded;
    /*Variable privada llamada rb del tipo Rigidbody2D, que se utilizar� para acceder al componente Rigidbody2D del GameObject.*/
    private Rigidbody2D rb;
    /*Variable p�blica para almacenar un clip de sonido que se reproducir� cuando el personaje salte.*/
    public AudioClip jumpSound;
    // public int saltosMaximos = 1;
    //private int saltosRestantes;



    // Start is called before the first frame update
    /* Este m�todo se llama autom�ticamente al inicio del juego.
     * Se obtiene una referencia al componente Rigidbody2D del GameObject actual y se asigna a la variable rb.*/
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // saltosRestantes = saltosMaximos;

    }

    // Update is called once per frame
    /* Este m�todo se llama una vez por fotograma del juego. 
     Aqu� se comprueba si el personaje est� en el suelo (isGrounded) y si se presiona el bot�n "Jump" */
    /*Si ambas condiciones son verdaderas, se reproduce un sonido, y 
     luego se llama al m�todo Jump() para aplicar una fuerza de salto al personaje.*/
    void Update()
    {
       if(isGrounded && Input.GetButton("Jump"))
        {
            AudioManager.Instance.ReproducirSonido(jumpSound);
            Jump();
        }

    }
    /*Este m�todo se encarga de aplicar la fuerza de salto al componente Rigidbody2D del personaje.*/
    private void Jump()
    {
        //Desde un comienzo utilizaba el deltatime pero despues de la consulta realizada quite el mismo
        rb.velocity = new Vector2(rb.velocity.x, jumpForce /** Time.deltaTime*/ );

    }
    /* Este m�todo se llama cuando el GameObject entra en colisi�n con otro objeto en 2D. 
     Si el objeto con el que colisiona tiene la etiqueta "Mapa," 
    se establece isGrounded en true, lo que indica que el personaje est� en el suelo.*/
    private void OnCollisionEnter2D(Collision2D otherTag)
    {
        if (otherTag.gameObject.CompareTag("Mapa"))
        {
            isGrounded = true;
        }
    }
    /*Este m�todo se llama cuando el GameObject sale de la colisi�n con otro objeto en 2D. 
     Si el objeto con el que ya no est� en colisi�n tiene la etiqueta "Mapa," se establece isGrounded en false, 
     lo que indica que el personaje ya no est� en el suelo.*/
    private void OnCollisionExit2D(Collision2D otherTag)
    {
        if (otherTag.gameObject.CompareTag("Mapa"))
        {
            isGrounded = false;
        }
    }



}
