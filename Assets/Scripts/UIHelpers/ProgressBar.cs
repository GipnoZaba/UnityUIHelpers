using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIHelpers
{
    [ExecuteInEditMode]
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _maskImage;
        [SerializeField] private Image _barImage;
        [SerializeField] private Image _progressIcon;
        [Space(20)] 
        [SerializeField] private TextMeshProUGUI _textMeshNormalised;
        [SerializeField] private TextMeshProUGUI _textMeshValue;
        [Space(20)]
        [SerializeField] private float _minimumValue;
        [SerializeField] private float _maximumValue;
        [SerializeField] private int _stepValue = 1;
        [SerializeField] private float _currentValue;
        [Space(20)]
        [SerializeField] private Gradient _barGradient;
        [SerializeField] private Gradient _progressPointGradient;

        private Vector3 _barProgressStart;
        private Vector3 _barProgressEnd;
        
        private bool _isMaskImage, _isBarImage, _isProgressIconImage, _isTextMeshNormalised, _isTextMeshValue;

        private void Awake()
        {
            CheckReferencesForNull();
        }

        private void CheckReferencesForNull()
        {
            _isMaskImage = _maskImage != null;
            _isBarImage = _barImage != null;
            _isProgressIconImage = _progressIcon != null;
            _isTextMeshNormalised = _textMeshNormalised != null;
            _isTextMeshValue = _textMeshValue != null;
        }

        public void SetFillAmount(float fillAmount)
        {
            if (_isMaskImage == false || _isBarImage == false)
                return;
            
            fillAmount = CalculateFillFromValue(fillAmount);

            _maskImage.fillAmount = fillAmount;
            _barImage.color = _barGradient.Evaluate(fillAmount);
            
            AdjustProgressPoint(fillAmount);
            UpdateText(fillAmount);
        }

        private void AdjustProgressPoint(float fillAmount)
        {
            if (_isProgressIconImage == false)
                return;

            _progressIcon.color = _progressPointGradient.Evaluate(fillAmount);
            _progressIcon.rectTransform.position = Vector3.Lerp(_barProgressStart, _barProgressEnd, fillAmount);
        }

        private void UpdateText(float fillAmount)
        {
            if (_isTextMeshNormalised)
            {
                _textMeshNormalised.SetText(Math.Round(fillAmount, 2).ToString());
            }

            if (_isTextMeshValue)
            {
                _textMeshValue.SetText(Math.Round(_currentValue).ToString());
            }
        }

        private float CalculateFillFromValue(float fillAmount)
        {
            _currentValue = fillAmount;
            float steppedValue = (int) fillAmount / _stepValue * _stepValue;

            fillAmount = Mathf.InverseLerp(_minimumValue, _maximumValue, steppedValue);
            return fillAmount;
        }

        private void CalculateBarEnds()
        {
            Vector3[] corners = new Vector3[4];
            _maskImage.rectTransform.GetWorldCorners(corners);
            _barProgressStart = (corners[0] + corners[1]) / 2;
            _barProgressEnd = (corners[2] + corners[3]) / 2;
        }

        private void OnValidate()
        {
            CheckReferencesForNull();
            CalculateBarEnds();
            
            if (_stepValue == 0)
                _stepValue = 1;

            _currentValue = _currentValue >= _maximumValue ? _maximumValue : _currentValue;
            _currentValue = _currentValue <= _minimumValue ? _minimumValue : _currentValue;

            SetFillAmount(_currentValue);
        }
    }
}