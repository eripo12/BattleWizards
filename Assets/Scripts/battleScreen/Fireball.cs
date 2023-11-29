using UnityEngine;

public class Fireball : MonoBehaviour
{

    public int damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Actor enemy = collision.gameObject.GetComponent<Actor>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); // Destroy the fireball on impact
        }
    }

    void Start()
    {
        Destroy(gameObject, 5f); // Destroy the fireball after 5 seconds to ensure it doesn't exist forever
    }
}

