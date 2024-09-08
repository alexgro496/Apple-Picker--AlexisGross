using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public GameObject restartButtonPrefab;
    public GameObject canvasPrefab;

    public static int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numBaskets; i++){
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleMissed(){
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tempGO in appleArray){
            Destroy(tempGO);
        }

        int basketIndex = basketList.Count - 1;
        RoundCounter.SET_ROUND((numBaskets - basketIndex) + 1);

        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        if(basketList.Count == 0){
            GameObject newCanvas = Instantiate(canvasPrefab) as GameObject;
            GameObject newButton = Instantiate(restartButtonPrefab) as GameObject;
            newButton.transform.SetParent(newCanvas.transform, false);
            
            // GameObject restartButton = Instantiate<GameObject>(restartButtonPrefab);
            // restartButton.transform.position = transform.position;
            // SceneManager.LoadScene("_Scene_0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
