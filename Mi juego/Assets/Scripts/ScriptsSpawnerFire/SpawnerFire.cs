using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFire : MonoBehaviour
{
    [SerializeField] private GameObject fires;
    [SerializeField] private float speed;
   // private float posicionEliminarY = -1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("MiCorrutina");
        speed = 3f;  
        InvokeRepeating("GenerateFire",0,2f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
       // if (fires.transform.position.y <= posicionEliminarY)
        //{
          // Debug.Log("se deberia destruir");
        //}
    }
    public void GenerateFire()
    {
       
        Instantiate(fires, this.transform.position, Quaternion.identity);
    }
    IEnumerator MiCorrutina()
    {
        this.speed = this.speed * -1;
        yield return new WaitForSeconds(26);
       
        StartCoroutine("MiCorrutina");
    }
}
