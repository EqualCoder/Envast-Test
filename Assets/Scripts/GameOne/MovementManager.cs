using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace GameOne
{
    public class MovementManager : MonoBehaviour
    {
        [SerializeField] private Transform[] wayPoints;
        [SerializeField] private GameObject prefab;
        [SerializeField] private float animationLength;
        [SerializeField] private float stayInPositionTimer;
        [SerializeField] private Ease easeType;
        
        private int _i = 1;
        private GameObject _createdCube;
        private WaitForSeconds _delay;

        private void Start()
        {
            _delay = new WaitForSeconds(stayInPositionTimer);
            var pos = wayPoints[0].transform.position;
            _createdCube = Instantiate(prefab, pos, Quaternion.identity);
            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            if (_i == wayPoints.Length) _i = 0;

            _createdCube.transform.DOMove(wayPoints[_i].transform.position, animationLength).SetEase(easeType);
            yield return _delay;
            _i++;
            StartCoroutine(Move());
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            var previousPoint = wayPoints[wayPoints.Length - 1];
            foreach (var point in wayPoints)
            {
                Gizmos.DrawLine(previousPoint.position, point.position);
                Gizmos.DrawWireSphere(point.position, .25f);
                previousPoint = point;
            }
        }
    }
}
