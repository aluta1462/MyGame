using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2DFollow : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform cam;


    // Update is called once per frame
    void Update()
    {


        cam.position = rb.position;
    }
}
