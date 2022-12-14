using Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class UIPanelController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> panels;

        public void OpenPanel(UIPanels panelParam)
        {
            panels[(int)panelParam].SetActive(true);
        }

        public void ClosePanel(UIPanels panelParam)
        {
            panels[(int)panelParam].SetActive(false);
        }
    }
}


