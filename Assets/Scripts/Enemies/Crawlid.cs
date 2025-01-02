using System;
using UnityEngine;
using Utilities;
public class Crawlid : Enemy
{
    [SerializeField] float attackDamage = 5f;
    [SerializeField] float attackDistance = 1f;
    [SerializeField] float movementSpeed = 1.5f;
    [SerializeField] GameObject[] bounds=new GameObject[2];
    Rigidbody2D rigidbody;
    Vector2 flipPoint; //Point at which the player will flip
    Vector2 leftBound;
    Vector2 rightBound;
    void Start()
    {
        base.Start();    
        health = 40.0f;
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.linearVelocityX = -movementSpeed;
        flipPoint = bounds[0].transform.position;
        leftBound = bounds[0].transform.position;
        rightBound = bounds[1].transform.position;
    }
    void Update()
    {
        if(Vector2.Distance(player.transform.position,transform.position) < attackDistance)
        {
            Attack(attackDamage);
        }
        else
        {
            Move();
        }
    }
    public override void Attack(float amount)
    {
        rigidbody.linearVelocityX = 0;
        if (Mathf.Sign(transform.position.x-player.transform.position.x ) != Mathf.Sign(transform.localScale.x))
        {
            Utilities.Utilities.Flip(gameObject);
        }
        base.Attack(amount);
    }
    public override void Move()
    {
        rigidbody.linearVelocityX = -Mathf.Sign(transform.localScale.x)*movementSpeed;
        if (Vector2.Distance(transform.position, leftBound) < 0.2f && flipPoint == leftBound)
        {
            Utilities.Utilities.Flip(gameObject);
            flipPoint = rightBound;
        }
        else if (Vector2.Distance(transform.position, rightBound) < 0.2f && flipPoint==rightBound)
        {
            Utilities.Utilities.Flip(gameObject);
            flipPoint = leftBound;
        }
    }

    public override void Hit(RaycastHit2D hit, float damage)
    {
        base.Hit(hit, damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(bounds[0].transform.position, 0.2f);
        Gizmos.DrawWireSphere(bounds[1].transform.position, 0.2f);
        Gizmos.DrawLine(bounds[0].transform.position, bounds[1].transform.position);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }

}
