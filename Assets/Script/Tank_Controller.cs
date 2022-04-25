using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Controller : MonoBehaviour
{

    public float tankSpeed = 3f;
    public Rigidbody2D rb;
    public Transform firePoint;
    Vector2 vector;

    // Update is called once per frame
    void Update()
    {
        vector.x = Input.GetAxisRaw("Horizontal");
        vector.y = Input.GetAxisRaw("Vertical");
        
        
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + vector * tankSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = (Vector2)firePoint.position - rb.position;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            
            rb.rotation = 90;
        
        }


        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
           
            rb.rotation = -90;

        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            
            rb.rotation = 0;

        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            
            rb.rotation = 180;

        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {

            rb.rotation = -45;

        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {

            rb.rotation = 45;

        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {

            rb.rotation = -135;

        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {

            rb.rotation = 135;

        }

    }
}
