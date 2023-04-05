using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "Examples/DefaultNPC")]

public class NPCSO : ScriptableObject
{
    public string npcName;
    public string[] dialogue;
    public Sprite npcSprite;
}
