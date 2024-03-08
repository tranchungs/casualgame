using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;


public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [Header(" Element")]
    private CrowdSystem crowdSystem;
    [SerializeField] private EffectSO effectCrow;
    [SerializeField] private GameObject runPrefabs;
    [SerializeField] private Transform runnerParent;
    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float roadWidth;
    [SerializeField] private LayerMask doorLayerMask;

    [Header("Control")]
    [SerializeField] private float slideSpeed;
    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;
    public static event EventHandler<OnInteractArg> OnInteract;
    public class OnInteractArg : EventArgs
    {
        public Vector3 positionPlayer;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
        crowdSystem = GetComponent<CrowdSystem>();
    }
    void Start()
    {
        GameManager.OnGameStateChange += GameManager_OnGameStateChange;   
    }

    private void GameManager_OnGameStateChange(object sender, GameManager.GameState e)
    {
       
      
    }

    //xoan oc Fermat
    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsGamePlaying())
        {
            MoveForWard();
            ManageControl();
            Interaction();
        }
    }
    private void MoveForWard()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }
    private void ManageControl()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if(Input.GetMouseButton(0))
        {
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;
            xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;
            Vector3 position = transform.position;
            position.x = clickedPlayerPosition.x + xScreenDifference;
            position.x = Mathf.Clamp(position.x, -roadWidth / 2 + crowdSystem.GetCrowdRadius(), roadWidth / 2 - crowdSystem.GetCrowdRadius());
            transform.position = position;
        }
        

    }
    private void Interaction()
    {
        Vector3 location = new Vector3(transform.position.x,1.2f, transform.position.z);
        Collider[] hitColliders = Physics.OverlapSphere(location, 1);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent<DoorRenderer>(out DoorRenderer hitDoor))
            {
             
                DoorInfo doorSo = hitDoor.GetDoorSO();
                ApplyBonus(doorSo);
                hitDoor.DisableCollier();
                OnInteract?.Invoke(this,new OnInteractArg { positionPlayer = transform.position });


            }
            if (hitCollider.gameObject.tag == "FinishLine")
            {
                GameManager.Instance.SetGameState(GameManager.GameState.LevelComplete);
                PlayerPrefs.SetInt("level",PlayerPrefs.GetInt("level") +1);
                SceneManager.LoadScene(0);
            }

        }
        
    }
    private  void ApplyBonus(DoorInfo doorSO)
    {
        switch (doorSO.DoorType)
        {
            case DoorType.Add:
                AddRunParten(doorSO.valueDoor);
                break;
            case DoorType.Sub:
                if(runnerParent.childCount < doorSO.valueDoor)
                {
                    Debug.Log("Misson Fail");
                    GameManager.Instance.SetGameState(GameManager.GameState.Gameover);
                }
                else
                {
                    SubRunParten(doorSO.valueDoor);
                }
               
                break;
            case DoorType.Mul:
                MulRunParten(doorSO.valueDoor);


                break;
            case DoorType.Div:
                if (runnerParent.childCount < doorSO.valueDoor)
                {
                    Debug.Log("Misson Fail");
                    GameManager.Instance.SetGameState(GameManager.GameState.Gameover);
                }
                else
                {
                    SubRunParten(doorSO.valueDoor);
                }
                DivRunParten(doorSO.valueDoor);
                break;
        }

    }
    private void AddRunParten(int value)
    {
        for (int i = 0; i < value; i++)
        {
            Instantiate(runPrefabs, runnerParent);
         
        }
    }
    private void SubRunParten(int value)
    {
        for (int i = 0; i <  value; i++)
        {
            Destroy(runnerParent.GetChild(i).gameObject);
         
        }
    }
    private void MulRunParten(int value)
    {
        int current = runnerParent.childCount;
        int numberRunPartenAdd = current * value - current;
        for (int i = 0; i < numberRunPartenAdd; i++)
        {
            Instantiate(runPrefabs, runnerParent);
           
        }
    }
    private void DivRunParten(int value)
    {
        int divResult = runnerParent.childCount / value;
        for (int i = 0; i < runnerParent.childCount - divResult; i++)
        {
            Destroy(runnerParent.GetChild(i).gameObject);
         
        }
    }

}

