using UnityEngine;
using System;
using System.Collections;

public class TurnManager : MonoBehaviour
{
    public enum Turn { Player, Enemy }
    public Turn currentTurn = Turn.Player;

    public Actor player;
    public Actor enemy;
    public float enemyTurnDuration = 5f;

    public event Action<Turn> OnTurnChanged;

    // Flag to track if a turn is in progress
    public bool isTurnInProgress = false;

    private void Start()
    {
        // Initially set the turn to Player's turn
        SetTurn(Turn.Player);
    }

    void Update()
    {
        if (currentTurn == Turn.Enemy && !isTurnInProgress)
        {
            StartCoroutine(HandleEnemyTurn());
        }
    }

    IEnumerator HandleEnemyTurn()
    {
        isTurnInProgress = true;
        Debug.Log("Enemy's turn started");

        enemy.GetComponent<EnemyBehavior>().TakeTurn();

        yield return new WaitForSeconds(enemyTurnDuration);

        Debug.Log("Enemy's turn ended");
        isTurnInProgress = false;
        SetTurn(Turn.Player);
    }

    public void EndTurn()
    {
        if (currentTurn == Turn.Player)
        {
            SetTurn(Turn.Enemy);
        }
        else
        {
            SetTurn(Turn.Player);
        }
    }

    private void SetTurn(Turn newTurn)
    {
        currentTurn = newTurn;
        Debug.Log("Current turn set to: " + currentTurn); // Added Debug
        OnTurnChanged?.Invoke(currentTurn);
    }
}




