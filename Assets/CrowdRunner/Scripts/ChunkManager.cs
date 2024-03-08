using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField] private LevelSO[] levelSO;
    public static ChunkManager instance;
    [Header(" Elements")]
    [SerializeField] private Chunk[] chunkPrefabs;
    [SerializeField] private Chunk finishChunk;
    private int currentLevel;
    private Vector3 posLineFinish;
    private void Awake()
    {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {

        GenarateLevel();
        posLineFinish = GameObject.FindGameObjectWithTag("FinishLine").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GenarateLevel()
    {
        int currentLevel = GetLevel();
        currentLevel = currentLevel % levelSO.Length;
        LevelSO level = levelSO[currentLevel];
        CreateLevel(level.chunks);
    }
    private void CreateLevel(Chunk[] levelChunks)
    {
        Vector3 chunkPosition = transform.position;
        for (int i = 0; i < levelChunks.Length; i++)
        {
            Chunk chunkToCreate = levelChunks[i];
            if (i > 0)
            {
                chunkPosition.z += chunkToCreate.GetLength() / 2;
            }
            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity);


            chunkPosition.z += chunkToCreate.GetLength() / 2;
        }
    }
    public int GetLevel()
    {
        return PlayerPrefs.GetInt("level");
    }
    public float GetFinishZ()
    {
        return posLineFinish.z;
    }
}
