using System;
using UnityEngine;

namespace UIHelpers
{
    [Serializable]
    public class MenuItem
    {
        public string name;
        public string description;
        public Sprite icon;
        public MenuElement menuElement;
    }
}
