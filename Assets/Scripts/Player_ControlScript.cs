using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ControlScript : MonoBehaviour
{
    // Con Range() se crea un deslizador que te deja elegir solo entre valores prestablecidos
    [Range(2,25)]
    public float speed;
    public float jumpForce;
    public Transform point1, point2;
    public LayerMask groundMask;


    // - Si no se pone private antes, tambien se considera que esta en privado
    // La funcion SerialField es una parametro publico temporal. Se puede ver pero no modificar
    private Rigidbody2D Rigidbody;
    [SerializeField]  private bool isGrounded;


    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        isGrounded = Physics2D.OverlapArea(point1.position, point2.position, groundMask);

        //transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        Rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Rigidbody.velocity.y);

        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

    }

    private void FixedUpdate()
    {
        
    }
}
