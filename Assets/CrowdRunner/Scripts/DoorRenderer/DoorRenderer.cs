using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorRenderer : MonoBehaviour
{
    [SerializeField] private DoorSO doorSO;
    [SerializeField] private Collider colliderDoor;
    [SerializeField] private TextMeshPro textDoor;
    private Color bonusColor = Color.blue;
    private Color penatyColor= Color.red;
    private SpriteRenderer colorDoor;
    private int valueDoor;
    private int valueDoorType;
    private DoorType doorType;
    private void Awake()
    {
        valueDoorType = Random.Range(0,3);
        switch (valueDoorType)
        {
            case 0:
                doorType = DoorType.Add; break;
            case 1:
                doorType = DoorType.Sub; break;
            case 2:
                doorType = DoorType.Mul; break;
            case 3:
                doorType = DoorType.Div; break;

        }
        valueDoor = Random.Range(3, 5);
        colorDoor = GetComponent<SpriteRenderer>();
        SetupDoor();
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetupDoor()
    {
        switch (doorType)
        {
            case DoorType.Add:

                textDoor.text = "+" + valueDoor.ToString();
                colorDoor.color = bonusColor;
                break;
            case DoorType.Sub:

                textDoor.text = "-" + valueDoor.ToString();
                colorDoor.color = penatyColor;
                break;
            case DoorType.Mul:

                textDoor.text = "*" + valueDoor.ToString();
                colorDoor.color = bonusColor;
                break;
            case DoorType.Div:

                textDoor.text = "/" + valueDoor.ToString();
                colorDoor.color = penatyColor;
                break;
        }
    }
   public DoorInfo GetDoorSO()
    {
        return new DoorInfo(valueDoor, doorType);
    }
    public void DisableCollier()
    {
        colliderDoor.enabled = false;
    }
    
}
