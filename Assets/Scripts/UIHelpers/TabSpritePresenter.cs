using System.Collections.Generic;
using UnityEngine;

namespace UIHelpers
{
    public class TabSpritePresenter : TabPresenter
    {
        [SerializeField] private Sprite _spriteIdle;
        [SerializeField] private Sprite _spriteHover;
        [SerializeField] private Sprite _spriteSelect;

        protected override void PresentIdle(TabButton button, GameObject window)
        {
            button.backgroundImage.sprite = _spriteIdle;
        }

        protected override void PresentHover(TabButton button, GameObject window)
        {
            button.backgroundImage.sprite = _spriteHover;
        }

        protected override void PresentSelected(TabButton button, GameObject window)
        {
            button.backgroundImage.sprite = _spriteSelect;
        }
    }
}
