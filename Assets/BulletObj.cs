using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "CustomObjects/Buildings")]
public class BulletObj : ScriptableObject
{
    public int damage;
    public Mesh mesh;
}
