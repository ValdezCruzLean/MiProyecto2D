using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScriptGameManager : MonoBehaviour
{
    public HUD hud;
    public static ScriptGameManager instance { get; private set; }
    public int PuntosTotales { get {  return puntosTotales; } }
    private int puntosTotales;
    private int vidas = 3;
    public AudioClip damageReceived;

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
        if(SceneManager.GetActiveScene().name == "Level1" && puntosTotales >= 10)
        {
            SceneManager.LoadScene("Level2");
        }

        if (SceneManager.GetActiveScene().name == "Level2" && puntosTotales >= 7)
        {
            SceneManager.LoadScene("YouWin");
        }

    }

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
