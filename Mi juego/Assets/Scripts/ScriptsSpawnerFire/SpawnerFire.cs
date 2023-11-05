using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFire : MonoBehaviour
{ /*Variable fires se utiliza para almacenar una referencia a un objeto GameObject, */
    [SerializeField] private GameObject fires;
    /*Variable speed representa la velocidad de desplazamiento del objeto en el juego.*/
    [SerializeField] private float speed;
    // private float posicionEliminarY = -1;
    // Start is called before the first frame update
    /*Este m�todo se llama autom�ticamente al inicio del juego. En �l, se inician algunas acciones. 
     * Se inicia una corrutina llamada "MiCorrutina" 
     * Se establece el valor de speed en 3.0
     * Se inicia repetidamente el m�todo "GenerateFire" con un intervalo de 1 segundo.*/
    void Start()
    {
        StartCoroutine("MiCorrutina");
        speed = 3f;  
        InvokeRepeating("GenerateFire",0,1f);
    }

    // Update is called once per frame
    /*Este m�todo se llama una vez por fotograma del juego. 
     * El GameObject actual se desplaza hacia la derecha a una velocidad determinada por la variable speed. */
    void Update()
    {
        gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
       // if (fires.transform.position.y <= posicionEliminarY)
        //{
          // Debug.Log("se deberia destruir");
        //}
    }
    /*Este es un m�todo que se encarga de instanciar un objeto fires en la posici�n del GameObject actual.
     * Este m�todo crea copias del objeto de fuego y las coloca en la misma posici�n que el GameObject actual.*/
    public void GenerateFire()
    {
       
        Instantiate(fires, this.transform.position, Quaternion.identity);
    }
    /*Este es un m�todo que devuelve una corrutina. 
     * La corrutina cambia la direcci�n de speed multiplic�ndola por -1 .*/
    IEnumerator MiCorrutina()
    {
        this.speed = this.speed * -1;
        yield return new WaitForSeconds(23);
       
        StartCoroutine("MiCorrutina");
    }
}
