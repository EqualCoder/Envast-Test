using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private RectTransform prefab;
    [SerializeField] private int preloadedAmount;
    private List<RectTransform> _availableItems;
    private int _counter;
    private Transform _t;

    private void Awake()
    {
        _availableItems = new List<RectTransform>();
        _counter = 0;
        _t = transform;
        GeneratePreloadedItems();
    }

    public RectTransform SpawnRectTransform()
    {
        if (_counter > 0)
        {
            Debug.Log("//. Spawn");
            var item = _availableItems[_counter - 1];
            _availableItems.Remove(item);
            _counter--;
            return item;
        }

        CreateNewItem();
        return SpawnRectTransform();
    }

    public void DeSpawnRectTransform(RectTransform objectToDeSpawn)
    {
        Debug.Log("//. Despawn");
        _availableItems.Add(objectToDeSpawn);
        _counter++;
        objectToDeSpawn.SetParent(_t);
        objectToDeSpawn.gameObject.SetActive(false);
    }
    
    private void CreateNewItem()
    {
        var newItem = Instantiate(prefab, _t);
        Debug.Log("//. Disable GO");
        newItem.gameObject.SetActive(false);
        _availableItems.Add(newItem);
        _counter++;
    }

    private void GeneratePreloadedItems()
    {
        for (int i = 0; i < preloadedAmount; i++) CreateNewItem();
    }
}
