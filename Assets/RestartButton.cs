using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // Start is called before the first frame update

    public void OnRestartButton(){
        SceneManager.LoadScene("_StartScreen_0");
    }


    // Update is called once per frame
}
