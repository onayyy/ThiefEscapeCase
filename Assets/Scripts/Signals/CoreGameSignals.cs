using UnityEngine;
using UnityEngine.Events;
using Pixelplacement;

namespace Signals
{
    public class CoreGameSignals : Singleton<CoreGameSignals>
    {
        public UnityAction OnRopeConnection = delegate { };
        public UnityAction OnRopeUnConnection = delegate { };
        public UnityAction OnRopeUnLocked = delegate { };

        public UnityAction<int, Collider, int> OnObstacleDetected = delegate { };
        public UnityAction<int, int> OnFinishDetected = delegate { };
        public UnityAction<Vector3[], int> OnMoveThieves = delegate { };

        public UnityAction<Transform> OnParticlePlay = delegate { };

        public UnityAction OnLevelCompleted = delegate { };
        public UnityAction OnLevelFailed = delegate { };

        public UnityAction OnRestartLevel = delegate { };

    }
}


