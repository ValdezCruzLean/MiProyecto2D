using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
   [SerializeField] private float jumpForce = 2500f;//fuerza
    private bool isGrounded;
    private Rigidbody2D rb;
   // public int saltosMaximos = 1;
    //private int saltosRestantes;
  


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // saltosRestantes = saltosMaximos;

    }

    // Update is called once per frame
    void Update()
    {
       if(isGrounded && Input.GetButton("Jump"))
        {
            Jump();
        }

    }
    private void Jump()
    {

        rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D otherTag)
    {
        if (otherTag.gameObject.CompareTag("Mapa"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D otherTag)
    {
        if (otherTag.gameObject.CompareTag("Mapa"))
        {
            isGrounded = false;
        }
    }



}
