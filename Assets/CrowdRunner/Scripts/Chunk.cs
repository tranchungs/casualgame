using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Vector3 size;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float GetLength()
    {
        return size.z;
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
