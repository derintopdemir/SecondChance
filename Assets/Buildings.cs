using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "CustomObjects/Buildings", order = 1)]
public class Buildings : ScriptableObject
{
    public enum BuildingType { Farm, Mine, Capacitor, O2Generator, Pump }
    
    public BuildingType buildingType;
    public ResourceManager.Type producing;
    public int buildingHealth;
    public int contribution;
    public int interval;
    public Mesh mesh;

    [Serializable]
    public struct Material
    {
        [SerializeField]
        public ResourceManager.Type type;
        [SerializeField]
        public int quantity;
    }
    public List<Material> neededMaterials;
}
