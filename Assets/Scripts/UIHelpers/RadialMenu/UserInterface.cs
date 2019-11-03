using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIHelpers.RadialMenu
{
    public class UserInterface : MonoBehaviour
    {
        [Header("GENERAL")] 
        public Camera cameraUI;
        public GameObject backgroundPanel;
        public GameObject circleMenuElementPrefab;
        public bool useGradient;

        [Header("BUTTONS")] 
        public Color normalButtonColor;
        public Color highlightedButtonColor;
        public Gradient highlightedButtonGradient = new Gradient();

        [Header("INFORMAL CENTER")]
        public Image informalCenterBackground;
        public Text itemName;
        public Text itemDescription;
        public Image itemIcon;

        private int currentMenuItemIndex;
        private int previousMenuItemIndex;
        private float calculatedMenuIndex;
        private float currentSelectionAngle;
        private Vector3 currentMousePosition;
        private List<RadialMenuElement> menuElements = new List<RadialMenuElement>();

        private static UserInterface instance;
        public static UserInterface Instance => instance;
        public bool Active => backgroundPanel.activeSelf;

        public List<RadialMenuElement> MenuElements
        {
            get => menuElements;
            set => menuElements = value;
        }

        public void Initialize()
        {
            float rotationalIncrementalValue = 360f / menuElements.Count;
            float currentRotationValue = 0;
            float fillPercentage = 1f / menuElements.Count;

            for (int i = 0; i < menuElements.Count; i++)
            {
                GameObject menuElementGameObject = Instantiate(circleMenuElementPrefab);
                menuElementGameObject.name = i + ": " + currentRotationValue;
                menuElementGameObject.transform.SetParent(backgroundPanel.transform);

                MenuButton menuButton = menuElementGameObject.GetComponent<MenuButton>();

                menuButton.rectTransform.localScale = Vector3.one;
                menuButton.rectTransform.localPosition = Vector3.zero;
                menuButton.rectTransform.rotation = Quaternion.Euler(0f, 0f, -currentRotationValue);
                currentRotationValue += rotationalIncrementalValue;

                menuButton.backgroundImage.fillAmount = fillPercentage + 0.001f;
                menuElements[i].buttonBackgroundImage = menuButton.backgroundImage;

                menuButton.iconImage.sprite = menuElements[i].buttonIcon;
                menuButton.iconRectTrasform.rotation = Quaternion.Euler(0,0, rotationalIncrementalValue / 2);
                menuButton.iconRectTrasform.transform.parent.rotation = Quaternion.Euler(0,0, -rotationalIncrementalValue / 2 - rotationalIncrementalValue * i);
            }
            
            backgroundPanel.SetActive(false);
        }

        private void Update()
        {
            if (Active == false)
            {
                return;
            }

            GetCurrentMenuElement();

            if (Input.GetMouseButton(0))
            {
                Select();
            }
        }

        private void GetCurrentMenuElement()
        {
            float rotationalIcrementalValue = 360f / menuElements.Count;
            currentMousePosition = cameraUI.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

            currentSelectionAngle = 90f + Mathf.Atan2(currentMousePosition.y, currentMousePosition.x) * Mathf.Rad2Deg;
            currentSelectionAngle = 360 - ((currentSelectionAngle + 360f) % 360);
            currentMenuItemIndex = (int) (currentSelectionAngle / rotationalIcrementalValue);
            
            if (currentMenuItemIndex != previousMenuItemIndex)
            {
                menuElements[previousMenuItemIndex].buttonBackgroundImage.color = normalButtonColor;

                previousMenuItemIndex = currentMenuItemIndex;

                menuElements[currentMenuItemIndex].buttonBackgroundImage.color = useGradient
                    ? highlightedButtonGradient.Evaluate(1f / menuElements.Count * currentMenuItemIndex)
                    : highlightedButtonColor;
                informalCenterBackground.color =  useGradient
                    ? highlightedButtonGradient.Evaluate(1f / menuElements.Count * currentMenuItemIndex)
                    : highlightedButtonColor;

                RefreshInformalCenter();
            }
        }

        private void RefreshInformalCenter()
        {
            
        }

        private void Select()
        {
            Deactivate();
        }

        public void Activate()
        {
            if (Active)
                return;
            
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
            backgroundPanel.SetActive(true);
            RefreshInformalCenter();
        }

        public void Deactivate()
        {
            backgroundPanel.SetActive(false);
        }
    }
}
