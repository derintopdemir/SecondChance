using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager singleton;
    public static ResourceManager Singleton { get { if (singleton == null) singleton = FindObjectOfType<ResourceManager>(); return singleton; } }

    public enum Type { O2, Water, Food, Energy, Mineral }

    private Dictionary<Type, int> resources;

    // Start is called before the first frame update
    void Start()
    {
        singleton = this;
        resources = new Dictionary<Type, int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddResource(Type type, int amount)
    {
        resources[type] += amount;
    }

    public bool CheckResource(Type type, int amount)
    {
        return resources[type] >= amount;
    }

    public bool CheckResource(List<Buildings.Material> material)
    {
        foreach (var item in material)
        {
            if (resources[item.type] <= item.quantity)
                return false;
        }
        return true;
    }

    public void UseResource(Type type, int amount)
    {
        resources[type] -= amount;
    }
}
