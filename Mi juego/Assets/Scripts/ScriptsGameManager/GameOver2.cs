using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    /* M�todo p�blico que se utiliza para cambiar de escena en el juego. Cuando se llama a este m�todo, 
     se carga la escena "MainMenu" utilizando SceneManager.LoadScene("MainMenu").
     Esta funci�n se asocia con un bot�n de la interfaz de usuario que permite al jugador regresar al men� principal.*/
    public void EscenaMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    /* Este es otro m�todo p�blico que se utiliza para cambiar de escena en el juego. 
      Cuando se llama a este m�todo, se carga la escena "Level1" utilizando SceneManager.LoadScene("Level2")
      Esta funci�n se asocia con un bot�n de la interfaz de usuario que permite al jugador regresar al men� principal*/
    public void EscenaJuego()
    {
        SceneManager.LoadScene("Level2");
    }
}
