using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Door", menuName = " Script Object/EffectSO")]
public class EffectSO : ScriptableObject
{
    public Transform effect;
    public AudioClip sound;
}
