using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{

    //Inputs
    private PlayerInputActions playerInputActions;
    private InputAction move;
    private InputAction jump;

    //Movement
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    [SerializeField] float moveSpeed;

    //Jump
    [SerializeField] private float jumpForce;
    public bool hasDoubleJump;

    //Groundcheck
    private bool collDown;
    private CapsuleCollider2D capsuleCollider; //player collider
    [SerializeField] private LayerMask collidable;
    [SerializeField] private float collisionDetectionLength; //How far to check for collision

    //upgrades
    private UpgradeManager upgradeManager;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        upgradeManager = GetComponent<UpgradeManager>();
    }

    private void OnEnable()
    {
        move = playerInputActions.Player.Move;
        move.Enable();

        jump = playerInputActions.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
    }

    private void OnDisable()
    {
        move = move = playerInputActions.Player.Move;
        move.Disable();
        jump = playerInputActions.Player.Jump;
        jump.Disable();
        jump.performed -= Jump;
    }

    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        GroundCheck();
    }

    void FixedUpdate()
    {
        Move();
        Crouch();
    }

    private void Move()
    {
        if (upgradeManager.Left)
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
        else if (moveDirection.x >= 0)
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }

    #region GroundCheck
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
    private void Jump(InputAction.CallbackContext context)
    {
        if (collDown && upgradeManager.Jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else if (!collDown && hasDoubleJump && upgradeManager.DoubleJump)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            hasDoubleJump = false;
        }
    }
    #endregion

    #region Crouch

    private void Crouch()
    {
        if (!upgradeManager.Crouch)
            return;

        if (moveDirection.y < 0)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(2, 2, 1);
    }
    #endregion

    private void OnDrawGizmos()
    {
        if (capsuleCollider)
            Gizmos.DrawLine(transform.position + (Vector3)capsuleCollider.offset, transform.position + (Vector3)capsuleCollider.offset + -transform.up * collisionDetectionLength);
    }
}
