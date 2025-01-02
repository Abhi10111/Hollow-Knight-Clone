using UnityEngine;

public class Enemy : Attackables
{
    protected float health;
    protected GameObject player;

    protected void Start()
    {
        player = GameManager.instance.player;
    }
    
    public virtual void Attack(float amount)
    {
        player.GetComponent<PlayerController>().TakeDamage(amount);
    }
    public virtual void Move()
    {

    }
    public virtual void ChasePlayer()
    {

    }

    public override void Hit(RaycastHit2D hit, float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
