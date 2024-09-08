using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    static private Text _UI_TEXT;
    static private int _ROUND = 1;

    private Text txtCom;
    
    void Awake(){
        _UI_TEXT = GetComponent<Text>();
    }
    
    static public int ROUND{
        get{return _ROUND; }
        private set{
            _ROUND = value;
            if(_UI_TEXT != null){
                if(value < 5){
                    _UI_TEXT.text = "Round " + value;
                }
                else{
                    _UI_TEXT.text = "Game Over";
                }
            }
        }
    }

    static public void SET_ROUND(int roundCount){
        if (roundCount <= 0) return;
        ROUND = roundCount;
    }
}
