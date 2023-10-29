using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMovePoint : MonoBehaviour
{
    public static KeepMovePoint instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

}
