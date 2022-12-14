using UnityEngine;
using Controllers;
using Signals;
using Enums;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIPanelController uIPanelController;

        private void OnEnable()
        {
            UISignals.Instance.OnOpenPanel += OpenPanel;
            UISignals.Instance.OnClosePanel += ClosePanel;
            CoreGameSignals.Instance.OnLevelCompleted += LevelCompleted;
            CoreGameSignals.Instance.OnLevelFailed += LevelFailed;
        }

        private void OnDisable()
        {
            UISignals.Instance.OnOpenPanel -= OpenPanel;
            UISignals.Instance.OnClosePanel -= ClosePanel;
            CoreGameSignals.Instance.OnLevelCompleted += LevelCompleted;
            CoreGameSignals.Instance.OnLevelFailed += LevelFailed;
        }

        private void OpenPanel(UIPanels panelParam)
        {
            uIPanelController.OpenPanel(panelParam);
        }

        private void ClosePanel(UIPanels panelParam)
        {
            uIPanelController.ClosePanel(panelParam);
        }

        private void LevelCompleted()
        {
            UISignals.Instance.OnClosePanel?.Invoke(UIPanels.FailPanel);
            UISignals.Instance.OnOpenPanel?.Invoke(UIPanels.WinPanel);
        }

        private void LevelFailed()
        {
            UISignals.Instance.OnClosePanel?.Invoke(UIPanels.WinPanel);
            UISignals.Instance.OnOpenPanel?.Invoke(UIPanels.FailPanel);
        }

        public void RestartLevel()
        {
            UISignals.Instance.OnClosePanel?.Invoke(UIPanels.WinPanel);
            UISignals.Instance.OnClosePanel?.Invoke(UIPanels.FailPanel);
            CoreGameSignals.Instance.OnRestartLevel?.Invoke();
        }
    }
}


