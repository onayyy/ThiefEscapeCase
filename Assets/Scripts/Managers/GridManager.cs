using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class GridManager : MonoBehaviour
    {
        [Header("Grid Property")]
        public int ColumnLength;
        public int RowLength;
        public float x_Space;
        public float y_Space;
        public float z_Space;

        [Space]
        public float x_Start;
        public float y_Start;
        public float z_Start;

        [Space]
        public Transform Prefab;

        [SerializeField] private List<Transform> transformsList = new List<Transform>();

        private void Start()
        {
            for (int i = 0; i < ColumnLength * RowLength; i++)
            {
                var obj = Instantiate(Prefab, new Vector3(x_Start + (x_Space * (i % ColumnLength)), y_Start + (y_Space * (i / ColumnLength)), z_Start + (z_Space * (i / ColumnLength))), Quaternion.identity);
                transformsList.Add(obj);
            }

            GameManager.Instance.GridTransform = transformsList;
        }


    }

}

