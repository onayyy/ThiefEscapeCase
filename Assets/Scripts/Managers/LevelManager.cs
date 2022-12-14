using System.Collections;
using UnityEngine;
using Signals;

namespace Managers
{

    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject levelPrefab;

        private GameObject currentLevel;

        private void Awake()
        {
            GenerateLevel();
        }

        private void OnEnable()
        {
            CoreGameSignals.Instance.OnRestartLevel += RestartLevel;
        }

        private void OnDisable()
        {
            CoreGameSignals.Instance.OnRestartLevel += RestartLevel;
        }

        private void RestartLevel()
        {
            StartCoroutine(RestartLevelRoutine());
        }

        private IEnumerator RestartLevelRoutine()
        {
            if (currentLevel != null)
            {
                Destroy(currentLevel);
            }

            yield return new WaitForEndOfFrame();

            GenerateLevel();
        }

        private void GenerateLevel()
        {
            currentLevel = Instantiate(levelPrefab, transform);
        }

    }
}

