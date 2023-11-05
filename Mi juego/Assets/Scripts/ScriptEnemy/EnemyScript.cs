using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{   /*Variable privada se utiliza para rastrear si el objeto puede atacar.*/
    private bool puedeAtacar = true;
    /*Variable privada serializada que representa la velocidad del objeto.*/
    [SerializeField] private float speed;
    /* Variable privada serializada que representa el tiempo de enfriamiento entre ataques.*/
    [SerializeField] private float cooldownAtaque;
    /*Variable privada que se utilizará para acceder al componente SpriteRenderer del objeto.*/
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    /* Este método se llama automáticamente al inicio del juego. En el cual se realiza lo siguiente:
     * Se obtiene una referencia al componente SpriteRenderer adjunto al GameObject.
     * Se inicia una corrutina llamada "CorrutinaMovement".
     * Se establecen los valores iniciales de cooldownAtaque y speed.*/
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("CorrutinaMovement");
        cooldownAtaque = 3f;
        speed = 3f;
    }

    // Update is called once per frame
    /*Este método se llama una vez por fotograma del juego. 
     * En él, el GameObject se desplaza hacia la derecha a una velocidad = speed utilizando transform.Translate.*/
    void Update()
    {
        gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);

    }
    /*Este método se llama cuando el GameObject colisiona con otro objeto en 2D. 
     Se realizan las siguientes comprobaciones:
     * Si el objeto con el que colisiona tiene la etiqueta "PikesMovement," se destruye el GameObject actual.
     * Si el objeto con el que colisiona tiene la etiqueta "Player":
        Se verifica si el objeto puede atacar = puedeAtacar. Si no puede atacar, no se realiza ninguna acción adicional.
        Se cambia la transparencia (alfa) del SpriteRenderer para hacer que el objeto sea transparente
        Se llama al método PerderVida() de la instancia de ScriptGameManager para reducir la vida del jugador.
        Se llama al método AplicarGolpe() en el componente CharacterController del objeto con el que colisiona
     */
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PikesMovement"))
        {
            Destroy(this.gameObject);
        }   
        if (other.gameObject.CompareTag("Player")){

            if (!puedeAtacar) return;
            puedeAtacar = false;
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;
            ScriptGameManager.instance.PerderVida();
            

            other.gameObject.GetComponent<CharacterController>().AplicarGolpe();
        }
    }
    /*Este es un método que devuelve una corrutina:
     *En este método, se invierte la dirección de movimiento speed y luego se espera durante 3 segundos.
     *Luego, se reinicia la misma corrutina y se invoca el método para realizar nuevamente la misma accion.
     */
    IEnumerator CorrutinaMovement()
    {
        this.speed = this.speed * -1;
        yield return new WaitForSeconds(3);

        StartCoroutine("CorrutinaMovement");


        Invoke("reactivarAtaque", cooldownAtaque);
    }
    /* Este método se utiliza para reactivar la capacidad de ataque del objeto. 
     * Restablece la transparencia del SpriteRenderer y establece puedeAtacar en true.*/
    public void reactivarAtaque()
    {
        Color c = spriteRenderer.color;
        c.a = 1f;
        spriteRenderer.color = c;
        puedeAtacar= true;
    }
}


