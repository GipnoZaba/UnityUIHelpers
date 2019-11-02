using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UIHelpers
{
    public class TabGroup : MonoBehaviour
    {
        [SerializeField] private TabPresenter _presenter;
        
        [ContextMenuItem("Set from children", "AddButtonsFromChildren")]
        [SerializeField] private List<TabButton> _tabButtons;
        [SerializeField] private List<GameObject> _tabWindows;

        private void Awake()
        {
            if (_presenter == null)
                _presenter = GetComponent<TabPresenter>();
        }

        private void Start()
        {
            InitButtons();
        }

        public void OnTabEnter(TabButton tabButton)
        {
            tabButton.buttonState = tabButton.buttonState == TabButtonState.Selected
                ? TabButtonState.Selected
                : TabButtonState.Hover;

            PresentTab(tabButton);
        }

        public void OnTabClick(TabButton tabButton)
        {
            if (tabButton.buttonState == TabButtonState.Selected)
                return;
            
            DeactivateActiveTab();
            
            tabButton.buttonState = TabButtonState.Selected;
            tabButton.Select();
            _tabWindows[_tabButtons.IndexOf(tabButton)].SetActive(true);

            PresentTab(tabButton);
        }

        public void OnTabExit(TabButton tabButton)
        {
            tabButton.buttonState = tabButton.buttonState == TabButtonState.Selected
                ? TabButtonState.Selected
                : TabButtonState.Idle;
            
            PresentTab(tabButton);
        }
        
        private void PresentTab(TabButton tabButton)
        {
            if (_presenter != null)
                _presenter.Present(tabButton, _tabWindows[_tabButtons.IndexOf(tabButton)]);
        }
        
        private void DeactivateActiveTab()
        {
            for (int i = 0; i < _tabButtons.Count; i++)
            {
                if (_tabButtons[i].buttonState == TabButtonState.Selected)
                {
                    _tabButtons[i].buttonState = TabButtonState.Idle;
                    _tabButtons[i].Deselect();
                    _tabWindows[i].SetActive(false);
                    _presenter.Present(_tabButtons[i], _tabWindows[_tabButtons.IndexOf(_tabButtons[i])]);
                }
            }
        }

        private void InitButtons()
        {
            foreach (var tabButton in _tabButtons)
            {
                tabButton.tabGroup = this;
                PresentTab(tabButton);
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            ValidateWindowsList();
        }
        
        private void ValidateWindowsList()
        {
            if (_tabButtons.Count < _tabWindows.Count)
                _tabWindows = _tabWindows.Take(_tabButtons.Count).ToList();
        }

        public void AddButtonsFromChildren()
        {
            List<TabButton> buttonsInChildren = GetComponentsInChildren<TabButton>().ToList();
            _tabButtons.AddRange(buttonsInChildren.Except(_tabButtons));
            
            ValidateWindowsList();
        }
#endif
    }
}