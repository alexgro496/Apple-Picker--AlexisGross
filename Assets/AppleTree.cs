using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    
    public GameObject applePrefab;
    public GameObject branchPrefab;
    public float speed = 10f;
    public float leftAndRightEdge = 24f;
    public float changeDirChance = 0.02f;
    public float appleDropDelay = 1f;
    public float branchDropDelay = 10f;    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
        Invoke("DropBranch", 3.5f);
    }

    void DropApple(){
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        if(ApplePicker.numBaskets > 0){
            Invoke("DropApple", appleDropDelay);
        }
    }

    void DropBranch(){
        GameObject branch = Instantiate<GameObject>(branchPrefab);
        branch.transform.position = transform.position;
        if(ApplePicker.numBaskets > 0){
            Invoke("DropBranch", branchDropDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge){
            speed = -Mathf.Abs(speed);
        }
        // else if (Random.value < changeDirChance){
        //     speed *= -1;
        // }
    }

    void FixedUpdate(){
        if (Random.value < changeDirChance){
            speed *= -1;
        }
    }

}
