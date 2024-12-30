using System;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] bool drawOnScene = true;
    [SerializeField] bool isGrounded = false;
    [SerializeField] bool isJumping = false;
    [SerializeField] float attackDistance = 0.2f;
    [SerializeField] float boxCastOffset = 0.02f;
    [SerializeField] float boxCastSize = 0.02f;
    [SerializeField] float groundDistance = 0.2f;
    [SerializeField] float jumpSpeed = 10.0f;
    [SerializeField] float walkSpeed = 4.0f;
    [SerializeField] LayerMask groundLayer;
    bool AttackPressed;
    private bool jumpPressed;
    private bool canJump;
    private bool readyToClear;
    private int direction = 1;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidbody;
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        CheckEnvironment();
        GroundMovement();
        AirMovement();
        if (AttackPressed)
        {
            Attack();
        }
        readyToClear = true;
    }


    // Update is called once per frame
    void Update()
    {
        ClearInputs();
        ProcessInputs();
    }


    void Attack()
    {
        animator.SetTrigger("Attack");
        RaycastHit2D hit = BoxCast(direction * Vector2.right* (boxCollider.bounds.size.x * 0.5f + boxCastOffset), new Vector2(boxCastSize, boxCastSize), direction * Vector2.right, attackDistance, 1<<gameObject.layer);
        if (hit.collider)
        {
            Attackables attackable=hit.collider.GetComponent<Attackables>();
            attackable.Hit();
        }    
    }
    void AirMovement()
    {
        if (jumpPressed && canJump) 
        {
            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, jumpSpeed);
            canJump = !isJumping;
            isJumping=true;
        }
    }

    void CheckEnvironment()
    {
        RaycastHit2D hit = BoxCast(Vector2.down*(boxCollider.bounds.size.y*0.5f+boxCastOffset), new Vector2(boxCastSize, boxCastSize), Vector2.down, groundDistance, groundLayer);
        isGrounded = hit && hit.normal.y>0.9f? true : false;
        if (isGrounded)
        {
            canJump = true;
            isJumping = false;
        }
    }
    void ClearInputs()
    {
        if (!readyToClear) 
        {
            return;
        }
        jumpPressed = false;
        readyToClear = false;
        AttackPressed = false;
    }
    void GroundMovement()
    {
        float xSpeed= walkSpeed*Input.GetAxis("Horizontal");
        rigidbody.linearVelocity=new Vector2(xSpeed,rigidbody.linearVelocity.y);
        if (xSpeed * direction < 0f)
        {
            FlipPlayer();
        }
    }

    void ProcessInputs() 
    {
        jumpPressed = jumpPressed || Input.GetButtonDown("Jump");
        AttackPressed = AttackPressed || Input.GetButtonDown("Fire1");
    }
    void FlipPlayer()
    {
        transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
        direction *= -1;
    }
    RaycastHit2D BoxCast(Vector2 start,Vector2 size, Vector2 direction, float distance, LayerMask layer)
    {
        Vector2 center = boxCollider.bounds.center;
        RaycastHit2D hit = Physics2D.BoxCast(center + start, size, 0f, direction, distance,layer);
        
        if (drawOnScene)
        {
            Color color = hit.collider ? Color.red : Color.green;
            Debug.DrawRay(center+start, direction * distance, color);
        }
        return hit;
    }
}
