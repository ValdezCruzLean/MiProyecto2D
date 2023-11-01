using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pikes : MonoBehaviour
{
    public float velocidad = 2.0f;
    public Vector3 direccion = Vector3.up; // Puedes ajustar la direcci�n del movimiento
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        // Calcula el desplazamiento basado en la direcci�n y la velocidad
        Vector3 desplazamiento = direccion * velocidad * Time.deltaTime;

        // Aplica el desplazamiento al objeto usando Transform.Translate
        transform.Translate(desplazamiento);
    }
}