using UnityEngine;
using Signals;
using Managers;

namespace Controllers
{
    
    public class RopeColorController : MonoBehaviour
    {
        [SerializeField] private Renderer myMaterial;

        private void OnEnable()
        {
            CoreGameSignals.Instance.OnRopeConnection += RopeConnection;
            CoreGameSignals.Instance.OnRopeUnConnection += RopeUnConnection;
            CoreGameSignals.Instance.OnMoveThieves += RopeConnectionAndMoveThieves;
        }

        private void OnDisable()
        {
            CoreGameSignals.Instance.OnRopeConnection -= RopeConnection;
            CoreGameSignals.Instance.OnRopeUnConnection -= RopeUnConnection;
            CoreGameSignals.Instance.OnMoveThieves -= RopeConnectionAndMoveThieves;
        }

        private void RopeConnection()
        {
            myMaterial.material.color = Color.green;
            GameManager.Instance.CanMoveThief = true;
        }

        private void RopeUnConnection()
        {
            myMaterial.material.color = Color.yellow;
            GameManager.Instance.CanMoveThief = false;

        }

        private void RopeConnectionAndMoveThieves(Vector3[] vectors, int i)
        {
            myMaterial.material.color = Color.black;

        }

   
    }

}

