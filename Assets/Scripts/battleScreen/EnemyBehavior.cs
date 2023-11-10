using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour
{
    private TurnManager turnManager;
    private Actor actor;
    public GameObject[] attackPrefabs;
    public float attackDelay = 10f;  // Delay for the enemy attack

    private void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
        actor = GetComponent<Actor>();
    }

    public void TakeTurn()
{
    if(gameObject.activeSelf)
    {
        StartCoroutine(DelayedAttack());
    }
}


    IEnumerator DelayedAttack()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(attackDelay);

        // Execute a random attack
        UseRandomAttack();

        // Then, perform the actual attack on the player
        actor.Attack(turnManager.player);

        // Wait a moment before ending the turn to allow animations or effects to complete
        yield return new WaitForSeconds(1f);

        // Finally, end the enemy's turn
        turnManager.EndTurn();
        turnManager.isTurnInProgress = false;
    }

    private void UseRandomAttack()
    {
        if (attackPrefabs.Length == 0)
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



