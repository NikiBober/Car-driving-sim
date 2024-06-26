using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] _carPrefabs;
    [SerializeField] private Transform _loadingPlace;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_carPrefabs[PlayerPrefs.GetInt("SelectedIndex")], _loadingPlace.position, _loadingPlace.rotation);
    }
}
