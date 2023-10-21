using UnityEngine;

public class LightningBolt : MonoBehaviour
{
    public float lifespan = 1f;  // How long the object exists before being destroyed

    private void Start()
    {
        Destroy(gameObject, lifespan);
    }
}

