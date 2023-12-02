using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogue : MonoBehaviour
{
    [SerializeField] Text dialogueText;
    //[SerializeField] int lettersPerSecond;

    public void setText(string text)
    {
        dialogueText.text = text;
    }

   public IEnumerator typeText(string text)
    {
        dialogueText.text = "";
        foreach (var letter in text .ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f/25);
        }
    }

}
