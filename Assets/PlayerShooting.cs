using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float fireballSpeed = 10f;
    public Vector2 fireballDirection = Vector2.right;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShootFireball();
        }
    }

    void ShootFireball()
    {
        // Instantiate a fireball and set its direction
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        fireball.GetComponent<Rigidbody2D>().velocity = fireballDirection.normalized * fireballSpeed;

        // If you want the fireball to face its direction
        if(fireballDirection.x < 0)
            fireball.transform.localScale = new Vector3(-1, 1, 1);
    }
}
