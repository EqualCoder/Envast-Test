using UnityEngine;
using UnityEngine.UI;

//todo: use pooling
//todo make it harder: scale to show cubesPyramid
namespace GameTwo
{
    public class Generate : MonoBehaviour
    {
        [SerializeField] private Button generateButton;
        [SerializeField] private Button deleteButton;
        [SerializeField] private InputField amount;
        [SerializeField] private RectTransform prefab;
        [SerializeField] private Transform parent;
        [SerializeField] private float spacing;
        [SerializeField] private Text msg;

        private Vector3 startPosition;
        private Vector3 currentPosition;
        private Vector2 prefabSize;

        private void Start()
        {
            deleteButton.onClick.AddListener(ClearCubes);
            generateButton.onClick.AddListener(GenerateCubes);
            startPosition = parent.GetComponent<RectTransform>().position;
            prefabSize = prefab.rect.size;
        }

        private void GenerateCubes()
        {

            ClearCubes();
            currentPosition = startPosition;
            var isValid = int.TryParse(amount.text, out var nb);

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
            if (nb == 0) return;
            if (nb % 2 == 0)
            {
                currentPosition.x -= prefabSize.x * (nb * .5f) - prefabSize.x * .5f;
                for (var i = 0; i < nb; i++)
                {
                    Instantiate(prefab, currentPosition, Quaternion.identity, parent);
                    currentPosition.x += prefabSize.x;
                }

                SetToUpperLine();
                NewGenerateCubes(nb - 1);
                return;
            }
        
            currentPosition.x -= prefabSize.x * Mathf.Floor(nb * .5f);
            for (var i = 0; i < nb; i++)
            {
                Instantiate(prefab, currentPosition, Quaternion.identity, parent);
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
    
        private void OldGenerateCubes(int nb)
        {
            var i = nb;
            msg.text = "";
            var k = 1;
            while (i>=1)
            {
                var j = 1;
                while(j<=i)
                {
                    Instantiate(prefab, currentPosition, Quaternion.identity,parent);
                    currentPosition = new Vector3(currentPosition.x + prefab.rect.width + spacing , currentPosition.y, 0f);
                    j++;
                }

                currentPosition = new Vector3(startPosition.x + k * (prefab.rect.height / 2), startPosition.y + (spacing * k), 0f);
                k++;
                i--;
            }
        }
    
        private void ClearCubes()
        {
            int childs = parent.childCount;
            for (int i = childs - 1; i >= 0; i--) {
                Destroy(parent.GetChild(i).gameObject);
            }
        }

    }
}
