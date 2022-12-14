using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Enums;
using Pixelplacement;

namespace Signals
{
    public class UISignals : Singleton<UISignals>
    {
        public UnityAction<UIPanels> OnOpenPanel;
        public UnityAction<UIPanels> OnClosePanel;
    }
}


