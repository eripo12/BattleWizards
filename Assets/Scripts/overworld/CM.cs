using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CM : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtCamera;
    public GameObject Player;
    // Start is called before the first frame update

    public void Awake()
    {
        cinemachineVirtCamera = GetComponent<CinemachineVirtualCamera>();
    }
    void Start()
    {
        Player = GameObject.Find("PlayerWizard");
        cinemachineVirtCamera.Follow = Player.transform;
    }

}

