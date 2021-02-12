using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //This will tell the game where youre moving to, whether using keyboard or controller (basically driving the character)
    public CharacterController controller;
    //the speed of character
    public float speed = 5f;
    //Base speed of gravity for falling
    public float gravity = -9.81f;
    //Jump Height
    public float jumpHeight = 3f;
    //So the velocity resets on character so they dont drop very quick
    public Transform groundCheck;
    //Size of the indicator to let you know you landed to reset velocity
    public float groundDistance = 0.4f;
    //will check to see if youre on ground instead of other objects
    public LayerMask groundMask;
    //for the gravity of the character
    Vector3 velocity;
    //will know if youre grounded
    bool isGrounded;
    
    void Update()
    {
        //will let code know if landed
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //this is player input Prep
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Taking the input and turning it into directions for movement
        Vector3 move = transform.right * x + transform.forward * z;
        //will actually allow movement
        controller.Move(move * speed * Time.deltaTime);
        //Jump Controlls
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //to get the gravity to actually work
        velocity.y += gravity * Time.deltaTime;
        //to get a realistic gravity
        controller.Move(velocity * Time.deltaTime);


    }
}
