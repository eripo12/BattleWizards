using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float fireballSpeed = 10f;
    public Vector2 fireballDirection = Vector2.right;
    public int fireballDamage = 20; 

    public void FireballAttack()
    {
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        fireball.GetComponent<Rigidbody2D>().velocity = fireballDirection.normalized * fireballSpeed;

        Fireball fireballScript = fireball.GetComponent<Fireball>();
        if (fireballScript != null)
        {
            fireballScript.damage = fireballDamage;
        }

        if (fireballDirection.x < 0)
            fireball.transform.localScale = new Vector3(-1, 1, 1);
    }
}

