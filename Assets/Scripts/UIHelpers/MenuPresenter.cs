using System;
using System.Collections.Generic;
using UnityEngine;

namespace UIHelpers
{
    public abstract class MenuPresenter : MonoBehaviour
    {
        [SerializeField] protected GameObject menuElementPrefab;
        
        protected List<MenuItem> menuItems = new List<MenuItem>();
        protected MenuItem selectedItem;
        protected int currentMenuItemIndex;
        protected int previousMenuItemIndex;
        protected float currentSelectionAngle;
        protected Action<MenuItem> onMenuItemSelected;

        public void AddActionOnSelect(Action<MenuItem> onMenuItemSelected)
        {
            this.onMenuItemSelected = onMenuItemSelected;
        }
        
        public abstract void UpdateSelectedItem(Vector2 mousePosition);
        public abstract MenuItem GetSelectedItem();
        public abstract void InitializeItems(List<MenuItem> menuItems);
        public abstract void SelectItem();
    }
}
