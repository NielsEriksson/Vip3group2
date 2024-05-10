using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
public class PlayerMovement : MonoBehaviour
{
    //Movement
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    [SerializeField] float maxMoveSpeed = 5;
    [SerializeField] float acceleration = 25;

    //Jump
    [SerializeField] private float jumpHeight;
    [SerializeField] private float doubleJumpHeight;
    [SerializeField] private float wallJumpHeight;
    [SerializeField] private float wallJumpXSpeed;
    private bool hasDoubleJump;

    //Groundcheck
    public bool collDown, collUp, collLeft, collRight; //is palyer colliding with something in any direction
    private BoxCollider2D boxCollider; //player collider
    [SerializeField] private LayerMask collidable; //which layers are collidable
    [SerializeField] private float collisionDetectionLength; //How far to check for collision

    //Minimize
    private Vector3 baseScale;
    private bool isMinimized;

    //references
    private PlayerControls playerControls; //to read player inputs


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        playerControls = GetComponent<PlayerControls>();
        baseScale = transform.localScale;
    }



    private void LateUpdate()
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
        float speed = rb.velocity.x;
        if (UpgradeManager.Instance.left && moveDirection.x != 0) // if player has unlocked left movement allow left movement otherwise only move right
        {
            speed = Mathf.MoveTowards(speed, maxMoveSpeed * moveDirection.x, acceleration * Time.deltaTime);
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        else if (moveDirection.x > 0)
        {
            speed = Mathf.MoveTowards(speed, maxMoveSpeed * 1, acceleration * Time.deltaTime);
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (moveDirection == Vector2.zero) // nothing is being pressed so we stop
        {
            speed = Mathf.MoveTowards(speed, 0, acceleration * Time.deltaTime);
            rb.velocity = new Vector2(speed, rb.velocity.y);

        }
    }

    #region Collision
    //Check if player is touching the ground
    private void CollisionCheck()
    {
        collDown = Physics2D.BoxCast(transform.position + (Vector3)boxCollider.offset, boxCollider.size * transform.localScale, 0, Vector2.down, collisionDetectionLength, collidable).collider != null;
        if (collDown)
        {
            hasDoubleJump = true;
        }

        collUp = Physics2D.BoxCast(transform.position + (Vector3)boxCollider.offset, boxCollider.size * transform.localScale, 0, Vector2.up, collisionDetectionLength, collidable).collider != null;
        collLeft = Physics2D.BoxCast(transform.position + (Vector3)boxCollider.offset, boxCollider.size * transform.localScale, 0, Vector2.left, collisionDetectionLength, collidable).collider != null;
        collRight = Physics2D.BoxCast(transform.position + (Vector3)boxCollider.offset, boxCollider.size * transform.localScale, 0, Vector2.right, collisionDetectionLength, collidable).collider != null;

    }

    #endregion

    #region Jump

    private float CalculateJumpSpeed(float jumpHeight)
    {
        return Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
    }

    public void Jump()
    {

        if ((collLeft && moveDirection.x < 0) || (collRight && moveDirection.x > 0) && !collDown)
        {
            rb.velocity = new Vector2(-moveDirection.x * wallJumpXSpeed, CalculateJumpSpeed(wallJumpHeight));
        }
        if (collDown && UpgradeManager.Instance.jump) //jump if unlocked
        {
            rb.velocity = new Vector2(rb.velocity.x, CalculateJumpSpeed(jumpHeight));
            AudioManager.Instance.PlaySFX(Sound.Jump);
        }
        else if (!collDown && hasDoubleJump && UpgradeManager.Instance.doubleJump) //perform second jump if double jump unlocked & is in the iar
        {
            rb.velocity = new Vector2(rb.velocity.x, CalculateJumpSpeed(doubleJumpHeight));
            hasDoubleJump = false;
            AudioManager.Instance.PlaySFX(Sound.Jump);

        }
    }
    #endregion

    #region Minimize

    public void Minimize()
    {
        if (!UpgradeManager.Instance.crouch) //crouch if unlocked
            return;

        if (isMinimized) // minimize player if button has been toggled{
        {
            transform.localScale = new Vector3(baseScale.x / 2, baseScale.y / 2, baseScale.z);
            isMinimized = false;
            AudioManager.Instance.PlaySFX(Sound.Minimize);
        }
        else if (!isMinimized && !collUp)
        {
            transform.localScale = baseScale;
            isMinimized = true;
            AudioManager.Instance.PlaySFX(Sound.Maximize);
        }
    }
    #endregion

    private void OnDrawGizmos()
    {
        if (boxCollider)
        {
            Gizmos.DrawLine(transform.position + (Vector3)boxCollider.offset, transform.position + (Vector3)boxCollider.offset + -transform.up * collisionDetectionLength);
        }
    }
}
