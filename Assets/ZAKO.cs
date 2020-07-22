using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZAKO : MonoBehaviour
{
    public Animator animator;

    public Player player;
    public Rigidbody2D rb;

    public bool isFlipped = false;
    public float distance;

    public ZAKO_Combat combat;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        combat = GetComponentInChildren<ZAKO_Combat>();
    }

    private void Update()
    {
        distance = rb.position.x - player.transform.position.x;
        
        animator.SetFloat("distance", Mathf.Abs(distance));

        if (distance > 0 && isFlipped == false)
        {
            Flip();
        }
        else if (distance < 0 && isFlipped == true)
        {
            Flip();
        }
    }

    public void Flip()
    {
        isFlipped = !isFlipped;

        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(GetComponentInParent<Transform>().position, 5f);
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<Player>().takeDamage(combat.attackDamage);
        }
     }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
