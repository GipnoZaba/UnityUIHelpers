using System.Collections.Generic;
using UIHelpers.RadialMenu;
using UnityEngine;

public class TestRadial : MonoBehaviour
{
    public RadialMenuElement[] menuElements;

    private void Awake()
    {
        UserInterface userInterface = FindObjectOfType<UserInterface>();
        
        userInterface.MenuElements = new List<RadialMenuElement>(menuElements);
        userInterface.Initialize();
        userInterface.Activate();
    }
}
