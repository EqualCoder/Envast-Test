using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameTwo
{
    public class TweeningAnimations : MonoBehaviour
    {
        [SerializeField] private Transform pyramid;
        [SerializeField] private Button minimiseButton;
        [SerializeField] private Button maximiseButton;
        [SerializeField] private Button animateButton;
        [SerializeField] private Button moveButton;
        [SerializeField] private Ease easeType;
        private float _duration;
        private float _jumpPower;
        private bool _snapping;
        private int _numJumps;
        private Vector3 transformPosition;
        
        
        private void Update()
        {
            if(pyramid.childCount == 0)
            {
                minimiseButton.interactable = false;
                maximiseButton.interactable = false;
                animateButton.interactable = false;
                moveButton.interactable = false;
            }
            else
            {
                minimiseButton.interactable = true;
                maximiseButton.interactable = true;
                animateButton.interactable = true;
                moveButton.interactable = true;
            }
        }

        private void Start()
        {
             transformPosition = pyramid.transform.position;
            _jumpPower=50f;
            _duration = 2f;
            _numJumps=3;
            minimiseButton.onClick.AddListener(Minimise);
           maximiseButton.onClick.AddListener(Maximase);
           animateButton.onClick.AddListener(Animate);
           moveButton.onClick.AddListener(Move);
        }


        private void Minimise()
        {
            DOTween.Kill(pyramid);
            pyramid.transform.DORotate(Vector3.zero, _duration, RotateMode.Fast);
            pyramid.transform.DOScale(0f, _duration).SetEase(Ease.InFlash).SetLoops(-1, LoopType.Yoyo);
        }
        private void Maximase()
        {
            DOTween.Kill(pyramid);
            pyramid.transform.DORotate(Vector3.zero, _duration, RotateMode.Fast);
            pyramid.transform.DOScale(1.6f, _duration).SetEase(Ease.InCubic).SetLoops(-1, LoopType.Yoyo);
        }
        private void Animate() //jump
        {
            DOTween.Kill(pyramid);
            Vector3 jump = pyramid.transform.position+ new Vector3(25f,150f,0f);
            Vector3 rotation = new Vector3(0f, 0f, -15);
            pyramid.transform.DORotate(rotation,  _duration, RotateMode.Fast).SetEase(Ease.InBack);
            pyramid.transform.DOJump(jump,
                _jumpPower, _numJumps, _duration, _snapping).SetLoops(-1,LoopType.Restart);
        }
        private void Move()
        {
            DOTween.Kill(pyramid);
            pyramid.transform.DORotate(Vector3.zero, _duration, RotateMode.Fast);
            Vector3 newPosition = pyramid.transform.position+ new Vector3(400f,0f,0f);
            pyramid.transform.DOMove(newPosition, _duration).SetEase(Ease.InOutQuint)
                .OnComplete(() =>
                    {
                        pyramid.transform.DOMove(pyramid.transform.position+new Vector3(-450f, 0f, 0f), _duration)
                            .OnComplete(Move);
                    }
                );
        }

        public void KillAllTweens() => DOTween.Kill(pyramid);
    }
}
