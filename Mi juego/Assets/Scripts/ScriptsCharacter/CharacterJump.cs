using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
     [SerializeField] private float jumpForce = 2500f;//fuerza
    private bool isGrounded;
    private Rigidbody2D rb;
    public int saltosMaximos = 1;
    private int saltosRestantes;
  


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        saltosRestantes = saltosMaximos;

    }

    // Update is called once per frame
    void Update()
    {
        ProcesarSalto();

    }
    void ProcesarSalto()
    {
        if(isGrounded == true)
        {
            saltosRestantes = saltosMaximos;
        }
        if ((saltosRestantes>0) && Input.GetKeyDown(KeyCode.Space))
     {
            saltosRestantes--;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
        }
 }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }



}
