using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFire : MonoBehaviour
{
    [SerializeField] private GameObject fires;
    // Start is called before the first frame update
    void Start()
    {
       
        InvokeRepeating("GenerateFire",0,2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GenerateFire()
    {
       
        Instantiate(fires, this.transform.position, Quaternion.identity);
    }
}
