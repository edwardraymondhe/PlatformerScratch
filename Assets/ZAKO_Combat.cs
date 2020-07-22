using UnityEngine;
using System.Collections;

public class ZAKO_Combat : MonoBehaviour
{
    public int attackDamage = 50;

    public LayerMask attackLayer;
    public Transform attackPoint;

    public Rigidbody2D rb;
    public ZAKO zako;
    private float dashSpeed = 10f;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        zako = GetComponentInParent<ZAKO>();
    }

    public void dash()
    {
        int facing = zako.isFlipped == false ? 1 : -1;
        rb.velocity = new Vector2(facing * dashSpeed, rb.velocity.x);
    }



}
