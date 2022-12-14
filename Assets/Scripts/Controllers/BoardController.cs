using UnityEngine;
using Managers;

namespace Controllers
{
    public class BoardController : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        [SerializeField] private GameObject childObj;

        private void Awake()
        {
            GameManager.Instance.RefTargetTransform = targetTransform;
        }

        private void Update()
        {
            if (GameManager.Instance.TriggerFinishBoard)
            {
                childObj.transform.localScale = new Vector3(1f, 1f, 3.25f);
            }
            else
            {
                childObj.transform.localScale = new Vector3(.85f, .85f, 3.25f);
            }
        }
    }
}


