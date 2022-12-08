using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Controlling all functionality of the player
/// </summary>
public class PlayerController : MonoBehaviour
{
    #region Player Controller Variables

    //Variables
    [Header("Speed controls")]
    [SerializeField] float moveSpeed;
    [SerializeField] float runSpeed;

    Vector3 moveDirection;
    Vector3 velocity;

    [Header("Ground Check")]
    [SerializeField] bool isGrounded;
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float gravity;

    [Header("Jump Controls")]
    [SerializeField] float jumpHeight;

    //References
    CharacterController controller;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    #region Player Movement
    void PlayerMovement()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalMovement, 0, verticalMovement);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero)
            {
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }

            moveDirection *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerJump();
            }
        } 


        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Run()
    {
        moveSpeed = runSpeed;

    }

    void Idle()
    {
        moveSpeed = 0;
    }

    void PlayerJump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    void PlayerFire()
    {
        //Add Code here later
    }

    #endregion

}
