using UnityEngine;

public class LightningBolt : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 direction = Vector3.right;  // Changed to Vector3 for 3D movement
    public float lifespan = 2f;  // How long the object exists before being destroyed
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
        transform.position += direction * speed * Time.deltaTime;
    }
}


