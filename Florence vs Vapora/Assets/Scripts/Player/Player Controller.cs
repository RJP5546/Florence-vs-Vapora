using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] private Animator animator;


    [SerializeField] private float animationPlayerSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float targetSpeed;
    [SerializeField] private float targetLerpTime;

    [SerializeField] private float walkSpeed;

    [SerializeField] private float walkLerpTime;
    [SerializeField] private float stopLerpTime;

    [SerializeField] private float jumpingPower = 16f;

    [SerializeField] private SpriteRenderer playerSpriteRenderer;

    private float horizontalInputDirection;
    

    [SerializeField] private GameObject playerSpawnLocation;

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

    void FixedUpdate()
    {
        //smooth the players movement
        speed = Mathf.Lerp(speed, targetSpeed, targetLerpTime);
        //update the animator speed
        animator.SetFloat("AnimationPlayerSpeed", speed);
        //update the players velocity
        rb.velocity = new Vector2(horizontalInputDirection * speed, rb.velocity.y);
    }

    public void UpdatePlayerSpawnLocation(GameObject newSpawnLocation)
    {
        //when entering a new scene, this will update the players spawnpoint
        playerSpawnLocation = newSpawnLocation;
    }

    public void Respawn()
    {
        this.transform.position = playerSpawnLocation.transform.position;
    }

    private bool IsGrounded()
    {
        //returns if the player is on the ground
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
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
        
        if (context.performed) 
        {
            //set the horizontal input direction
            horizontalInputDirection = context.ReadValue<Vector2>().x;
            targetSpeed = walkSpeed;
            targetLerpTime = walkLerpTime;

            //flip the character if needed
            if (playerSpriteRenderer.flipX && horizontalInputDirection > 0f)
            {
                playerSpriteRenderer.flipX = false;
            }
            else if (!playerSpriteRenderer.flipX && horizontalInputDirection < 0f)
            {
                playerSpriteRenderer.flipX = true;
            }
        }
        
        
        if (context.canceled)
        {
            targetSpeed = 0;
            targetLerpTime = stopLerpTime;
        }


    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        //call the interact with item method on the itemInteractor
        if (context.performed) { itemInteractor.InteractWithItem(); }
        
    }
}

