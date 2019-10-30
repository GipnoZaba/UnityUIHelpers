using UIHelpers;
using UnityEngine;

public class TestChangeValue : MonoBehaviour
{

    private ProgressBar[] _progressBars;
    private float _currentValue;

    private void Awake()
    {
        _progressBars = FindObjectsOfType<ProgressBar>();
        if (_progressBars.Length == 0)
            Destroy(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _currentValue += 10;
            if (_currentValue < 0) _currentValue = 0;
            if (_currentValue > 100) _currentValue = 100;
            ChangeProgressBarsValues(_currentValue);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _currentValue -= 10;
            if (_currentValue < 0) _currentValue = 0;
            if (_currentValue > 100) _currentValue = 100;
            ChangeProgressBarsValues(_currentValue);
        }

        if (_currentValue < 0) _currentValue = 0;
        if (_currentValue > 100) _currentValue = 100;
    }

    public void ChangeProgressBarsValues(float value)
    {
        foreach (var bar in _progressBars)
        {
            bar.SetFillFromValue(value);
        }
    }
}
