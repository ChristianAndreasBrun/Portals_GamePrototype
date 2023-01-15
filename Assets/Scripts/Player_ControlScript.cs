using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ControlScript : MonoBehaviour
{
    // Con Range() se crea un deslizador que te deja elegir solo entre valores prestablecidos
    [Range(2,25)]
    public float speed;
    public float jumpForce;
    public int totalJumps;
    public Transform point1, point2;
    public LayerMask groundMask;
    public Transform[] portals;


    // - Si no se pone private antes, tambien se considera que esta en privado
    // La funcion SerialField es una parametro publico temporal. Se puede ver pero no modificar
    private Rigidbody2D Rigidbody;
    [SerializeField]  private bool isGrounded;
    private int currentJumps;


    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        isGrounded = Physics2D.OverlapArea(point1.position, point2.position, groundMask);
        //transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        Rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Rigidbody.velocity.y);

        // Coloca los portales en la posicion del raton dentro de la camera
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    portals[0].position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //}
        //if (Input.GetButtonDown("Fire2"))
        //{
        //    portals[1].position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //}


        if (isGrounded)
        {
            currentJumps = 0;
            if (Input.GetButtonDown("Jump"))
            {
                Rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && currentJumps < totalJumps)
            {
                currentJumps++;
                // Siempre empieza en 0, y cancela la velocidad en el aire
                Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, 0);
                Rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

    }

    public void AutoJump()
    {
        Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, 0);
        Rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
