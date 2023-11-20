using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HostileNPC : MonoBehaviour, Interactable
{
   public void Interact()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
}
