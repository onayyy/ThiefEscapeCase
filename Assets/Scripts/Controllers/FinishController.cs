using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Signals;
using Managers;

namespace Controllers
{
    public class FinishController : MonoBehaviour
    {
  
        private void OnTriggerEnter(Collider other)
        {
            /*if (other.CompareTag("Player"))
            {
                Debug.Log("Teneke");

                CoreGameSignals.Instance.OnFinishDetected?.Invoke(transform);
            }*/
        }

    
    }
}


