using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Vector2 movement;
    public float speed = 5;
    public float friction;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        gameObject.transform.Rotate(0, 0, movement.x);
    }

    void moveCharacter(Vector2 direction)

    {

        rb.AddRelativeForce(direction * speed);
    }
    void FixedUpdate()
    {
        moveCharacter(movement);

    }


}
