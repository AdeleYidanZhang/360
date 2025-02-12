using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamRegister : MonoBehaviour
{
    private void OnEnable()
    {
        CamManager.Register(GetComponent<CinemachineVirtualCamera>());
    }

    private void OnDisable()
    {
        CamManager.Unregister(GetComponent<CinemachineVirtualCamera>());
    }
}
