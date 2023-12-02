using UnityEngine;

public class WaterBlast : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 direction = Vector2.right;
    public float lifespan = 2f;  // How long the object exists before being destroyed
    private AudioSource audioSource;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
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
}

