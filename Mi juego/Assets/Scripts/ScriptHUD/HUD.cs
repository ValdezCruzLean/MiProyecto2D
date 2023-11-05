using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{ /*Esto declara un array p�blico de GameObject llamado vidas 
   almacena una serie de objetos que representan las vidas del personaje�*/
    public GameObject[] vidas;
    /*Esto declara una variable p�blica de tipo TextMeshProUGUI llamada puntos. 
     * Se utiliza para mostrar informaci�n textual en la interfaz de usuario del juego.*/
    public TextMeshProUGUI puntos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() { 
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            puntos.text = "Monedas: " + ScriptGameManager.instance.PuntosTotales.ToString() + "/10";
        }
       if (SceneManager.GetActiveScene().name == "Level2")
      {
            puntos.text = "Almas: " + ScriptGameManager.instance.PuntosTotales.ToString() + "/7";
        }

    }
    /*Este es un m�todo p�blico que permite actualizar el texto del objeto puntos. 
     * Toma un argumento puntosTotales y establece el texto del objeto puntos en el valor de puntosTotales.*/
    public void ActualizarPuntos(int puntosTotales)
    {
        puntos.text= puntosTotales.ToString();
    }
    /* Este es un m�todo p�blico que toma un �ndice como argumento y desactiva el GameObject en la posici�n correspondiente en el array vidas.
     * Esto se lo utiliza para representar la p�rdida de una vida en el juego.*/
    public void DesactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
    }
    /*Este es otro m�todo p�blico que toma un �ndice como argumento y activa el GameObject en la posici�n correspondiente en el array vidas.
     * Esto se lo utiliza la recuperaci�n de una vida en el juego.*/
    public void ActivarVida(int indice)
    {
        vidas[indice].SetActive(true);
    }
}
