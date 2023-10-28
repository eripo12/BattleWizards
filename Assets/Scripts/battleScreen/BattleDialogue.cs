using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogue : MonoBehaviour
{
    [SerializeField] Text dialogueText;

    public void setText(string dialog)
    {
        dialogueText.text = dialog;
    }

}
