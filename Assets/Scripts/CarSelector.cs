using System.Collections;
using UnityEngine;

public class CarSelector : MonoBehaviour
{
    [SerializeField] private float _slotSize = 100f;
    [Tooltip("Time for smoothing the movement.")]
    [SerializeField] private float _smoothTime = 0.3f;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private GameObject _previousButton;

    private int _selectedIndex = 0;
    private readonly int _minIndex = 0;
    private int _maxIndex;
    private Vector3 _targetPosition;
    private Vector3 _velocity = Vector3.zero; // Velocity for SmoothDamp.
    private readonly float _threshold = 0.01f; // Threshold to check if movement is complete.

    private void Start()
    {
        _maxIndex = transform.childCount - 1;
    }
    public void Next()
    {
        _targetPosition = transform.position + Vector3.forward * _slotSize;
        StartCoroutine(MoveToTarget());

        if (_selectedIndex == _minIndex)
        {
            _previousButton.SetActive(true);
        }

        _selectedIndex++;

        if (_selectedIndex == _maxIndex)
        {
            _nextButton.SetActive(false);
        }
    }

    public void Previous()
    {
        _targetPosition = transform.position - Vector3.forward * _slotSize;
        StartCoroutine(MoveToTarget());

        if (_selectedIndex == _maxIndex)
        {
            _nextButton.SetActive(true);
        }

        _selectedIndex--;

        if (_selectedIndex == _minIndex)
        {
            _previousButton.SetActive(false);
        }

    }

    public void Select()
    {
        PlayerPrefs.SetInt("SelectedIndex", _selectedIndex);
        Debug.Log(_selectedIndex);
    }

    private IEnumerator MoveToTarget()
    {

        while (Mathf.Abs(transform.position.z - _targetPosition.z) > _threshold)
        {
            transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _velocity, _smoothTime);
            yield return null;
        }

        // Set the final position to eliminate any innacuracy.
        transform.position = _targetPosition;
    }
}
