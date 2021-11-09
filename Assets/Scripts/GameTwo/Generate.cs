using UnityEngine;
using UnityEngine.UI;

namespace GameTwo
{
    public class Generate : MonoBehaviour
    {
        [SerializeField] private Button generateButton;
        [SerializeField] private InputField amount;
        [SerializeField] private RectTransform prefab;
        [SerializeField] private Transform parent;
        [SerializeField] private Text msg;
        [SerializeField] private TweeningAnimations tweener;
        [SerializeField] private PoolManager _pool;

        private Vector3 startPosition;
        private Vector3 currentPosition;
        private Vector2 prefabSize;

        private void Start()
        {
            generateButton.onClick.AddListener(GenerateCubes);
            startPosition = parent.GetComponent<RectTransform>().position;
            prefabSize = prefab.rect.size;
        }

        private void GenerateCubes()
        {
            ClearCubes();
            currentPosition = startPosition;
            bool isValid = int.TryParse(amount.text, out var nb);

            if (!isValid)
            {
                msg.text = "Use Numbers";
                return;
            }

            if (nb < 1)
            {
                msg.text = "Give a number bigger than 0 !";
                return;
            }
        
            NewGenerateCubes(nb);

        }

        private void NewGenerateCubes(int nb)
        {
            msg.text = "";
            if (nb == 0) return;
            if (nb % 2 == 0)
            {
                currentPosition.x -= prefabSize.x * (nb * .5f) - prefabSize.x * .5f;
                for (var i = 0; i < nb; i++)
                {
                    var spawnedItem = _pool.SpawnRectTransform();
                    Debug.Log("//. Enable GO");
                    spawnedItem.gameObject.SetActive(true);
                    spawnedItem.position = currentPosition;
                    spawnedItem.SetParent(parent);
                    currentPosition.x += prefabSize.x;
                }

                SetToUpperLine();
                NewGenerateCubes(nb - 1);
                return;
            }
        
            currentPosition.x -= prefabSize.x * Mathf.Floor(nb * .5f);
            for (var i = 0; i < nb; i++)
            {
                var spawnedItem = _pool.SpawnRectTransform();
                Debug.Log("//. Enable GO");
                spawnedItem.gameObject.SetActive(true);
                spawnedItem.position = currentPosition;
                spawnedItem.SetParent(parent);
                currentPosition.x += prefabSize.x;
            }

            SetToUpperLine();
            NewGenerateCubes(nb - 1);
        }

        private void SetToUpperLine()
        {
            currentPosition.x = startPosition.x;
            currentPosition.y += prefabSize.y;
        }
        
        private void ClearCubes()
        {
            tweener.KillAllTweens();
            
            var childs = parent.childCount;
            for (var i = childs - 1; i >= 0; i--) {
                _pool.DeSpawnRectTransform(parent.GetChild(i).GetComponent<RectTransform>());
            }
        }

    }
}
