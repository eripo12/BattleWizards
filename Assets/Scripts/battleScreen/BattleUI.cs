using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public TurnManager turnManager;
    public Button attackButton;

    void Awake()
    {
        turnManager.OnTurnChanged += HandleTurnChange;
    }

    void Start()
    {
        attackButton.onClick.AddListener(PlayerAttack);
        attackButton.interactable = (turnManager.currentTurn == TurnManager.Turn.Player);
    }

    void HandleTurnChange(TurnManager.Turn newTurn)
    {
        if (newTurn == TurnManager.Turn.Player && !turnManager.isTurnInProgress)
        {
            attackButton.interactable = true;
            Debug.Log("Button enabled for player's turn");
        }
        else
        {
            attackButton.interactable = false;
            Debug.Log("Button disabled for enemy's turn");
        }
    }

    void PlayerAttack()
    {
        if (turnManager.currentTurn == TurnManager.Turn.Player && !turnManager.isTurnInProgress)
        {
            turnManager.player.Attack(turnManager.enemy);
            turnManager.EndTurn();
        }
    }
}





