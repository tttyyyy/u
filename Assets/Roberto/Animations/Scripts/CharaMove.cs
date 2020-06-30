using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaMove : MonoBehaviour
{

    
    public float speed = 3f;
    public float gravity = 10f;
    public float jumpSpeed = 5f;

    
    Vector3 moveDirection;

  
    CharacterController controller;

   
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;




    void Start()
    {

        controller = GetComponent<CharacterController>();

   

    }

    void Update()
    {
       
        if (controller.isGrounded)
        {
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            transform.Rotate(0, h, 0);
          
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0,
                                    Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButtonDown("Jump"))
                moveDirection.y = jumpSpeed;
        }

   
        moveDirection.y -= gravity * Time.deltaTime;

  
        controller.Move(moveDirection * Time.deltaTime);

    }
}