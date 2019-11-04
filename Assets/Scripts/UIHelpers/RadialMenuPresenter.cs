using System.Collections.Generic;
using UnityEngine;

namespace UIHelpers
{
    public class RadialMenuPresenter : MenuPresenter
    {
        public override void InitializeItems(List<MenuItem> menuItems)
        {
            this.menuItems = menuItems;

            float rotationalIncrementalValue = 360f / menuItems.Count;
            float currentRotationValue = 0;
            float fillPercentage = 1f / menuItems.Count;
            
            for (int i = 0; i < menuItems.Count; i++)
            {
                GameObject menuElementGo = Instantiate(menuElementPrefab, transform);
                menuElementGo.name = $"Item {i}: {currentRotationValue}";

                MenuElement menuButton = menuElementGo.GetComponent<MenuElement>();
                menuButton.buttonRectTransform.localPosition = Vector3.zero;
                menuButton.buttonRectTransform.localRotation = Quaternion.Euler(0,0,-currentRotationValue);
                menuButton.buttonRectTransform.localScale = Vector3.one;
                
                menuButton.backgroundImage.fillAmount = fillPercentage;

                menuButton.iconImage.sprite = menuItems[i].icon;
                menuButton.iconRectTransform.localRotation = Quaternion.Euler(0,0, rotationalIncrementalValue / 2 + rotationalIncrementalValue * i);
                menuButton.iconAnchor.localRotation = Quaternion.Euler(0,0, -rotationalIncrementalValue / 2);

                this.menuItems[i].menuElement = menuButton;
                
                currentRotationValue += rotationalIncrementalValue;
            }
        }
        
        public override void UpdateSelectedItem(Vector2 mousePosition)
        {
            float rotationalIncrementalValue = 360f / menuItems.Count;

            UpdateSelectionAngle(mousePosition);

            previousMenuItemIndex = currentMenuItemIndex;
            currentMenuItemIndex = (int) (currentSelectionAngle / rotationalIncrementalValue);
            
            menuItems[previousMenuItemIndex].menuElement.backgroundImage.color = Color.white;
            menuItems[currentMenuItemIndex].menuElement.backgroundImage.color = Color.cyan;
        }

        public override MenuItem GetSelectedItem()
        {
            return menuItems[currentMenuItemIndex];
        }

        public override void SelectItem()
        {
            onMenuItemSelected?.Invoke(menuItems[currentMenuItemIndex]);
        }

        private void UpdateSelectionAngle(Vector2 mousePosition)
        {
            currentSelectionAngle = 90f + Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
            currentSelectionAngle = 360 - ((currentSelectionAngle + 360f) % 360);
        }
    }
}
