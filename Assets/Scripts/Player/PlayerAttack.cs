using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public float attackCd = 2;
    private float attackTimerCd; 
    private Vector2 lastMoveDirection = Vector2.down;

    private void Update()
    {
        if (attackTimerCd > 0)
        {
            attackTimerCd -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if(attackTimerCd <= 0)
        {
            anim.SetBool("isAttacking", true);
            attackTimerCd = attackCd;
        }
    }

    public void ResetAttack()
    {
        
        anim.SetBool("isAttacking", false);
    }
}
