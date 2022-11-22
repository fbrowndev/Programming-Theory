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
    [SerializeField] float runSpeed;

    Vector3 moveDirection;
    Vector3 velocity;

    [Header("Ground Check")]
    [SerializeField] bool isGrounded;
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float gravity;

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

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalMovement, 0, verticalMovement) * runSpeed * Time.deltaTime;

        controller.Move(moveDirection);
        
    }

    void PlayerJump()
    {
        //Add code here later
    }

    void PlayerFire()
    {
        //Add Code here later
    }

    #endregion

}
