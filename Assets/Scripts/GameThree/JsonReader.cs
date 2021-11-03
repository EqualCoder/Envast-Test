using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


namespace GameThree
{
    public class JsonReader : MonoBehaviour
    {

        [SerializeField] private Ease buttonAnimationEase;
        [SerializeField] private float timeDuration;
        [SerializeField] private Button b1;
        [SerializeField] private Button b2;
        [SerializeField] private Button b3;
        [SerializeField] private TextAsset textJson;

        [System.Serializable]
        public class Tab
        {
            public int id;
            public string title;
            public int index;
            public bool enabled;
        }

        [System.Serializable]
        public class Table
        {
            public Tab[] tabs;
        }

        [System.Serializable]
        public class Color
        {
            public byte r;
            public byte g;
            public byte b;
        }

        [System.Serializable]
        public class Content
        {
            public int tabId;
            public string name;
            public string message;
            public Color color;
        }

        [System.Serializable]
        public class Contents
        {
            public Content[] content;
        }

        [SerializeField] public static Table tabs = new Table();
        [SerializeField] public static Contents content = new Contents();

        private void Awake()
        {
            tabs = JsonUtility.FromJson<Table>(textJson.text);
            content = JsonUtility.FromJson<Contents>(textJson.text);

        }

        private void Start()
        {
            for (var i = 0; i <tabs.tabs.Length; i++)
            {
                if (tabs.tabs[i].index == 1)
                {
                    b1.GetComponentInChildren<Text>().text = tabs.tabs[i].title;
                    b1.transform.DOScale(1.25f, timeDuration)
                        .SetEase(buttonAnimationEase).SetLoops(-1, LoopType.Yoyo);
                }

                if (tabs.tabs[i].index == 2)
                {
                    b2.GetComponentInChildren<Text>().text = tabs.tabs[i].title;
                    b2.transform.DOScale(1.25f, timeDuration)
                        .SetEase(buttonAnimationEase).SetLoops(-1, LoopType.Yoyo);
                }

                if (tabs.tabs[i].index == 3)
                    b3.GetComponentInChildren<Text>().text = tabs.tabs[i].title;

            }
            
            //enabled
            for (var i = 0; i <tabs.tabs.Length; i++)
            {
                if (tabs.tabs[i].enabled == false && tabs.tabs[i].index == 1)
                    b1.interactable = false;

                if (tabs.tabs[i].enabled == false && tabs.tabs[i].index == 2)
                    b2.interactable = false;
                if (tabs.tabs[i].enabled == false && tabs.tabs[i].index == 3)
                    b3.interactable = false;
            }
        }
    }
}