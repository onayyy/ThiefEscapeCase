using System.Collections.Generic;
using UnityEngine;
using Signals;
using DG.Tweening;
using Controllers;

namespace Managers
{
    public class RobberManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> robberList = new List<GameObject>();

        private int robberIndex = 0;
        private int robberObstacleCounter = 0;
        private int getRobberListCount = 0;
        private int LoopAmount = 0;
        private int j = 0;

        private void Awake()
        {
            GameManager.Instance.GetRobberList = robberList;
            getRobberListCount = robberList.Count;

            for (int i = 0; i < robberList.Count; i++)
            {
                robberList[i].GetComponent<RobberController>().Id = i;
            }
        }

        private void OnEnable()
        {
            CoreGameSignals.Instance.OnMoveThieves += MoveThief;
            CoreGameSignals.Instance.OnObstacleDetected += ObstacleDetected;
            CoreGameSignals.Instance.OnRestartLevel += ResetData;
        }

        private void OnDisable()
        {
            CoreGameSignals.Instance.OnMoveThieves -= MoveThief;
            CoreGameSignals.Instance.OnObstacleDetected -= ObstacleDetected;
            CoreGameSignals.Instance.OnRestartLevel -= ResetData;
        }

     

        private void MoveThief(Vector3[] vectors, int robberCounter)
        {
            if (robberCounter >= robberIndex)
            {
                LoopAmount++;

                robberList[robberIndex].transform.DOLocalPath(vectors, 2.5f, PathType.CatmullRom, PathMode.Ignore).SetEase(Ease.Linear)
                    .OnComplete(() =>
                    {

                        CoreGameSignals.Instance.OnFinishDetected?.Invoke(j + 1, robberList.Count);
                        robberList[j].transform.DOLocalMove(GameManager.Instance.GridTransform[j].position, .25f);
                        j++;
                  
                        if (robberCounter == LoopAmount)
                        {
                            CoreGameSignals.Instance.OnRopeUnLocked?.Invoke();
                            CoreGameSignals.Instance.OnRopeConnection?.Invoke();
                        }

                    });
                robberIndex++;
            
            }


        }


        private void ObstacleDetected(int index, Collider robberCollider, int id)
         {
            robberIndex--;
            CoreGameSignals.Instance.OnParticlePlay?.Invoke(robberCollider.transform);
         }


        private void ResetData()
        {
            robberIndex = 0;
            robberObstacleCounter = 0;
            getRobberListCount = 0;
            LoopAmount = 0;
            j = 0;
        }




    }
}


