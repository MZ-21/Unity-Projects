using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   public void PlayGame(){
    int click= int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name); //getting button they clicked & converting string to int
    
    GameManager.instance.CharIndex = click;
    SceneManager.LoadScene("SampleScene");//switching scenes once selecting a character
   }



    
}//class
