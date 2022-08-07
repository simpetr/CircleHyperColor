using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    //Main level manager 
   
    public class GameManager : MonoBehaviour
    {
        public GameObject DefaultMap;
        //TODO load game map
        //TODO load begin UI
        //TODO load end level 
        private void Start()
        {
            StartCoroutine(LoadLevel());
        }


        IEnumerator LoadLevel()
        {
            Debug.Log("START LOADING THE LEVEL");
            yield return new WaitUntil(LoadMap);
            Debug.Log("ACTIVE UI AND START COUNTDOWN");
            yield return new WaitUntil(UICountdown);
            StartGame();
        }
        
        private bool LoadMap()
        {
            GameObject map = GameDataManager.GetCurrentMap();
            Instantiate(map, Vector3.zero, Quaternion.identity);
            return true;
        }
        
        private bool UICountdown()
        {
            return true;
        }
        
        private void StartGame()
        {
            
        }
    }
}