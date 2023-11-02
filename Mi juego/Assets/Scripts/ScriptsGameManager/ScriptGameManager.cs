using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGameManager : MonoBehaviour
{
    public HUD hud;
    public static ScriptGameManager instance { get; private set; }
    public int PuntosTotales { get {  return puntosTotales; } }
    private int puntosTotales;
    private int vidas = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        Debug.Log(puntosTotales);
        hud.ActualizarPuntos(puntosTotales);
    }

    public void PerderVida()
    {
        vidas -= 1;
        hud.DesactivarVida(vidas);
        
    }
    public void GanarVida()
    {
        hud.ActivarVida(vidas);
        vidas += 1;
    }
}
