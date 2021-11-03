
using System;
using UnityEngine;
using UnityEngine.UI;

public class Generate : MonoBehaviour
{
    [SerializeField] private Button btn;
    [SerializeField] private InputField nbr;
    [SerializeField] private Text msg;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform parent;
    [SerializeField] private float distance;
    private void Start()
    {
        btn.onClick.AddListener(Call);
    }

    private void Call()
    {
        var posinit =new Vector3(667f, 318f,0f);
        var pos = new Vector3(667f, 318f, 0f);
        var nb=int.Parse(nbr.text);
        
        if (nb < 1) msg.text = "Give a number bigger than 0 !"; 
        else
        {
            int i = nb;
            msg.text = "";
            int k = 1;
            while (i>=1)
            {
                int j = 1;
                while(j<=i)
                {
                    Instantiate(prefab, pos, Quaternion.identity,parent);
                    pos = new Vector3(pos.x+distance, pos.y,0f);
                    j++;
                }
                pos = new Vector3(posinit.x+k*(distance/2), posinit.y+(distance*k),0f);
                k++;
                i--;
            }
        }
    }

}
