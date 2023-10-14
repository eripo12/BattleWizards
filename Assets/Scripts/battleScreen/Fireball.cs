using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Duration after which the fireball will be destroyed
    public float lifetime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}

