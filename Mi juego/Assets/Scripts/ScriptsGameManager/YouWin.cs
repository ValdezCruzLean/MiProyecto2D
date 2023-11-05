using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class YouWin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /* Método público que se utiliza para cambiar de escena en el juego. Cuando se llama a este método, 
     se carga la escena "MainMenu" utilizando SceneManager.LoadScene("MainMenu").
     Esta función se asocia con un botón de la interfaz de usuario que permite al jugador regresar al menú principal.*/
    public void EscenaMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
