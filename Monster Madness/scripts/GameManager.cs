using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] characters;

    public static GameManager instance; //instance means

    private int _charIndex;
    
    public int CharIndex 
    {
        get {return _charIndex;}
        set {_charIndex = value;}
    }
    //use singleton pattern to have only one copy
    private void Awake(){

        if(instance==null){

            instance = this;//mEAning createe copy
            DontDestroyOnLoad(gameObject);//game object holding script wont be destroyed when loading new scene
        }
        else{Destroy(gameObject);}//destroy the duplicate
    }

    private void OnEnable(){
        SceneManager.sceneLoaded += OnLevelFinishedLoading; 
    }
    private void OnDisable(){
        SceneManager.sceneLoaded -= OnLevelFinishedLoading; 
    }
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){//lstening to event
         
         if(scene.name == "SampleScene"){
            Instantiate(characters[CharIndex]);
         }

   }
}//class
