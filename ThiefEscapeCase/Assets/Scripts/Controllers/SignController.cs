using Data.UnityObject;
using Data.ValueObject;
using TMPro;
using UnityEngine;
using Signals;
using Managers;

namespace Controllers
{
    public class SignController : MonoBehaviour
    {
        [Header("Data")] public ThiefData ThiefData;

        [SerializeField] private int thiefValue;
        [SerializeField] private TextMeshProUGUI thiefValueText;

        private void Awake()
        {
            ThiefData = GetThiefData();
            SetSignText();
        }

        private void OnEnable()
        {
            CoreGameSignals.Instance.OnFinishDetected += FinishDetected;
            CoreGameSignals.Instance.OnObstacleDetected += ObstacleDetected;
        }

        private void OnDisable()
        {
            CoreGameSignals.Instance.OnFinishDetected -= FinishDetected;
            CoreGameSignals.Instance.OnObstacleDetected -= ObstacleDetected;
        }

        private ThiefData GetThiefData() => Resources.Load<CD_Level>("Data/CD_Level").Levels[0].ThiefData[0];

        private void SetSignText()
        {
            thiefValueText.text = ThiefData.ThiefValueText + "/" + ThiefData.ThiefValue;
        }

        private void FinishDetected(int amountThief, int robberListCount)
        {
            thiefValueText.text = amountThief + "/" + ThiefData.ThiefValue;

            if (amountThief  == ThiefData.ThiefValue)
            {
                CoreGameSignals.Instance.OnLevelCompleted?.Invoke();
            }

        }

        private void ObstacleDetected(int i, Collider collider, int j)
        {
            if (GameManager.Instance.GetRobberList.Count < ThiefData.ThiefValue)
            {
                CoreGameSignals.Instance.OnLevelFailed?.Invoke();
            }
        }


    }
}


