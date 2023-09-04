using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUIScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart(){
        //SceneManager.LoadScene("SampleScene"); //load scene called "SampleScene"
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // get the scene we are currently on and load it
    }

    public void Home(){
        SceneManager.LoadScene("MainMenu");   
    }
}
