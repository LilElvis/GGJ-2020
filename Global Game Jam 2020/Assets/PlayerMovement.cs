using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController cc;
    public float speed = 10;
    public Vector2 movement;
    
    // Start is called before the first frame update
    void Start()
    {
        cc = this.GetComponent<CharacterController>();
    }   

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement.Normalize();
        cc.Move(movement * Time.deltaTime * speed);
       
    }

   
}
