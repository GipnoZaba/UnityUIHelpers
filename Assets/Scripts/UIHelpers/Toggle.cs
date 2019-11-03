using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIHelpers
{
    public class Toggle : MonoBehaviour, IPointerClickHandler
    {
        public UnityEvent onOn;
        public UnityEvent onOff;
        
        [SerializeField] private Image _buttonImage;
        [SerializeField] private TextMeshProUGUI _textMesh;
        
        [SerializeField] private Sprite _spriteOn;
        [SerializeField] private Sprite _spriteOff;

        private bool _isOn;

        private void ToggleButton()
        {
            _isOn = !_isOn;
            if (_isOn) onOn?.Invoke();
            if (!_isOn) onOff?.Invoke();
            
            if (_isOn)
            {
                ChangeAnchorPointRight(_textMesh.rectTransform);
                _textMesh.SetText("ON");
                
                ChangeAnchorPointLeft(_buttonImage.rectTransform);
                _buttonImage.sprite = _spriteOn;
            }
            else
            {
                ChangeAnchorPointLeft(_textMesh.rectTransform);
                _textMesh.SetText("OFF");
                
                ChangeAnchorPointRight(_buttonImage.rectTransform);
                _buttonImage.sprite = _spriteOff;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            ToggleButton();
        }

        private void ChangeAnchorPointLeft(RectTransform rectTransform)
        {
            rectTransform.anchorMin =  new Vector2(0,0.5f);
            rectTransform.anchorMax =  new Vector2(0,0.5f);
            rectTransform.pivot =  new Vector2(0,0.5f);
        }
        
        private void ChangeAnchorPointRight(RectTransform rectTransform)
        {
            rectTransform.anchorMin =  new Vector2(1,0.5f);
            rectTransform.anchorMax =  new Vector2(1,0.5f);
            rectTransform.pivot =  new Vector2(1,0.5f);
        }
    }
}
