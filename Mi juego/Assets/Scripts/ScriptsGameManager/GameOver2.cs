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
    public void EscenaMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void EscenaJuego()
    {
        SceneManager.LoadScene("Level2");
    }
}