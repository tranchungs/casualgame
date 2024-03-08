using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Door", menuName = " Script Object/LevelSO")]
public class LevelSO : ScriptableObject
{
    public Chunk[] chunks;
}
