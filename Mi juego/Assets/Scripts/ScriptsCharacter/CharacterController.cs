using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float movementSpeed = 1250;
    [SerializeField] private float fuerzaGolpe;
    private bool puedeMoverse = true ;
    private bool isFacing = false;
    private Rigidbody2D rb;
    private bool isGrounded;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!puedeMoverse) return;
        float movementX = Input.GetAxis("Horizontal");
        Flip(movementX);
        Move(movementX * movementSpeed);

    }

    private void Move(float velocity)
    {
        rb.velocity = new Vector2(velocity * Time.deltaTime, rb.velocity.y);
    }

    private void Flip(float movementX)
    {
        if ((isFacing == true && movementX < 0) || (isFacing == false && movementX > 0))
        {
            isFacing = !isFacing;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    public void AplicarGolpe()
    {
        puedeMoverse = false;
        Vector2 direccionGolpe;
        if (rb.velocity.x < 0)
        {
            direccionGolpe = new Vector2(-1, 1);
        }
        else
        {
            direccionGolpe = new Vector2(1, 1);

        }
        rb.AddForce(direccionGolpe * fuerzaGolpe);
        StartCoroutine(EsperarYActivasMovimiento());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }



    IEnumerator EsperarYActivasMovimiento()
    {
        yield return new WaitForSeconds(0.1f);
        while (!isGrounded)
        {
            yield return null;
        }
        puedeMoverse = true;
    }
}
