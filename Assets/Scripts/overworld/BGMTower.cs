using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMTower : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
