using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Signals;
using Managers;
using DG.Tweening;

namespace Controllers
{
    public class RobberController : MonoBehaviour
    {
        public int Id = 0;

        private void OnEnable()
        {
            CoreGameSignals.Instance.OnObstacleDetected += ObstacleDetected;   
        }

        private void OnDisable()
        {
            CoreGameSignals.Instance.OnObstacleDetected -= ObstacleDetected;
        }

        private void ObstacleDetected(int i, Collider robberCollider,int id)
        {
            if (gameObject.GetComponent<RobberController>().Id == id)
            {
                robberCollider.transform.DOKill();
                GameManager.Instance.GetRobberList.Remove(robberCollider.gameObject);

                if (GameManager.Instance.RobberCounter == GameManager.Instance.LoopAmountObstacle)
                {
                    CoreGameSignals.Instance.OnRopeUnLocked?.Invoke();
                    CoreGameSignals.Instance.OnRopeConnection?.Invoke();

                }
            }

            if (robberCollider.gameObject.transform.position.x < 0.1f || robberCollider.gameObject.transform.position.x > -.1f)
            {
                var tempPos = robberCollider.gameObject.transform.position;
                tempPos.x -= .05f;
                robberCollider.gameObject.transform.position = tempPos;
            }
     
            var rigidBody = robberCollider.gameObject.GetComponent<Rigidbody>();
            rigidBody.AddForce(new Vector3(robberCollider.gameObject.transform.position.x * 7.5f, -.1f, 0), ForceMode.VelocityChange);

            StartCoroutine(DestroyRobber(robberCollider));
        }

        private IEnumerator DestroyRobber(Collider collider)
        {
            yield return new WaitForSeconds(2f);
            Destroy(collider.gameObject);
        }
    }
}


