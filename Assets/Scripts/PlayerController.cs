using System;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using static UnityEngine.UI.Image;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] bool drawOnScene = true;
    [SerializeField] bool isGrounded = false;
    [SerializeField] bool isJumping = false;
    [SerializeField] float attackDistance = 0.2f;
    [SerializeField] float boxCastOffset = 0.02f;
    [SerializeField] float attackBoxSize = 0.02f;
    [SerializeField] float damage = 10.0f;
    [SerializeField] float groundDistance = 0.2f;
    [SerializeField] float jumpSpeed = 10.0f;
    [SerializeField] float walkSpeed = 4.0f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform startPostion;
    bool AttackPressed;
    private bool jumpPressed;
    private bool canJump;
    private bool readyToClear;
    private int attackDirection = 0;
    private int playerDirection = 1;
    private float verticalInput = 0;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidbody;
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        if (startPostion)
        {
            transform.position = startPostion.position;
        }
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
        RaycastHit2D hit;
        if(verticalInput==0f)
        {
            attackDirection = 0;
            hit = BoxCast(playerDirection * Vector2.right * (boxCollider.bounds.size.x * 0.5f + boxCastOffset), new Vector2(0.01f, attackBoxSize), playerDirection * Vector2.right, attackDistance, 1 << gameObject.layer);

        }
        else
        {
            attackDirection = verticalInput>0?1:-1;
            hit = BoxCast(attackDirection * Vector2.up * (boxCollider.bounds.size.y * 0.5f + boxCastOffset), new Vector2(attackBoxSize, 0.01f), attackDirection * Vector2.up, attackDistance, 1 << gameObject.layer);

        }
        animator.SetInteger("Attack Direction",attackDirection);
        animator.SetTrigger("Attack");
        if (hit.collider)
        {
            Attackables attackable=hit.collider.GetComponent<Attackables>();
            attackable.Hit(hit,damage);
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
        RaycastHit2D hit = BoxCast(Vector2.down*(boxCollider.bounds.size.y*0.5f+boxCastOffset), new Vector2(boxCollider.bounds.size.x/2, 0.01f), Vector2.down, groundDistance, groundLayer);
        isGrounded = hit && (hit.normal.y>0.9f||hit.normal.y<-0.9f)? true : false;
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
        AttackPressed = false;
        jumpPressed = false;
        readyToClear = false;
        verticalInput = 0f;
    }

    void Flip()
    {

    }
    void GroundMovement()
    {
        float xSpeed= walkSpeed*Input.GetAxis("Horizontal");
        rigidbody.linearVelocity=new Vector2(xSpeed,rigidbody.linearVelocity.y);
        if (xSpeed * playerDirection < 0f)
        {
            Utilities.Utilities.Flip(gameObject);
            playerDirection *= -1;
        }
    }

    void ProcessInputs() 
    {
        AttackPressed = AttackPressed || Input.GetButtonDown("Fire1");
        jumpPressed = jumpPressed || Input.GetButtonDown("Jump");
        verticalInput += Input.GetAxis("Vertical");
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

    public void TakeDamage(float damage)
    {
        Debug.Log(damage);
    }
}
