using UnityEngine;
using Signals;
using Managers;
using DG.Tweening;
using Lean.Touch;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private LeanDragTranslateRigidbody leanDragTranslateRigidbody;

        private void OnEnable()
        {
            CoreGameSignals.Instance.OnMoveThieves += LockedRope;
            CoreGameSignals.Instance.OnRopeUnLocked += UnLockedRope;
        }

        private void OnDisable()
        {
            CoreGameSignals.Instance.OnMoveThieves -= LockedRope;
            CoreGameSignals.Instance.OnRopeUnLocked -= UnLockedRope;
        }


        public void OnLeanFingerUpdate()
        {
            CoreGameSignals.Instance.OnRopeUnConnection?.Invoke();

            if (Vector3.Distance(transform.position, GameManager.Instance.RefTargetTransform.position) < 0.6f)
            {
                GameManager.Instance.TriggerFinishBoard = true;
            }
            else
            {
                GameManager.Instance.TriggerFinishBoard = false;
            }

        }

        public void OnLeanFingerUp()
        {
            CheckRopeConnect();

        }


        private void CheckRopeConnect()
        {
            if (Vector3.Distance(transform.position, GameManager.Instance.RefTargetTransform.position) < 0.6f)
            {
                transform.DOMove(GameManager.Instance.RefTargetTransform.position + new Vector3(0f, 0f, -GameManager.Instance.RefTargetTransform.position.z), .1f);
                CoreGameSignals.Instance.OnRopeConnection?.Invoke();
            }
        }


        private void LockedRope(Vector3[] vectors, int i)
        {
            leanDragTranslateRigidbody.enabled = false;
        }

        private void UnLockedRope()
        {
            leanDragTranslateRigidbody.enabled = true;
        }
      
    }

}

