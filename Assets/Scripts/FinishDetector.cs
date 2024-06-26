using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDetector : MonoBehaviour
{
    [SerializeField] private GameObject _finishScreen;

    private void OnTriggerEnter()
    {
        _finishScreen.SetActive(true);
    }
}
