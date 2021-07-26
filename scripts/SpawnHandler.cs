using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Lightbug.CharacterControllerPro.Core;
using Lightbug.Utilities;


public class SpawnHandler : MonoBehaviour
{
    int currentDoor;
    public GameObject player;
    public GameObject[] door;  

    public GameObject PlayerPrefab;
    public Vector3 spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
      // player = GameObject.FindWithTag("PlayerClose");
       
        if(player != null)
        {
           SetPlayerLocation();
        }
    }

    public void RespawnPlayer()
    {
         player.GetComponent<CharacterActor>().Teleport(spawnLocation, Quaternion.identity);
    }

    public void SetPlayerToSpawnPoint()
    {
         if(player != null)
            {
                int i = 7;
                
                if(door != null && player.GetComponent<CharacterActor>() != null)
                {
                    print("moving player " + player.transform.position.ToString() + " to spawn location (" + i + ") " + door[i].transform.position.ToString());
                    spawnLocation = door[i].transform.position;
                   
                    player.GetComponent<CharacterActor>().Teleport(spawnLocation, Quaternion.identity);

                }
            }
    }

    public void SetPlayerLocation()
    {        
            if(!PlayerPrefs.HasKey("pref-doorToLoad"))
            {
                PlayerPrefs.SetInt("pref-doorToLoad", 7);
            }
            currentDoor = PlayerPrefs.GetInt("pref-doorToLoad");
        
        
            if(player != null)
            {
                print(currentDoor.ToString());
                if(currentDoor == null)
                {
                    currentDoor = 7;
                }
                if(door != null && player.GetComponent<CharacterActor>() != null)
                {
                    print("moving player " + player.transform.position.ToString() + " to spawn location (" + currentDoor + ") " + door[currentDoor].transform.position.ToString());
                    spawnLocation = door[currentDoor].transform.position;
                   
                    player.GetComponent<CharacterActor>().Teleport(spawnLocation, Quaternion.identity);
                    PlayerPrefs.DeleteKey("pref-doorToLoad");
                }
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
