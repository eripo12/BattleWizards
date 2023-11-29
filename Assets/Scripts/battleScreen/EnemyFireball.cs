using UnityEngine;

public class EnemyFireball : MonoBehaviour
{

    public float speed = 10f;
    public Vector2 direction = Vector2.left; // The fireball will move from right to left by default
    public float lifespan = 5f;  // Time before the fireball gets destroyed to avoid it staying in the scene indefinitely
    public int damage = 20;      // Damage value

    private void Start()
    {
        Destroy(gameObject, lifespan); // Destroy the fireball after a certain amount of time
    }

    private void Update()
    {
        // Move the fireball
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Assuming the player has a tag "Player"
        if (other.CompareTag("Player"))
        {
            Actor playerActor = other.GetComponent<Actor>();
            if (playerActor)
            {
                playerActor.TakeDamage(damage);
                Destroy(gameObject); // Destroy the fireball when it hits the player
            }
        }
    }
}

