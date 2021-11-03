using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameThree
{
    public class GenerateTab : MonoBehaviour
    {
        [SerializeField] private Text txt;
        [SerializeField] private GameObject popup;
        private Vector3 _pos = new Vector3(220.7f, 557.4f, 0);
        [SerializeField] private Button b;
        [SerializeField] private Transform panel;
        [SerializeField] private Button t1;
        [SerializeField] private Button t2;
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
            for (var j = 0; j < JsonReader.content.content.Length; j++)
            {
                if (JsonReader.content.content[j].tabId == JsonReader.tabs.tabs[_k].id)
                {
                    //Button content (text)
                    b.GetComponentInChildren<Text>().text = JsonReader.content.content[j].name;

                    //Button color 
                   // b.GetComponent<Image>().DOColor(new Color(JsonReader.content.content[j].color.r/255f,
                        //JsonReader.content.content[j].color.g/255f, JsonReader.content.content[j].color.b/255f,255), 0);
                    
                    b.GetComponent<Image>().color= new Color(JsonReader.content.content[j].color.r/255f,
                        JsonReader.content.content[j].color.g/255f, JsonReader.content.content[j].color.b/255f,255);
                    
                    //Show Up Button
                    var m = Instantiate(b, _pos, Quaternion.identity, panel);
                    var j1 = j;
                    m.onClick.AddListener(() =>
                    {
                        popup.SetActive(true);
                        txt.text = JsonReader.content.content[j1].message;
                    });
                    _pos.y = _pos.y - 120;
                }
            }
            
        }
    }
}


    
        


