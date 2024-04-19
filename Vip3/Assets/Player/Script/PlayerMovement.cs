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
    [SerializeField] private float jumpForce;
    public bool hasDoubleJump;

    //Groundcheck
    private bool collDown; //is colliding to something under the player
    private CapsuleCollider2D capsuleCollider; //player collider
    [SerializeField] private LayerMask collidable; //which layers are collidable
    [SerializeField] private float collisionDetectionLength; //How far to check for collision

    //crouch
    private Vector3 baseScale;

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
        GroundCheck();
    }

    void FixedUpdate()
    {
        Move();
        Crouch();
    }

    private void Move()
    {
        if (upgradeManager.Left) // if player has unlocked left movement allow left movement otherwise only move right
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
        else if (moveDirection.x >= 0)
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }

    #region GroundCheck
    //Check if player is touching the ground
    private void GroundCheck()
    {
        collDown = Physics2D.CapsuleCast(transform.position + (Vector3)capsuleCollider.offset, capsuleCollider.size, capsuleCollider.direction, 0, Vector2.down, collisionDetectionLength, collidable).collider != null;
        if (collDown)
        {
            hasDoubleJump = true;
        }
    }

    #endregion

    #region Jump
    public void Jump()
    {
        if (collDown && upgradeManager.Jump) //jump if unlocked
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else if (!collDown && hasDoubleJump && upgradeManager.DoubleJump) //perform second jump if double jump unlocked & is in the iar
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            hasDoubleJump = false;
        }
    }
    #endregion

    #region Crouch

    private void Crouch()
    {
        if (!upgradeManager.Crouch) //crouch if unlocked
            return;

        if (moveDirection.y < 0) // half player scale if pressing down otherwise set it to normal
            transform.localScale = new Vector3(baseScale.x/2,baseScale.y/2, baseScale.z);
        else
            transform.localScale = baseScale;
    }
    #endregion

    private void OnDrawGizmos()
    {
        if (capsuleCollider)
            Gizmos.DrawLine(transform.position + (Vector3)capsuleCollider.offset, transform.position + (Vector3)capsuleCollider.offset + -transform.up * collisionDetectionLength);
    }
}
