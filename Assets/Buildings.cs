using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "CustomObjects/Buildings", order = 1)]
public class Buildings : ScriptableObject
{
    public enum BuildingType { Farm, Mine, Capacitor, O2Generator, Pump }
    
    public BuildingType buildingType;
    public int buildingHealth;
    public int contribution;
    public Mesh mesh;

    [Serializable]
    public struct Material
    {
        [SerializeField]
        public enum Type { O2, Water, Food, Energy, Mıneral }
        [SerializeField]
        public Type type;
        [SerializeField]
        public int quantity;
    }
    public List<Material> neededMaterials;
}
