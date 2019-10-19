using UnityEngine;
using UnityEngine.UI;

namespace UIHelpers
{
    [ExecuteInEditMode]
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] protected Image _maskImage;
        [SerializeField] protected Image _barImage;
        
        [SerializeField] protected float _minimumValue;
        [SerializeField] protected float _maximumValue;
        [SerializeField] protected int _stepValue = 1;
        [SerializeField] protected float _currentValue;
        
        [SerializeField] protected Image _progressIcon;
        [SerializeField] protected Gradient _gradient;

        private Vector3 _barLeftSide;
        private Vector3 _barRightSide;
        
        private bool _isMaskImage, _isBarImage, _isProgressIconImage;

        private void OnAwake()
        {
            CheckReferencesForNull();
        }

        private void CheckReferencesForNull()
        {
            _isMaskImage = _maskImage != null;
            _isBarImage = _barImage != null;
            _isProgressIconImage = _progressIcon != null;
        }

        protected virtual void SetFillAmount(float fillAmount)
        {
            if (_isMaskImage == false || _isBarImage == false)
                return;
            
            _currentValue = fillAmount;
            float steppedValue = (int) fillAmount / _stepValue * _stepValue;
            
            fillAmount = Mathf.InverseLerp(_minimumValue, _maximumValue, steppedValue);
            
            _maskImage.fillAmount = fillAmount;
            _barImage.color = _gradient.Evaluate(fillAmount);

            if (_isProgressIconImage == false)
                return;
            _progressIcon.rectTransform.position = Vector3.Lerp(_barLeftSide, _barRightSide, fillAmount);
        }

        private void SetBarSides()
        {
            Vector3[] corners = new Vector3[4];
            _maskImage.rectTransform.GetWorldCorners(corners);
            _barLeftSide = (corners[0] + corners[1]) / 2;
            _barRightSide = (corners[2] + corners[3]) / 2;
        }

        protected virtual void OnValidate()
        {
            CheckReferencesForNull();
            SetBarSides();
            if (_stepValue == 0)
                _stepValue = 1;

            _currentValue = _currentValue >= _maximumValue ? _maximumValue : _currentValue;
            _currentValue = _currentValue <= _minimumValue ? _minimumValue : _currentValue;

            SetFillAmount(_currentValue);
        }
    }
}