using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public GameObject restartButtonPrefab;
    public GameObject canvasPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        
        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll){
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.CompareTag("Apple")){
            Destroy(collidedWith);

            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
        if(collidedWith.CompareTag("Branch")){
            Destroy(collidedWith);

            GameObject[] basketArray = GameObject.FindGameObjectsWithTag("Basket");

            foreach(GameObject tempGO in basketArray){
                Destroy(tempGO);
                // ApplePicker.AppleMissed();
            }
            // ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // for(int i = 0; i < ApplePicker.numBaskets; i++){
            //     apScript.AppleMissed();
            // }
            GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
            RoundCounter.SET_ROUND(10);
            ApplePicker.numBaskets = 0;

            GameObject newCanvas = Instantiate(canvasPrefab) as GameObject;
            GameObject newButton = Instantiate(restartButtonPrefab) as GameObject;
            newButton.transform.SetParent(newCanvas.transform, false);
        }
    }
}
