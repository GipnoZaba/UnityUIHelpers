using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIHelpers
{
    [RequireComponent(typeof(Image))]
    public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        public UnityEvent onSelect;
        public UnityEvent onDeselect;
        
        [HideInInspector] public Image image;
        [HideInInspector] public TabGroup tabGroup;

        private void Awake()
        {
            image = GetComponent<Image>();
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            tabGroup.OnTabEnter(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            tabGroup.OnTabClick(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
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
}
