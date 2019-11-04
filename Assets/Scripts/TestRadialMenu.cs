using UIHelpers;
using UnityEngine;

public class TestRadialMenu : MonoBehaviour
{
    public Menu menu;

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        menu.UpdatePresenter(mousePos);

        if (Input.GetMouseButtonDown(0))
            menu.SelectButton();
    }
}
