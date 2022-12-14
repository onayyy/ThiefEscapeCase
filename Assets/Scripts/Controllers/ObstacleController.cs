using UnityEngine;
using Signals;
using Managers;
using DG.Tweening;

namespace Controllers
{
    public class ObstacleController : MonoBehaviour
    {
        private void Start()
        {
            transform.DORotate(new Vector3(0f, 0f, 360f), 1.5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        }

    

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Robber"))
            {
                GameManager.Instance.LoopAmountObstacle++;
                var getRobberIndex = GameManager.Instance.GetRobberList.IndexOf(other.gameObject);

                if (getRobberIndex >= 0)
                {
                    CoreGameSignals.Instance.OnObstacleDetected?.Invoke(getRobberIndex, other, other.GetComponent<RobberController>().Id);
                }

            }
        }
    }

}

