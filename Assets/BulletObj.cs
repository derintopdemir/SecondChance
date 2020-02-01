using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullets", menuName = "CustomObjects/Bullets", order = 3)]
public class BulletObj : ScriptableObject
{
    public int damage;
    public Mesh mesh;
}
