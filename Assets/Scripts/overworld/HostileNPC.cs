using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HostileNPC : MonoBehaviour, Interactable
{
    
    public string holdPos = "";

    public void Interact()
   {
        //Sets the playerpref of lastexitname to empty so that the playerwizard sprite spawns on the same spot in the overworld
        PlayerPrefs.SetString("LastExitName", holdPos);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
}
