using UnityEngine;
using UnityEngine.UI;

namespace GameThree
{
    public class GenerateTab : MonoBehaviour
    {
        [SerializeField] private JsonReader jsonReader;
        [SerializeField] private Text txt;
        [SerializeField] private GameObject popup;
        [SerializeField] private Button b;
        [SerializeField] private Transform panel;
        [SerializeField] private Button t1;
        [SerializeField] private Button t2;
        private Vector3 _pos = new Vector3(220.7f, 557.4f, 0);
        private int _k;

        private void Start()
        {
            t1.onClick.AddListener(() =>
            {
                _k = 1;
                Generate();
            });
            
            t2.onClick.AddListener(() =>
            {
                _k = 2;
                Generate();
            });
        }

        private void Generate()
        {
            // position of the new tabs(buttons)
            _pos = new Vector3(220.7f, 557.4f, 0);
            
            //destroy old tabs
            foreach (Transform child in panel)
            {
                Destroy(child.gameObject);
            }
            
            //generate new ones
            for (var j = 0; j < jsonReader.content.content.Length; j++)
            {
                if (jsonReader.content.content[j].tabId == jsonReader.tabs.tabs[_k].id)
                {
                    //Button content (text)
                    b.GetComponentInChildren<Text>().text = jsonReader.content.content[j].name;

                    //Button color 
                   // b.GetComponent<Image>().DOColor(new Color(JsonReader.content.content[j].color.r/255f,
                        //JsonReader.content.content[j].color.g/255f, JsonReader.content.content[j].color.b/255f,255), 0);
                    
                    b.GetComponent<Image>().color= new Color(jsonReader.content.content[j].color.r/255f,
                        jsonReader.content.content[j].color.g/255f, jsonReader.content.content[j].color.b/255f,255);
                    
                    //Show Up Button
                    var m = Instantiate(b, _pos, Quaternion.identity, panel);
                    var j1 = j;
                    m.onClick.AddListener(() =>
                    {
                        popup.SetActive(true);
                        txt.text = jsonReader.content.content[j1].message;
                    });
                    _pos.y = _pos.y - 120;
                }
            }
            
        }
    }
}


    
        


