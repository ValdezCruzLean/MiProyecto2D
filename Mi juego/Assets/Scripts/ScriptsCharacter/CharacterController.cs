using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    /*Variable privada serializada que representa la velocidad de movimiento del objeto.*/
    [SerializeField] private float movementSpeed = 1250;
    /*Variable privada serializada que representa la fuerza de un golpe que se aplicar� al objeto.*/
    [SerializeField] private float fuerzaGolpe;
    /*Variable privada se utiliza para rastrear si el objeto puede moverse. */
    private bool puedeMoverse = true ;
    /*Variable privada se utiliza para rastrear la direcci�n hacia la que est� mirando el objeto.*/
    private bool isFacing = false;
    /*Privada que almacena una referencia al componente Rigidbody2D del objeto. */
    private Rigidbody2D rb;
    /*Esta variable privada se utiliza para rastrear si el objeto est� en el suelo*/
    private bool isGrounded;
    // public AudioClip runSound;



    // Start is called before the first frame update
    /*Este m�todo se llama autom�ticamente al inicio del juego. 
     * En �l, se obtiene una referencia al componente Rigidbody2D adjunto al GameObject.*/
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    /*Este m�todo se llama una vez por fotograma del juego. En �l, se realiza lo siguiente:
     *Se verifica si el objeto puede moverse = puedeMoverse. Si no puede moverse, no se realiza ninguna acci�n adicional.
     *Se obtiene la entrada del eje horizontal del jugador utilizando Input.GetAxis("Horizontal"). Esto controla el movimiento del objeto a la izquierda o derecha.
     *Se llama a los m�todos Flip y Move con el valor de movimiento obtenido.
     */
    void Update()
    {
        if (!puedeMoverse) return;
        float movementX = Input.GetAxis("Horizontal");
        Flip(movementX);
        Move(movementX * movementSpeed);

    }
    /*Este m�todo se utiliza para aplicar una velocidad al objeto en el eje horizontal utilizando el componente Rigidbody2D*/
    private void Move(float velocity)
    {
        rb.velocity = new Vector2(velocity * Time.deltaTime, rb.velocity.y);
    }
    /*Este m�todo se utiliza para voltear la direcci�n del objeto en funci�n de su movimiento. 
     * Si el objeto se est� moviendo hacia la izquierda (valor negativo) y estaba mirando hacia la derecha o viceversa,
     * el objeto se voltea y su escala en el eje X se invierte.*/
    private void Flip(float movementX)
    {

        if ((isFacing == true && movementX < 0) || (isFacing == false && movementX > 0))
        {
            isFacing = !isFacing;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            //AudioManager.Instance.ReproducirSonido(runSound);

        }
    }
    /*Este m�todo se llama para aplicar un golpe al objeto.
     * Desactiva la capacidad de movimiento (puedeMoverse), calcula una direcci�n para el golpe bas�ndose en la velocidad actual del objeto y
      aplica una fuerza en esa direcci�n utilizando el componente Rigidbody2D. 
     *Luego, inicia una corrutina para reactivar el movimiento despu�s de un corto per�odo de tiempo.*/
    public void AplicarGolpe()
    {
        puedeMoverse = false;
        Vector2 direccionGolpe;
        if (rb.velocity.x < 0)
        {
            direccionGolpe = new Vector2(-1, 1);
        }
        else
        {
            direccionGolpe = new Vector2(1, 1);

        }
        rb.AddForce(direccionGolpe * fuerzaGolpe);
        StartCoroutine(EsperarYActivasMovimiento());
    }
    /* Este m�todo se llama cuando el objeto colisiona con otro objeto en 2D.
     * En este caso, se establece la variable isGrounded en true para indicar que el objeto est� en el suelo.*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
    /* Este m�todo se llama cuando el objeto deja de colisionar con otro objeto en 2D. 
     * En este caso, se establece la variable isGrounded en false para indicar que el objeto ya no est� en el suelo.*/
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    /* Este es un m�todo que devuelve una corrutina. 
     * En este m�todo, se espera durante 0.1 segundos y luego verifica continuamente si el objeto est� en el suelo (isGrounded).
     * Cuando el objeto toca el suelo, se reactiva la capacidad de movimiento (puedeMoverse).*/
    IEnumerator EsperarYActivasMovimiento()
    {
        yield return new WaitForSeconds(0.1f);
        while (!isGrounded)
        {
            yield return null;
        }
        puedeMoverse = true;
    }
}
