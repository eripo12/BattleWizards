using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float fireballSpeed = 10f;
    public Vector2 fireballDirection = Vector2.right;

    public void FireballAttack()
    {
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        fireball.GetComponent<Rigidbody2D>().velocity = fireballDirection.normalized * fireballSpeed;

        if(fireballDirection.x < 0)
            fireball.transform.localScale = new Vector3(-1, 1, 1);
    }
}
