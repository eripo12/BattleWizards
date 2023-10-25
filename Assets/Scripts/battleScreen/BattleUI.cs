using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public TurnManager turnManager;
    public Button fireballButton;
    public Button waterBlastButton;
    public Button lightningBoltButton;
    public Button healButton;

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
        UpdateButtons();
    }

    void UpdateButtons()
    {
        bool isPlayerTurn = turnManager.currentTurn == TurnManager.Turn.Player && !turnManager.isTurnInProgress;

        fireballButton.interactable = isPlayerTurn;
        waterBlastButton.interactable = isPlayerTurn;
        lightningBoltButton.interactable = isPlayerTurn;
        healButton.interactable = isPlayerTurn && (turnManager.turnCount - lastHealTurn >= 2);
    }

    void PlayerFireballAttack()
    {
        turnManager.player.GetComponent<PlayerShooting>().FireballAttack();
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
        turnManager.player.currentHealth = Mathf.Min(turnManager.player.maxHealth, turnManager.player.currentHealth + 20);
        turnManager.player.healthBar.SetHealth(turnManager.player.currentHealth); // Update the health bar
        lastHealTurn = turnManager.turnCount;
        turnManager.EndTurn();
    }
}








