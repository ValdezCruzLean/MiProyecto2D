using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PikesMovementY : MonoBehaviour
{
    private float posicionEliminarY = 25;
    public float velocidad = 1.0f;
    public Vector3 direccion = Vector3.up; // Puedes ajustar la direcci?n del movimiento
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per framea
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            if (this.transform.position.y >= posicionEliminarY)
            {
                Destroy(this.gameObject);
            }
        }
        // Calcula el desplazamiento basado en la direcci?n y la velocidad
        Vector3 desplazamiento = direccion * velocidad * Time.deltaTime;

        // Aplica el desplazamiento al objeto usando Transform.Translate
        transform.Translate(desplazamiento);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) { 
        
            ScriptGameManager.instance.PerderVida();


            other.gameObject.GetComponent<CharacterController>().AplicarGolpe();
        }
    }
}