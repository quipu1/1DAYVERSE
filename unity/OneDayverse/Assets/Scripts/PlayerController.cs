using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // component 
    private CharacterController characterController;
    private Animator animator;

    // var move
    private float inputX;
    private float inputZ;
    private Vector3 v_movement;
    private Vector3 v_valocity;
    private float moveSpeed;
    private float gravity;

    // Start is called before the first frame update
    void Start()
    {
        // component
        GameObject tmpPlayer = GameObject.FindGameObjectWithTag("Player");
        characterController = tmpPlayer.GetComponent<CharacterController>();
        animator = tmpPlayer.transform.GetComponent<Animator>();

        // etc
        moveSpeed = 4f;
        gravity = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        // when moving forward
        if (inputZ == 0)
        {
            animator.SetBool("isMoveForward", false);
            animator.SetBool("isMoveBackward", false);
        }
        else if (inputZ > 0)
        {
            animator.SetBool("isMoveForward", true);
        }
        else if (inputZ < 0)
        {
            animator.SetBool("isMoveBackward", true);
        }
    }

    private void FixedUpdate()
    {
        // gravity
        if (characterController.isGrounded)
        {
            v_valocity.y = 0f;
        }
        else
        {
            v_valocity.y = gravity * Time.deltaTime;
        }
        // Input forward
        v_movement = characterController.transform.forward * inputZ;

        // char roatate
        characterController.transform.Rotate(Vector3.up * inputX * (100f * Time.deltaTime));

        // char move * gravity
        characterController.Move(v_movement * moveSpeed * Time.deltaTime);
        characterController.Move(v_valocity);
    }
}