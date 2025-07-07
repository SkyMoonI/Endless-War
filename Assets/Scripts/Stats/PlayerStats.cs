using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth { get; set; }
    public int damage;
    public int statPoints;
    public HealthBar healthBar;

    public TMP_Text HEALTH_TXT;
    public TMP_Text DAMAGE_TXT;
    public TMP_Text STATPOINTS_TXT;

    public static int killCount=0;
    void Start()
    {
        damage = 100;
        statPoints = 0;
        maxHealth = 100;
        
        if (maxHealth > 100)
            maxHealth = PlayerPrefs.GetInt("playerMaxHealth");
        if (damage > 100)
            damage = PlayerPrefs.GetInt("playerDamage");
        currentHealth = maxHealth;
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            healthBar.SetMaxHealth(maxHealth);
            killCount = 0;
        }

        if (SceneManager.GetActiveScene().name == "DieScene")
        {
            Debug.Log(damage);
            Debug.Log(statPoints);
            Debug.Log(maxHealth);
            statPoints = (int)(killCount / 10);
            Debug.Log(killCount);
            Debug.Log(statPoints);
            Update_Stats();
        }
        
    }
    public void Update_Stats()
    {
            maxHealth = PlayerPrefs.GetInt("playerMaxHealth");
            damage = PlayerPrefs.GetInt("playerDamage");
            HEALTH_TXT.text = maxHealth.ToString();
            DAMAGE_TXT.text = damage.ToString();
            Debug.Log(statPoints);
            STATPOINTS_TXT.text = statPoints.ToString();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(20);
        }
    }
    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        
    }
    public void DamageIncrease()
    {
        if(statPoints > 0)
        {
            statPoints--;
            damage += 10;
            PlayerPrefs.SetInt("playerDamage", damage);
            Update_Stats();
        }

    }
    public void DamageDecrease()
    {
        if (damage > 100)
        {
            damage -= 10;
            statPoints++;
            PlayerPrefs.SetInt("playerDamage", damage);
            Update_Stats();
        }
    }
    public void HealthIncrease()
    {
        
        if (statPoints > 0)
        {
            statPoints--;
            maxHealth += 10;
            currentHealth = maxHealth;
            PlayerPrefs.SetInt("playerMaxHealth", maxHealth);
            Update_Stats();
        }
    }
    public void HealthDecrease()
    {
        if(maxHealth > 100)
        {
            maxHealth -= 10;
            currentHealth = maxHealth;
            statPoints++;
            PlayerPrefs.SetInt("playerMaxHealth", maxHealth);
            Update_Stats();
        }
    }
}