using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*Método público que se utiliza para cambiar de escena en el juego.
     *Cuando se llama a este método, se carga la escena "Level1" utilizando SceneManager.LoadScene("Level1").*/
    public void EscenaJuego()
    {
        SceneManager.LoadScene("Level1");
    }
}
