using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "Examples/DefaultItem")]

public class ItemSO : ScriptableObject
{
    public int id = 0;
    public Sprite img;
}