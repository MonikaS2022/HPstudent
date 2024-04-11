using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class DayNighCycle : MonoBehaviour
{
    public TextMeshProUGUI _indexText;
    public TextMeshProUGUI _timeText;
    public TextMeshProUGUI _days;
    
   


    [System.Serializable]
    public struct DayAndNightMark
    {
        public float timeRation;
        public Color color;
        public float intensity;

    }

    [SerializeField] private DayAndNightMark[] _marks;
    [SerializeField] private float _cycleLenght = 24; // in sec
    [SerializeField] private Light _light;


    private const float _TIME_CHECK_EPSILON = 0.1f;

    private float _currentCyckelTime;
    private int _currentMarkIndex, _nextMarkIndex;
    private float _currentMarkTime, _nextMarkTime;

    private int days = 1;



    // Start is called before the first frame update
    void Start()
    {
        _currentMarkIndex = -1;
        _CycleMarks();
        
    }

    // Update is called once per frame
    void Update()
    {
        _currentCyckelTime = (_currentCyckelTime + Time.deltaTime) % _cycleLenght;
        if(Mathf.Abs(_currentCyckelTime - _nextMarkTime) < _TIME_CHECK_EPSILON)
        {
            DayAndNightMark next = _marks[_nextMarkIndex];
            _light.color = next.color;
            _light.intensity = next.intensity;

            _CycleMarks();

            if (_currentMarkIndex == 0)
            {
                days++;
            }
        }
       

       
        
        _indexText.text = "IndexText " + _currentMarkIndex.ToString();
        _timeText.text = "TimeText: " + _currentCyckelTime.ToString();
        _days.text = "Day: " + days.ToString();

    }

    private void _CycleMarks()
    {
        _currentMarkIndex = (_currentMarkIndex + 1) % _marks.Length;
        _nextMarkIndex = (_currentMarkIndex + 1) % _marks.Length;
        _currentMarkTime = _marks[_currentMarkIndex].timeRation * _cycleLenght;
        _nextMarkTime = _marks[_nextMarkIndex].timeRation * _cycleLenght;
    }
}
