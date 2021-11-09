using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace GameThree
{
    //todo: Add Select and Unselect to tabs & zoom for pyramid
    public class GenerateTab : MonoBehaviour
    {
        [SerializeField] private JsonReader jsonReader;
        [SerializeField] private Transform panelParent;
        [SerializeField] private Transform sousPanel;
        [SerializeField] private GameObject popup;
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform parent;

        private void Start()
        {
            jsonReader = FindObjectOfType<JsonReader>();
            Initiliase();

        }

        private void Initiliase()
        {
            var enemiesToTarget = jsonReader.tabs.tabs.OrderBy(t => t.index);
            foreach (var t in enemiesToTarget)
            {
                // instantiate in the topPanel
                var btn = Instantiate(prefab, panelParent.transform, false);

                //Put the text on the button
                btn.GetComponentInChildren<Text>().text = t.title;

                // put a random color on the button
                btn.GetComponent<Image>().color = new Color(Random.Range(0f, 1f),
                    Random.Range(0f, 1f), Random.Range(0f, 1f));

                // add an action listener
                 Button b = btn.GetComponent<Button>();

                //test if the button is set disabled in json file
                
                b.interactable = t.enabled;
                b.onClick.AddListener(() => ShowContent(t.id));
                
            }
        }

        private void ShowContent(int i)
        {
            foreach (Transform child in sousPanel)
            {
                GameObject.Destroy(child.gameObject);
            }

            foreach (var t in jsonReader.content.content)
            {
                if (i != t.tabId) continue;

                //instantiate button
                var content = Instantiate(prefab, sousPanel.transform, false);

                //Put the text on the button
                content.GetComponentInChildren<Text>().text = t.name;

                //set the color of the button from JSON
                content.GetComponent<Image>().color = t.color.GetColor();
                Button b = content.GetComponent<Button>();

                b.onClick.AddListener(() =>
                {
                    popup.GetComponentInChildren<Text>().text = t.message;
                    popup.gameObject.SetActive(true);
                });
            }
        }
    }

}
    

    
        


