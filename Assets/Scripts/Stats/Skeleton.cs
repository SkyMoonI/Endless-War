using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Skeleton : MonoBehaviour
{
    public int hp;
    public Animator animator;

    public Slider healthBar;
    public void TakeDamage(int damageAmount)
    {
        hp-=damageAmount;
        Debug.Log(hp);

        if (hp <= 0)
        {
            PlayerStats.killCount++;
            Debug.Log(PlayerStats.killCount);
            animator.SetTrigger("isDead");
            Debug.Log("dead");
            Destroy(transform.GetComponent<CapsuleCollider>());
            Destroy(gameObject,3);
            animator.SetBool("isAttacking", false);
        }
        else
        {
            animator.SetTrigger("isDamaged");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = hp;
    }
}
