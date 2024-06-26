using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerInputController.IPlayerControlsActions
{
    private PlayerInputController.PlayerControlsActions actions;
    //refrence to the action map we are implementing
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private PlayerItemCollect itemInteractor;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float horizontalInputDirection;
    [SerializeField] private float speed;
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to our action map
        actions = new PlayerInputController().PlayerControls;
        //Enable our actions
        actions.Enable();
        //Set callbacks to those actions (automatically handled since we derive from IWristMenuActions)
        actions.SetCallbacks(this);
    }

    void Update()
    {
        //update the players velocity
        rb.velocity = new Vector2(horizontalInputDirection * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        //returns if the player is on the ground
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        //Flip the Player X scale
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //jump if the player is on the ground
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        //jump higher if the jump button is held longer
        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        //set the horizontal input direction
        horizontalInputDirection = context.ReadValue<Vector2>().x;

        //flip the character if needed
        if(!isFacingRight && horizontalInputDirection > 0f) 
        {
            Flip();
        }
        else if (isFacingRight && horizontalInputDirection < 0f)
        {
            Flip();
        }

    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        //call the interact with item method on the itemInteractor
        if (context.performed) { itemInteractor.InteractWithItem(); }
        
    }
}

