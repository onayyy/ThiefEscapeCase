using System.Collections.Generic;
using UnityEngine;
using Managers;
using Signals;

namespace Controllers
{
    public class RopeController : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Transform startBoard;
        [SerializeField] private LineRenderer rope;
        [SerializeField] private LayerMask collMask;
        [SerializeField] private List<Vector3> ropePositions = new List<Vector3>();

        private Vector3 untieTheRope = Vector3.zero;

        private float timer = 0.1f;
        private int counter = 0;
        private int robberListCount = 0;

        private void Awake()
        {
            AddPosToRope(startBoard.position);
            robberListCount = GameManager.Instance.GetRobberList.Count;
        }

        private void Update()
        {
            UpdateRopePositions();
            LastSegmentGoToPlayerPos();

            DetectCollisionEnter();
            if (ropePositions.Count > 2) DetectCollisionExits();

            MoveThieves();

        }

        private void OnEnable()
        {
            CoreGameSignals.Instance.OnRestartLevel += ResetData;
        }

        private void OnDisable()
        {
            CoreGameSignals.Instance.OnRestartLevel -= ResetData;
        }



        #region Rope Methods

        private void DetectCollisionEnter()
        {
            RaycastHit hit;
            if (Physics.Linecast(player.position, rope.GetPosition(ropePositions.Count - 2), out hit, collMask))
            {
                ropePositions.RemoveAt(ropePositions.Count - 1);
                untieTheRope = (hit.point - hit.collider.gameObject.transform.position).normalized * .04f;
                AddPosToRope(hit.point + untieTheRope);
            }
            else
            {
                if (ropePositions.Count > 0)
                {
                    if (ropePositions[ropePositions.Count - 1] != player.position)
                    {
                        ropePositions[ropePositions.Count - 1] = player.position;
                    }
                   
                }
            }
       
        }

        private void DetectCollisionExits()
        {
            RaycastHit hit;
            if (!Physics.Linecast(player.position, rope.GetPosition(ropePositions.Count - 3), out hit, collMask))
            {
                ropePositions.RemoveAt(ropePositions.Count - 2);
            }
        }

        private void AddPosToRope(Vector3 _pos)
        {
            ropePositions.Add(_pos);
            ropePositions.Add(player.position); //Always the last pos must be the player
        }

        private void UpdateRopePositions()
        {
            rope.positionCount = ropePositions.Count;
            rope.SetPositions(ropePositions.ToArray());
        }
      
        private void LastSegmentGoToPlayerPos() 
        {
            rope.SetPosition(rope.positionCount - 1, player.position);
       
        }

        // By Ivan Moreno --- https://github.com/ivarovin/Rope-with-line-renderer

        #endregion

    
        public void MoveThieves()
        {
            if (Input.GetMouseButton(0))
            {
                if (GameManager.Instance.CanMoveThief && (robberListCount > GameManager.Instance.RobberCounter))
                {
                   
                    timer -= Time.deltaTime * 6.5f;

                    if (timer < 0)
                    {
                        GameManager.Instance.RobberCounter++;
                        CoreGameSignals.Instance.OnMoveThieves?.Invoke(ropePositions.ToArray(), GameManager.Instance.RobberCounter);
                       
                        timer = 1f;
                    }

                }
            }
        }

        private void ResetData()
        {
            timer = 0.1f;
            counter = 0;
            robberListCount = 0;
        }



    }
}


