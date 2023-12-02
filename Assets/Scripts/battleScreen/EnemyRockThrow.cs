using UnityEngine;

public class EnemyRockThrow : MonoBehaviour
{
    public float speed = 10f;            // Speed of the rock
    public Vector2 direction = Vector2.left; // Moving from right to left
    public float lifespan = 2f;          // How long the rock exists before being destroyed
    public int damage = 15;              // Damage done to the player
    private AudioSource audioSource;


    private void Start()
    {
        Destroy(gameObject, lifespan);
        audioSource = GetComponent<AudioSource>();
        PlaySound();
    }
     public void PlaySound()
    {
        if(audioSource != null)
        {
            audioSource.Play();
        }
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Actor playerActor = collision.gameObject.GetComponent<Actor>();
            if(playerActor)
            {
                playerActor.TakeDamage(damage);
            }
            Destroy(gameObject); // Destroy the rock after it hits the player
        }
    }
}

