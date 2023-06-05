using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globals : MonoBehaviour
{
    public int NumberOfMagnetsClicked;
    public GameObject portalLightning;
    public GameObject player;
    public bool playerHasKey = false;
    public bool isTeleporting;
    public List<GameObject> levels;
    public string code;


    private void Start()
    {
        
        portalLightning.SetActive(false);

        //PlayerPrefs.SetInt("currentLevel", 1);
        //loadLevel();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            refreshVariables();
        }
    }


    public void getTheKey(GameObject key=null)
    {
        playerHasKey = true;
        portalLightning.SetActive(true);
        Destroy(key);
    }


    public void loadNextLevel()
    {
        GameObject currentLevel = levels[PlayerPrefs.GetInt("currentLevel")];
        currentLevel.SetActive(false);
        PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("currentLevel") + 1);
        loadLevel();
    }

    public void loadLevel()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel");
        GameObject currentLevelObj = levels[currentLevel];
        
        currentLevelObj.SetActive(true);
        playerHasKey = false;
        ResetPlayerOnInitialPosition();
        refreshVariables();
    }

    public void ResetPlayerOnInitialPosition()
    {
        var InitialPositionObject = GameObject.Find("ballPosition");
        player.transform.position = InitialPositionObject.transform.position;
    }

    public void refreshVariables()
    {
        Debug.Log("variables refreshed");
        GameObject portalLightningParent = GameObject.Find("exit portal");
        portalLightning = portalLightningParent.transform.GetChild(0).gameObject;
    }
}
