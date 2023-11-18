using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerController : MonoBehaviour, Interactable
{

    public GameObject NPC;

    public void Interact()
    {
        NPC.GetComponent<DialogueTrigger>()?.TriggerDialogue();
    }
}
