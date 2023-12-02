using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    // Reference for editing the dialogue box
    [SerializeField] BattleDialogue dialogueText;

    public TurnManager turnManager;
    public Button fireballButton;
    public Button waterBlastButton;
    public Button lightningBoltButton;
    public Button healButton;
    public GameObject healEffectPrefab;


    // Reference to the prefabs
    public GameObject waterBlastPrefab;
    public GameObject lightningBoltPrefab;

    private int lastHealTurn = -2;  // To track when the heal was last used

    void Awake()
    {
        turnManager.OnTurnChanged += HandleTurnChange;
    }

    void Start()
    {
        fireballButton.onClick.AddListener(PlayerFireballAttack);
        waterBlastButton.onClick.AddListener(PlayerWaterBlast);
        lightningBoltButton.onClick.AddListener(PlayerLightningBolt);
        healButton.onClick.AddListener(PlayerHeal);

        UpdateButtons();
    }

    void HandleTurnChange(TurnManager.Turn newTurn)
    {
        Debug.Log("HandleTurnChange called. New turn: " + newTurn);
        UpdateButtons();
    }

    void UpdateButtons()
    {
        bool isPlayerTurn = turnManager.currentTurn == TurnManager.Turn.Player && !turnManager.isTurnInProgress;
        Debug.Log("Updating buttons. Player's turn: " + isPlayerTurn);

        fireballButton.interactable = isPlayerTurn;
        waterBlastButton.interactable = isPlayerTurn;
        lightningBoltButton.interactable = isPlayerTurn;
        healButton.interactable = isPlayerTurn && (turnManager.turnCount - lastHealTurn >= 2);
        UpdateButtons(turnManager.currentTurn);
    }
    void UpdateButtons(TurnManager.Turn currentTurn)
{
    bool isPlayerTurn = currentTurn == TurnManager.Turn.Player && !turnManager.isTurnInProgress;
    Debug.Log("Updating buttons. Player's turn: " + isPlayerTurn);

    fireballButton.interactable = isPlayerTurn;
    waterBlastButton.interactable = isPlayerTurn;
    lightningBoltButton.interactable = isPlayerTurn;
    healButton.interactable = isPlayerTurn && (turnManager.turnCount - lastHealTurn >= 2);
}

    void PlayerFireballAttack()
    {       
        turnManager.player.GetComponent<PlayerShooting>().FireballAttack();
        turnManager.enemy.TakeDamage(5);
        turnManager.EndTurn();
    }

    void PlayerWaterBlast()
    {
        Instantiate(waterBlastPrefab, turnManager.player.transform.position, Quaternion.identity);
        turnManager.enemy.TakeDamage(20);
        turnManager.EndTurn();
    }

    void PlayerLightningBolt()
    {
        Instantiate(lightningBoltPrefab, turnManager.player.transform.position, Quaternion.identity);
        turnManager.enemy.TakeDamage(15);
        turnManager.EndTurn();
    }

   void PlayerHeal()
{

    Instantiate(healEffectPrefab, turnManager.player.transform.position, Quaternion.identity);

    
    turnManager.player.currentHealth = Mathf.Min(turnManager.player.maxHealth, turnManager.player.currentHealth + 20);
    StartCoroutine(dialogueText.typeText("Player heals " + 20 + " HP."));
    turnManager.player.healthBar.SetHealth(turnManager.player.currentHealth); // Update the health bar
    lastHealTurn = turnManager.turnCount;
    turnManager.EndTurn();
}

}








