using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private float posicionEliminarY = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EliminateFire();

        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            ScriptGameManager.instance.PerderVida();
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Mapa"))
        {
            Destroy(this.gameObject);
        }
    }


    private void EliminateFire ()
    {
        
        if (this.transform.position.y <= posicionEliminarY)
        {
            Destroy(this.gameObject);
        }
    }
}
