using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrowCounter : MonoBehaviour
{
    [SerializeField] private TextMeshPro crowdCounterText;
    [SerializeField] private Transform runnerParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        crowdCounterText.text  = runnerParent.childCount.ToString();
    }
}
