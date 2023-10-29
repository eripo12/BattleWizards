using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private GameObject PW;
    private GameObject PMP;
    // Start is called before the first frame update
    void Start()
    {
        PW = GameObject.Find("PlayerWizard");
        PMP = GameObject.Find("PlayerMovePoint");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(PW);
        Destroy(PMP);
    }
}
