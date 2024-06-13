using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gommba_DetectorScript : MonoBehaviour
{
    public float speed;
    public Transform detect;
    public LayerMask wallMask;

    private Rigidbody2D Rigidbody;
    
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Rigidbody.velocity = new Vector2(transform.right.x * speed, Rigidbody.velocity.y);

        // Hace girar al enemigo segun detecte un muro
        Collider2D collision = Physics2D.OverlapCircle(detect.position, 0.1f, wallMask);
        if (collision != null)
        {
            transform.eulerAngles = transform.eulerAngles.y == 0 ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player_ControlScript>().AutoJump();
            Destroy(gameObject);
        }
    }
}
