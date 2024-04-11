using System;
using System.Collections;
using UnityEngine;

public class TimeControll : MonoBehaviour
{
    [SerializeField] private float _dayLenght; //in sec

    private TimeSpan _currentTime;
    private float _minuteLenght => _dayLenght / WorldTimeConstants.MinutesInDay;

    private void Start()
    {
        StartCoroutine(AddMinute());
    }
    private IEnumerator AddMinute()
    {
        _currentTime += TimeSpan.FromMinutes(1);
        yield return new WaitForSeconds(_minuteLenght);
        StartCoroutine(AddMinute());
    }
}
