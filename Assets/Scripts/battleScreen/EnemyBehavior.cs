using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private TurnManager turnManager;
    private Actor actor;

    // Array of prefabs that the enemy can shoot
    public GameObject[] attackPrefabs;
    
    private void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
        actor = GetComponent<Actor>();
    }

    public void TakeTurn()
    {
        // Enemy randomly selects one of its attacks
        UseRandomAttack();

        // For simplicity, our enemy will just attack the player and end its turn
        actor.Attack(turnManager.player);
        turnManager.EndTurn();
    }

    private void UseRandomAttack()
    {
        if(attackPrefabs.Length == 0)
        {
            Debug.LogWarning("No attack prefabs assigned for enemy.");
            return;
        }

        // Select a random prefab from the attackPrefabs array
        GameObject selectedAttack = attackPrefabs[Random.Range(0, attackPrefabs.Length)];

        // Instantiate the selected prefab
        Instantiate(selectedAttack, transform.position, Quaternion.identity);
    }
}

