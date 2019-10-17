using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UIHelpers
{
    [ExecuteInEditMode]
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _maskImage;
        [SerializeField] private Image _barImage;
        
        [SerializeField] private float _minimumValue;
        [SerializeField] private float _maximumValue;
        [SerializeField] private float _currentValue;
        [SerializeField] private Gradient _gradient;

        private void SetFillAmount(float fillAmount)
        {
            _currentValue = fillAmount;
            fillAmount = Mathf.InverseLerp(_minimumValue, _maximumValue, fillAmount);
            _maskImage.fillAmount = fillAmount;
            _barImage.color = _gradient.Evaluate(fillAmount);
        }

        private void OnValidate()
        {
            _currentValue = _currentValue >= _maximumValue ? _maximumValue : _currentValue;
            _currentValue = _currentValue <= _minimumValue ? _minimumValue : _currentValue;

            SetFillAmount(_currentValue);
        }
        
            
#if UNITY_EDITOR
        [MenuItem("GameObject/UI/Linear Progress Bar")]
        public static void AddLinearProgressBar()
        {
            GameObject barObj = Instantiate(
                Resources.Load<GameObject>("UIHelpers/Progress Bar Linear"),
                Selection.activeGameObject.transform, false);
            barObj.name = "Progress Bar Linear";
        }
        
        [MenuItem("GameObject/UI/Radial Progress Bar")]
        public static void AddRadialProgressBar()
        {
            GameObject barObj = Instantiate(
                Resources.Load<GameObject>("UIHelpers/Progress Bar Radial"),
                Selection.activeGameObject.transform, false);
            barObj.name = "Progress Bar Radial";
        }
#endif
    }
}