using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Transform playButton;
    [SerializeField] private Transform settingButton;
    [SerializeField] private Transform progressBar;
    [SerializeField] private Transform levelText;
    // Start is called before the first frame update
    void Start()
    {
        progressBar.GetComponent<Slider>().value = 0;
        levelText.GetComponent<TextMeshProUGUI>().text =  "Level " + ChunkManager.instance.GetLevel();
   
        GameManager.OnGameStateChange += GameManager_OnGameStateChange;
    }
    private void Update()
    {
        ProcessBarHandle();
    }
    private void GameManager_OnGameStateChange(object sender, GameManager.GameState e)
    {
      if(e == GameManager.GameState.Menu)
        {
            ShowUI();
        }
        else
        {
            HideUI();
        }
    }
    private void OnDestroy()
    {
        GameManager.OnGameStateChange -= GameManager_OnGameStateChange;
    }


    // Update is called once per frame

    private void ShowUI()
    {
        
        playButton.gameObject.SetActive(true);
    }
    private void HideUI()
    {
        playButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }
    private void ProcessBarHandle()
    {
        if (!GameManager.Instance.IsGamePlaying()) return;
        float z = PlayerController.Instance.transform.position.z / ChunkManager.instance.GetFinishZ();
        progressBar.GetComponent<Slider>().value =z;
    }
}
