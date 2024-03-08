using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    [Header(" Element")]
    [SerializeField] private Transform runnerParent;
    [Header(" Setting")]
    [SerializeField] private float radius;
    [SerializeField] private float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaceRunner();
    }
    private void PlaceRunner()
    {
        for (int i = 0; i < runnerParent.childCount; i++)
        {
            Vector3 childLocalPostion = GetRunnerLocalPosition(i);
            runnerParent.GetChild(i).localPosition = childLocalPostion;
        }
    }
    private Vector3 GetRunnerLocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);
        return new Vector3(x, 0,z);
    }
    public float GetCrowdRadius()
    {
        return radius * Mathf.Sqrt(runnerParent.childCount);
    }
}
