using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    /*Esta es una propiedad p�blica y est�tica que se utiliza para acceder a una instancia �nica de la clase AudioManager*/
    public static AudioManager Instance {  get; private set; }
    /*Esto declara una variable privada que almacena una referencia al componente AudioSource*/
    private AudioSource audioSource;


    /*- Este m�todo se llama autom�ticamente al inicio del juego, antes de que se ejecute cualquier m�todo Start
     
     *Se verifica si la propiedad Instance es null. Si es null, significa que no hay una instancia de AudioManager creada previamente.
     *Si no existe una instancia previa, se establece la instancia actual en this, ser� la �nica instancia de AudioManager disponible en el juego.
     *Si ya existe una instancia de AudioManager, se muestra un mensaje de advertencia en la consola indicando que hay m�s de un objeto AudioManager.
     */
    private void Awake()
    {
        if (Instance == null) { 
        Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas hay de un AudioManager en escena");
        }
    }
    // Start is called before the first frame update
    /*Este m�todo se llama autom�ticamente al inicio del juego, despu�s de Awake. 
     * Se obtiene una referencia al componente AudioSource adjunto al GameObject que contiene este script.*/
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*Este es un m�todo p�blico que se utiliza para reproducir un clip de sonido espec�fico. Recibe como argumento un objeto AudioClip que representa el sonido que se debe reproducir.
     Se utiliza el AudioSource para reproducir el sonido utilizando PlayOneShot, el sonido se reproduce una sola vez sin interrupciones de otros sonidos en el AudioSource.*/
    public void ReproducirSonido(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
