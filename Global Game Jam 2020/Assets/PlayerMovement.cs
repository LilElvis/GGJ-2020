using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
      
    }   

    // Update is called once per frame
    void Update()
    {

        Vector2 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));


        rb.AddForce(direction * speed);
    }

    void FixedUpdate()
    {

    }


}
