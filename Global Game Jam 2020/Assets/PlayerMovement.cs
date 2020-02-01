using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Vector2 movement;
    public float speed = 5;
    public float friction;

    float yAxis, xAxis;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
         yAxis = Input.GetAxis("Vertical");
         xAxis = Input.GetAxis("Horizontal");
        
    }
    void FixedUpdate()
    {
        moveForward(yAxis);

    }

    void moveForward(float thrust)
    {
        Vector2 force = transform.up * thrust;

        rb.AddRelativeForce(force);
    }


}
