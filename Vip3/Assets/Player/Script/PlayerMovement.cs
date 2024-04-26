using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    //Movement
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    [SerializeField] float moveSpeed;

    //Jump
    [SerializeField] private float jumpHeight;
    [SerializeField] private float doubleJumpHeight;
    private bool hasDoubleJump; 

    //Groundcheck
    private bool collDown, collUp, collLeft, collRight; //is palyer colliding with something in any direction
    private CapsuleCollider2D capsuleCollider; //player collider
    [SerializeField] private LayerMask collidable; //which layers are collidable
    [SerializeField] private float collisionDetectionLength; //How far to check for collision

    //Minimize
    private Vector3 baseScale;
    private bool isMinimized;

    //references
    [SerializeField] private UpgradeManager upgradeManager; //to read what has been unlocked
    private PlayerControls playerControls; //to read player inputs


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        playerControls = GetComponent<PlayerControls>();
        baseScale = transform.localScale;
        upgradeManager.Initiate();
    }



    private void Update()
    {
        moveDirection = playerControls.MoveDirection;
        CollisionCheck();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (collLeft && moveDirection.x < 0 || collRight && moveDirection.x > 0)
            return;

        if (upgradeManager.Left) // if player has unlocked left movement allow left movement otherwise only move right
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
        else if (moveDirection.x >= 0)
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }

    #region Collision
    //Check if player is touching the ground
    private void CollisionCheck()
    {
        collDown = Physics2D.CapsuleCast(transform.position + (Vector3)capsuleCollider.offset, capsuleCollider.size, capsuleCollider.direction, 0, Vector2.down, collisionDetectionLength, collidable).collider != null;
        if (collDown)
        {
            hasDoubleJump = true;
        }

        collUp = Physics2D.CapsuleCast(transform.position + (Vector3)capsuleCollider.offset, capsuleCollider.size, capsuleCollider.direction, 0, Vector2.up, collisionDetectionLength, collidable).collider != null;
        collLeft = Physics2D.CapsuleCast(transform.position + (Vector3)capsuleCollider.offset, capsuleCollider.size, capsuleCollider.direction, 0, Vector2.left, collisionDetectionLength, collidable).collider != null;
        collRight = Physics2D.CapsuleCast(transform.position + (Vector3)capsuleCollider.offset, capsuleCollider.size, capsuleCollider.direction, 0, Vector2.right, collisionDetectionLength, collidable).collider != null;
        
    }

    #endregion

    #region Jump

    private float CalculateJumpSpeed(float jumpHeight)
    {
        return Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
    }

    public void Jump()
    {
        float jumpSpeed = CalculateJumpSpeed(jumpHeight);

        if (collDown && upgradeManager.Jump) //jump if unlocked
        {
            rb.velocity = new Vector2(rb.velocity.x, CalculateJumpSpeed(jumpHeight));
        }
        else if (!collDown && hasDoubleJump && upgradeManager.DoubleJump) //perform second jump if double jump unlocked & is in the iar
        {
            rb.velocity = new Vector2(rb.velocity.x, CalculateJumpSpeed(doubleJumpHeight));
            hasDoubleJump = false;
        }
    }
    #endregion

    #region Minimize

    public void Minimize()
    {
        if (!upgradeManager.Crouch) //crouch if unlocked
            return;

        if (isMinimized) // minimize player if button has been toggled{
        {
            transform.localScale = new Vector3(baseScale.x / 2, baseScale.y / 2, baseScale.z);
            isMinimized = false;
        }
        else if(!isMinimized && !collUp)
        {
            transform.localScale = baseScale;
            isMinimized = true;
        }
    }
    #endregion

    private void OnDrawGizmos()
    {
        if (capsuleCollider)
            Gizmos.DrawLine(transform.position + (Vector3)capsuleCollider.offset, transform.position + (Vector3)capsuleCollider.offset + -transform.up * collisionDetectionLength);
    }
}
