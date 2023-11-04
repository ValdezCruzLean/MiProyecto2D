using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public GameObject[] vidas;
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



        //puntos.text = "Monedas: " + ScriptGameManager.instance.PuntosTotales.ToString() + "/10";
    }

    public void ActualizarPuntos(int puntosTotales)
    {
        puntos.text= puntosTotales.ToString();
    }

    public void DesactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
    }

    public void ActivarVida(int indice)
    {
        vidas[indice].SetActive(true);
    }
}
