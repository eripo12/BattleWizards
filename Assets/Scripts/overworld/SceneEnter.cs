using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEnter : MonoBehaviour
{
    public string lastExitName;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("LastExitName") == lastExitName)
        {
            KeepObject.instance.transform.position = transform.position;
            KeepMovePoint.instance.transform.position = transform.position;
        }
    }

   
}
