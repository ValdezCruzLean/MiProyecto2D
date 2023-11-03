using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private bool puedeAtacar = true;
    [SerializeField] private float speed;
    [SerializeField] private float cooldownAtaque;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("CorrutinaMovement");
        cooldownAtaque = 3f;
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PikesMovement"))
        {
            Destroy(this.gameObject);
        }   
        if (other.gameObject.CompareTag("Player")){

            if (!puedeAtacar) return;
            puedeAtacar = false;
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;
            ScriptGameManager.instance.PerderVida();
            

            other.gameObject.GetComponent<CharacterController>().AplicarGolpe();
        }
    }
    IEnumerator CorrutinaMovement()
    {
        this.speed = this.speed * -1;
        yield return new WaitForSeconds(3);

        StartCoroutine("CorrutinaMovement");


        Invoke("reactivarAtaque", cooldownAtaque);
    }

    public void reactivarAtaque()
    {
        Color c = spriteRenderer.color;
        c.a = 1f;
        spriteRenderer.color = c;
        puedeAtacar= true;
    }
}


