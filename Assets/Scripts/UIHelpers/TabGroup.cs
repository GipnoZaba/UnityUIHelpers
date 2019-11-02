using System;
using System.Collections.Generic;
using UnityEngine;

namespace UIHelpers
{
    public class TabGroup : MonoBehaviour
    {
        public Color colorDefault;
        public Color colorOnHover;
        public Color colorOnSelected;
        
        [SerializeField] private List<TabButton> _tabButtons;
        [SerializeField] private List<GameObject> _tabWindows;

        private int _size;
        private TabButton _activeButton;

        private void Awake()
        {
            InitButtons();
            SetMinSize();
        }

        public void OnTabEnter(TabButton tabButton)
        {
            int index = _tabButtons.IndexOf(tabButton);
            if (index >= _size) return;

            if (_activeButton != tabButton)
                tabButton.image.color = colorOnHover;
        }

        public void OnTabClick(TabButton tabButton)
        {
            int index = _tabButtons.IndexOf(tabButton);
            if (index >= _size) return;

            if (_activeButton != null)
            {
                _tabWindows[_tabButtons.IndexOf(_activeButton)].SetActive(false);
                _activeButton.Deselect();                
            }

            if (_activeButton != null)
                _activeButton.image.color = colorDefault;
            
            _activeButton = _tabButtons[index];
            _activeButton.Select();
            _activeButton.image.color = colorOnSelected;
            
            _tabWindows[index].SetActive(true);
        }
        
        public void OnTabExit(TabButton tabButton)
        {
            int index = _tabButtons.IndexOf(tabButton);
            if (index >= _size) return;

            if (_activeButton != tabButton)
                tabButton.image.color = colorDefault;
        }

        private void InitButtons()
        {
            foreach (var button in _tabButtons)
            {
                button.tabGroup = this;
            }
        }

        private void SetMinSize()
        {
            _size = Math.Min(_tabButtons.Count, _tabWindows.Count);
        }
    }
}