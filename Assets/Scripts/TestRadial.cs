using System.Collections.Generic;
using UIHelpers.RadialMenu;
using UnityEngine;

public class TestRadial : MonoBehaviour
{
    public RadialMenuElement[] menuElements;
    public RadialMenuElement[] menuElements2;

    private void Awake()
    {
        UserInterface userInterface = FindObjectOfType<UserInterface>();
        
        userInterface.MenuElements = new List<RadialMenuElement>(menuElements);
        userInterface.MenuElements.AddRange(menuElements2);
        userInterface.Initialize();
        userInterface.Activate();
    }
}
