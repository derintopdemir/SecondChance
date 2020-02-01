using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager singleton;
    public static ResourceManager Singleton { get { if (singleton == null) singleton = FindObjectOfType<ResourceManager>(); return singleton; } }

    public enum Type { O2, Water, Food, Energy, Mineral }

    private Dictionary<Type, int> resources;

    public TMPro.TextMeshProUGUI O2, Water, Food, Energy, Mineral;

    // Start is called before the first frame update
    void Start()
    {
        singleton = this;
        resources = new Dictionary<Type, int>();
        resources[Type.O2] = 0;
        resources[Type.Water] = 0;
        resources[Type.Food] = 0;
        resources[Type.Energy] = 0;
        resources[Type.Mineral] = 0;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddResource(Type type, int amount)
    {
        if (!resources.ContainsKey(type)) resources[type] = amount;
        resources[type] += amount;
        UpdateUI();
    }

    public bool CheckResource(Type type, int amount)
    {
        if (!resources.ContainsKey(type)) return false;
        return resources[type] >= amount;
    }

    public bool CheckResource(List<Buildings.Material> material)
    {
        foreach (var item in material)
        {
            if (!resources.ContainsKey(item.type) || resources[item.type] <= item.quantity)
                return false;
        }
        return true;
    }

    public void UseResource(Type type, int amount)
    {
        if (resources.ContainsKey(type))
        {
            resources[type] -= amount;
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        O2.text = resources[Type.O2].ToString();
        Water.text = resources[Type.Water].ToString();
        Food.text = resources[Type.Food].ToString();
        Energy.text = resources[Type.Energy].ToString();
        Mineral.text = resources[Type.Mineral].ToString();
    }
}
