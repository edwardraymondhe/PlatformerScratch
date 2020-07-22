using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Animator animator;
    public LayerMask playerLayer;

    public Transform attackPoint;
    public float attackRange;
    public int attackDamage = 20;
    public float attackRate = 2f;
    public float nextAttackTime = 0f;

    void Attack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<Player>().takeDamage(attackDamage);
            Debug.Log("He's dealed" + attackDamage + "damage to " + player.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
