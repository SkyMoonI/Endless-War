using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{
    public int damageAmount = 5;
    private CapsuleCollider m_CapsuleCollider;


    // Start is called before the first frame update
    void Start()
    {
        //Fetch the GameObject's Collider (make sure they have a Collider component)
        m_CapsuleCollider = GetComponent<CapsuleCollider>();
    }
    private void Update()
    {
        if (GetComponentInParent<Animator>().GetBool("isAttacking") && !GetComponentInParent<Animator>().GetBool("isDead"))
        {
            m_CapsuleCollider.enabled = true;

        }
        else
        {
            m_CapsuleCollider.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("damage taken");
            other.GetComponent<PlayerStats>().TakeDamage(damageAmount);
        }
    }
}
