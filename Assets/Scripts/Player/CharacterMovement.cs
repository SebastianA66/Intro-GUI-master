using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    [Header("Mini Header")]
    public float speed = 6.0f;
    public float jumpspeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;
    

    private void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));



            moveDirection = transform.TransformDirection(moveDirection);

            moveDirection *= speed;

            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = jumpspeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);



    }
}

