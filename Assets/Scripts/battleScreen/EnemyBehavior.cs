using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private TurnManager turnManager;
    private Actor actor;

    private void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
        actor = GetComponent<Actor>();
    }

    public void TakeTurn()
    {
        // For simplicity, our enemy will just attack the player and end its turn
        actor.Attack(turnManager.player);
        turnManager.EndTurn();
    }
}

