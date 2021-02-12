using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintCrouch : MonoBehaviour
{
    //Crouching Variables
    CharacterController characterCollider;
    //Running Variables
    PlayerMovement basicMovementScript;
    public float speedBoost = 10f;

    void Start()
    {
        //For Crouching
        characterCollider = gameObject.GetComponent<CharacterController>();
        //For Running
        basicMovementScript = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        //Crouch
        if (Input.GetKey(KeyCode.LeftControl))
        {
            characterCollider.height = 1.8f;
        }
        else
        {
            characterCollider.height = 3.8f;
        }
        //sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
            basicMovementScript.speed += speedBoost;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            basicMovementScript.speed -= speedBoost;
    }

}
