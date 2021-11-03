using DG.Tweening;
using UnityEngine;

namespace GameOne
{
    public class MovementManager : MonoBehaviour
    {
        [SerializeField] private Transform[] wayPoints;
        [SerializeField] private GameObject prefab;
        [SerializeField] private float delay;
        private int _i = 1;
        private GameObject _createdCube;

        private void Start()
        {
            var pos = wayPoints[0].transform.position;
             _createdCube = Instantiate(prefab, pos,Quaternion.identity);
            Move();
        }

        private void Move()
        {
            if (_i == wayPoints.Length) _i = 0;

            _createdCube.transform.DOMove(wayPoints[_i].transform.position, delay).OnComplete(() =>
            {
                System.Threading.Thread.Sleep(1000);
                _i++;
                Move();
            });
        }
    }
}
