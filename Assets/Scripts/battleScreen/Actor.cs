using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Actor : MonoBehaviour
{
    // Reference for editing the dialogue box
    [SerializeField] BattleDialogue dialogueText;

    public int maxHealth = 100;
    public int currentHealth; // Made this public
    public int attackPower = 10;
    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(gameObject.name + " is taking " + damage + " damage.");
        
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        Debug.Log(gameObject.name + "'s current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            StartCoroutine(DelayedDeactivation());
        }
    }

    public void CustomAttack(Actor target, int damageAmount)
    {
        target.TakeDamage(damageAmount);
    }

    public void Attack(Actor target)
    {
        target.TakeDamage(attackPower);
    }

    IEnumerator DelayedDeactivation()
    {
        // Wait for a short duration before deactivating
        yield return new WaitForSeconds(1f); // You can adjust this duration

        // Deactivate the object
        gameObject.SetActive(false);

        // If the current actor is the enemy, load the "Overworld" scene
        if (gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Tower1");
        }
    }
}

