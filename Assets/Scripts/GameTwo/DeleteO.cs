using UnityEngine;
using UnityEngine.UI;

namespace GameTwo
{
    public class DeleteO : MonoBehaviour
    {
        [SerializeField] private GameObject obj;
        [SerializeField] private Button btn;

        private void Start()
        {
            btn.onClick.AddListener(Change);
        }

        private void Change()
        {
            int childs = obj.transform.childCount;
            for (int i = childs - 1; i >= 0; i--) {
                DestroyImmediate(obj.transform.GetChild(i).gameObject);
            }
        }  
 
   
    }
}
