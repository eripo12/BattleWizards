using UnityEngine;
using System;

public class TurnManager : MonoBehaviour
{
    // Reference for editing the dialogue box
    [SerializeField] BattleDialogue dialogueText;

    public enum Turn { Player, Enemy }
    public Turn currentTurn = Turn.Player;

    public Actor player;
    public Actor enemy;

    public event Action<Turn> OnTurnChanged;

    // Flag to track if a turn is in progress
    public bool isTurnInProgress = false;

    // Field to keep track of the turn count
    public int turnCount = 0;

    private void Start()
    {
        // Initially set the turn to Player's turn
        SetTurn(Turn.Player);

        StartCoroutine(dialogueText.typeText("An enemy approaches..."));
    }

    void Update()
    {
        if (currentTurn == Turn.Enemy && !isTurnInProgress)
        {
            isTurnInProgress = true;
            Debug.Log("Enemy's turn started");

            enemy.GetComponent<EnemyBehavior>().TakeTurn();
        }
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
    turnCount++; 
    isTurnInProgress = false; // Ensure this is set before calling OnTurnChanged
    Debug.Log("SetTurn called. New turn: " + currentTurn);
    OnTurnChanged?.Invoke(currentTurn);
}

}



