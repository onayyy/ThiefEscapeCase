using UnityEngine;
using Signals;

namespace Managers
{
    public class ParticleManager : MonoBehaviour
    {
        [SerializeField] private ParticleSystem confetti;
        [SerializeField] private ParticleSystem blood;

        private void OnEnable()
        {
            CoreGameSignals.Instance.OnLevelCompleted += LevelComplete;
            CoreGameSignals.Instance.OnParticlePlay += ParticlePlay;
        }

        private void OnDisable()
        {
            CoreGameSignals.Instance.OnLevelCompleted -= LevelComplete;
            CoreGameSignals.Instance.OnParticlePlay += ParticlePlay;
        }

        private void LevelComplete()
        {
            confetti.Play();
        }

        private void ParticlePlay(Transform transformParam)
        {
            blood.transform.position = transformParam.position;
            blood.Play();
        }

    }
}


