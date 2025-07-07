using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damageAmount=10;
    private CapsuleCollider m_CapsuleCollider;
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the GameObject's Collider (make sure they have a Collider component)
        m_CapsuleCollider = GetComponent<CapsuleCollider>();
        damageAmount = GetComponentInParent<PlayerStats>().damage;
    }
    private void Update()
    {
        if (animationStateController.attackPressed == true)
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
        if(other.tag == "Enemy")
        {
            other.GetComponent<Skeleton>().TakeDamage(damageAmount);    
        }
    }
}
