using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other1)
    {
        if (other1.gameObject.CompareTag("Player"))
        {  //ScriptGameManager.instance.GanarVida();
            Destroy(this.gameObject);
        }
    }
}
