using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using Signals;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public List<Transform> GridTransform = new List<Transform>();
        public List<GameObject> GetRobberList = new List<GameObject>();

        public Transform RefTargetTransform;

        public bool CanMoveThief = false;
        public bool TriggerFinishBoard = false;

        public int RobberCounter = 0;

        public int LoopAmountObstacle = 0;

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        private void OnEnable()
        {
            CoreGameSignals.Instance.OnRestartLevel += ResetData;
        }

        private void OnDisable()
        {
            CoreGameSignals.Instance.OnRestartLevel -= ResetData;
        }

        private void ResetData()
        {
            CanMoveThief = false;
            TriggerFinishBoard = false;
            RobberCounter = 0;
            LoopAmountObstacle = 0;
        }

    }

}

