using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScript : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
  void OnGUI(){

    GUI.color = Color.white;    //text color
    GUI.skin.label.fontSize = 50; //font size

    GUI.Label(new Rect(((Screen.width/2)-200),((Screen.height/2)-100),300,150),"Sleep Assassin"); 
    GUI.skin.button.fontSize = 20;
    if(GUI.Button(new Rect(((Screen.width/2)-10),((Screen.height/2)+50),150,20),"Start Game")){
      UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1",LoadSceneMode.Single);   
    }
  }
}
