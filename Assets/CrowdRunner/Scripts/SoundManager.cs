using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private EffectSO effectSO;
    private AudioSource m_AudioSource;
    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.OnInteract += PlayerController_OnInteract;
    }
    private void OnDestroy()
    {
        PlayerController.OnInteract -= PlayerController_OnInteract;
    }
    private void PlayerController_OnInteract(object sender, PlayerController.OnInteractArg e)
    {
        m_AudioSource.clip = effectSO.sound;
       Transform effIns = Instantiate(effectSO.effect, new Vector3( e.positionPlayer.x, e.positionPlayer.y+3, e.positionPlayer.z-2), Quaternion.identity);
        m_AudioSource.Play();
        Destroy(effIns.gameObject,2f );
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
