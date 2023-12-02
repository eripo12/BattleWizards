using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

 
public class BGMTower : MonoBehaviour
{
    public static BGMTower instance;
 
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "ForestVIllage" )
            Destroy(gameObject);
    }
}