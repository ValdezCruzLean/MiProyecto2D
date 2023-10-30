using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float movementSpeed = 1250;
    private bool isFacing = false;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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

}
