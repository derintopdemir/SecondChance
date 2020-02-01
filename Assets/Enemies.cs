using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemies", menuName = "CustomObjects/Enemies", order = 3)]
public class Enemies : ScriptableObject
{
    public int speed;
    public int fireSpeed;
    public int damage;
    
    public enum FireType { Melee, Ranged }
    public FireType fireType;

    public Mesh mesh;
}
