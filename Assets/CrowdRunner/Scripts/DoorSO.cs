using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Door",menuName = " Script Object/DoorSO")]
public class DoorSO : ScriptableObject
{
     public int valueDoor;
     public DoorType DoorType;

    public DoorSO(int valueDoor,DoorType doorType)
    {
        this.valueDoor = valueDoor;
        this.DoorType = doorType;
    }
}
public class DoorInfo
{
    public int valueDoor;
    public DoorType DoorType;

    public DoorInfo(int valueDoor, DoorType doorType)
    {
        this.valueDoor = valueDoor;
        this.DoorType = doorType;
    }
}
public enum DoorType
{
     Add,
     Sub,
     Mul,
     Div
}
