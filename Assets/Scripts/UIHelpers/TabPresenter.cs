using UnityEngine;

namespace UIHelpers
{
    public abstract class TabPresenter : MonoBehaviour
    {
        public void Present(TabButton button, GameObject window)
        {
            switch (button.buttonState)
            {
                case TabButtonState.Idle:
                    PresentIdle(button, window);
                    break;
                case TabButtonState.Hover:
                    PresentHover(button, window);
                    break;
                case TabButtonState.Selected:
                    PresentSelected(button, window);
                    break;
            }
        }

        protected abstract void PresentIdle(TabButton button, GameObject window);
        protected abstract void PresentHover(TabButton button, GameObject window);
        protected abstract void PresentSelected(TabButton button, GameObject window);
    }
}
