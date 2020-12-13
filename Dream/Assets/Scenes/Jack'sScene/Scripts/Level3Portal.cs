using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level3Portal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionStay(Collision col)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (col.gameObject.tag == "Player")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console

            UnityEngine.SceneManagement.SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        }
    }
}
