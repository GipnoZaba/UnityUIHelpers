using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIHelpers
{
    [RequireComponent(typeof(Image))]
    public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        public Image backgroundImage;
        
        [SerializeField] private UnityEvent onSelect;
        [SerializeField] private UnityEvent onDeselect;

        [HideInInspector] public TabButtonState buttonState = TabButtonState.Idle;
        [HideInInspector] public TabGroup tabGroup;

        private void Awake()
        { 
            backgroundImage = GetComponent<Image>();
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (tabGroup != null)
                tabGroup.OnTabEnter(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (tabGroup != null)
                tabGroup.OnTabClick(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (tabGroup != null)
                tabGroup.OnTabExit(this);
        }

        public void Select()
        {
            onSelect?.Invoke();
        }

        public void Deselect()
        {
            onDeselect?.Invoke();
        }
    }

    public enum TabButtonState
    {
        Idle,
        Hover,
        Selected
    }
}
