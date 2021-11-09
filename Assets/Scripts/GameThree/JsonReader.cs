using UnityEngine;
using System;

namespace GameThree
{
    public class JsonReader : MonoBehaviour
    {
        [SerializeField] private TextAsset textJson;

        [Serializable]
        public class Table
        {
            public Tab[] tabs;
        }

        [Serializable]
        public class Tab
        {
            public int id;
            public string title;
            public int index;
            public bool enabled;
        }

        [Serializable]
        public class Contents
        {
            public Content[] content;
        }

        [Serializable]
        public class Content
        {
            public int tabId;
            public string name;
            public string message;
            public Color color;
        }
        
        [Serializable]
        public class Color
        {
            public byte r;
            public byte g;
            public byte b;
        }
        
        public Table tabs = new Table();
        public Contents content = new Contents();

        
        private void Awake()
        {
            tabs = JsonUtility.FromJson<Table>(textJson.text);
            content = JsonUtility.FromJson<Contents>(textJson.text);
        }
        

    }
}