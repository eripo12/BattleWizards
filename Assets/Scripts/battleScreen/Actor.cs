using UnityEngine;
using UnityEngine.SceneManagement;


public class Actor : MonoBehaviour
{
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
            Die();
        }
    }

    // Added a method to handle custom attacks with variable damage values
    public void CustomAttack(Actor target, int damageAmount)
    {
        target.TakeDamage(damageAmount);
    }

    public void Attack(Actor target)
    {
        target.TakeDamage(attackPower);
    }

    void Die()
{
    // Handle death. For now, just deactivate the object
    gameObject.SetActive(false);

    // If the current actor is the enemy, load the "Overworld" scene
    if (gameObject.CompareTag("Enemy"))
    {
        SceneManager.LoadScene("Overworld");
    }
}

}
