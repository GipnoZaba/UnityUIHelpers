using System.Collections.Generic;
using UnityEngine;

namespace UIHelpers
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private List<MenuItem> _menuItems = new List<MenuItem>();
        [SerializeField] private MenuPresenter _menuPresenter;

        private void Awake()
        {
            if (_menuPresenter != null)
            {
                _menuPresenter.AddActionOnSelect(AddActionOnSelect);
                _menuPresenter.InitializeItems(_menuItems);
            }
        }

        public void UpdatePresenter(Vector2 mousePosition)
        {
            _menuPresenter.UpdateSelectedItem(mousePosition);
        }
        
        public void SelectButton()
        {
            _menuPresenter.SelectItem();
        }

        private void AddActionOnSelect(MenuItem menuItem)
        {
            Debug.Log(menuItem.name);
        }
    }
}
