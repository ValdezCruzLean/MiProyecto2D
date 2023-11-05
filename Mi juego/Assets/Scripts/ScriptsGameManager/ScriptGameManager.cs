using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScriptGameManager : MonoBehaviour
{ /*Variable pública llamada hud del tipo HUD. Este objeto se utiliza para gestionar la interfaz de usuario en el juego.*/
    public HUD hud;
    /*Esto declara una propiedad estática llamada instance que permite acceder a una instancia única de la clase ScriptGameManager. 
     * El acceso a la instancia es a través de ScriptGameManager.instance.*/
    public static ScriptGameManager instance { get; private set; }
    /*Esto declara una propiedad pública llamada PuntosTotales que proporciona acceso a la variable privada puntosTotales. 
     * Esto permite a otras clases obtener el valor de puntos totales sin modificarlo directamente.*/
    public int PuntosTotales { get {  return puntosTotales; } }
    /*Esta variable privada almacena la cantidad total de puntos en el juego.*/
    private int puntosTotales;
    /*Esta variable privada almacena la cantidad de vidas iniciales del jugador, estableciendo el valor en 3.*/
    private int vidas = 3;
    /*Esto declara una variable pública para almacenar un clip de sonido que se reproducirá cuando el jugador reciba daño.*/
    public AudioClip damageReceived;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*Este método se llama al comienzo de la ejecución del juego, antes del método Start. 
     * Se comprueba si ya existe una instancia de ScriptGameManager y, en caso contrario, se establece esta instancia como la actual. 
     * Esto garantiza que solo haya una instancia de ScriptGameManager en la escena.*/
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Mas de un GameManager en escena");
        }
    }
    /*Este método se utiliza para agregar puntos al puntaje total del jugador. Se suma la cantidad puntosASumar a puntosTotales,
     se actualiza la interfaz de usuario a través de hud, y se verifica si el jugador ha alcanzado ciertos puntos en escenas específicas
     para cargar niveles posteriores.*/
    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        Debug.Log(puntosTotales);
        hud.ActualizarPuntos(puntosTotales);
        if(SceneManager.GetActiveScene().name == "Level1" && puntosTotales >= 10)
        {
            SceneManager.LoadScene("Level2");
        }

        if (SceneManager.GetActiveScene().name == "Level2" && puntosTotales >= 7)
        {
            SceneManager.LoadScene("YouWin");
        }

    }
    /*Este método se utiliza para restar una vida al jugador, reproducir un sonido de daño y verificar si el jugador se queda sin vidas 
     en una escena específica para cargar una pantalla de "Game Over".*/
    public void PerderVida()
    {
        AudioManager.Instance.ReproducirSonido(damageReceived);
        vidas -= 1;
        if ( SceneManager.GetActiveScene().name == "Level1" && vidas == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (SceneManager.GetActiveScene().name == "Level2" && vidas == 0)
        {
            SceneManager.LoadScene("GameOver2");
        }
        hud.DesactivarVida(vidas);
        
    }
    /* Este método se utiliza para aumentar el contador de vidas del jugador, siempre y cuando no haya alcanzado el máximo de 3 vidas.
     * También actualiza la interfaz de usuario y devuelve un valor booleano para indicar si se pudo ganar una vida.*/
    public bool GanarVida()
    {
        if(vidas == 3)
        {
            return false;
        }
        hud.ActivarVida(vidas);
        vidas += 1;
        return true;
    }
}
