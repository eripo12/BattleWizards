using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HostileNPC : MonoBehaviour, Interactable
{
    //private GameObject PW;
    //private GameObject PMP;

    public void Interact()
   {
        //PW = GameObject.Find("PlayerWizard");
        //PMP = GameObject.Find("PlayerMovePoint");
        //PW.SetActive(false);
        //PMP.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
}
