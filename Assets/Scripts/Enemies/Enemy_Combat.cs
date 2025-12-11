using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public int damage = 1;
    public float weaponRange;

    public float knockbackForce;
    public float stunTime;

    public Transform attackPoint;
    public LayerMask playLayer;


    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playLayer);

        if (hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().ChangeHealth(-damage);
            hits[0].GetComponent<PlayerMovement>().Knockback(transform, knockbackForce, stunTime);
        }

    }
}
