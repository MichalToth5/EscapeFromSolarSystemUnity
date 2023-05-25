using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 15f;
    public float baseSpeed = 15f;
    public float boostedSpeed = 100f;
    public float jumpPower = 22f;
    public float baseJumpPower = 22f;
    public float boostedJumpPower = 30f;

    public bool isFacingRight = true;

    private Animator animator;
    public GameObject cameraHelper;
    public MovementJoystick movementJoystick;
    public Transform jumpImage; // Reference to the jump image transform
    private bool canJump = false;

    public AudioSource jumpSound;

    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] private Transform groundCheck;
    //[SerializeField] private LayerMask groundLayer;

    private enum MovementState { idle, running, jump, falling }

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       // Check if the left mouse button is pressed and the player is touching the jump image
        if (Input.GetMouseButtonDown(0) && RectTransformUtility.RectangleContainsScreenPoint(jumpImage.GetComponent<RectTransform>(), Input.mousePosition))
        {
            canJump = true;
        }

        // Player jump
        if (canJump && Input.GetMouseButtonUp(0) && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpSound.Play();
            canJump = false;
        }
        horizontal = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && rb.velocity.y ==0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpSound.Play();
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        //remove item from slot
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.GetComponent<Inventory>().RemoveFromInventory(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            transform.GetComponent<Inventory>().RemoveFromInventory(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            transform.GetComponent<Inventory>().RemoveFromInventory(2);
        }

        AnimationUpdate();

        Flip();

        UpdateCamera();

       

    }


    /* private bool IsGrounded()
     {
         return Physics2D.OverlapCircle(groundCheck.position, 2f, groundLayer);
     }*/


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (movementJoystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * speed, movementJoystick.joystickVec.y * 0);

        }
        else
        {
            //rb.velocity = Vector2.zero;
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;
        }
    }

    private void AnimationUpdate()
    {
        MovementState state;

        if (horizontal > 0f)
        {
            state = MovementState.running;
        }
        else if (horizontal < 0f)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }

    
      
    
   

    void UpdateCamera()
    {
        cameraHelper.transform.position = Vector3.Lerp(cameraHelper.transform.position, transform.position, 4f * Time.deltaTime);
    }   
}
