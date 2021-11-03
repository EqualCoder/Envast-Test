using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameThree
{
    public class CloseButton : MonoBehaviour
    {
        [SerializeField] private Button b;
        [SerializeField] private GameObject panel;
        void Start()
        {
            //movement and color changer using Tweening
            b.transform.DOMoveX(b.transform.position.x+600, 1.5f).SetEase(Ease.InFlash)
                .SetLoops(-1, LoopType.Yoyo);
            b.GetComponent<Image>().DOColor(Random.ColorHSV(), 1.8f).SetLoops(-1, LoopType.Yoyo);
            
            b.onClick.AddListener(Close);
        }

        // Update is called once per frame
        private void Close()
        {
            panel.gameObject.SetActive(false);
        }
    }
}
