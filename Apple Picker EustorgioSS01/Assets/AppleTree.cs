using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    public GameObject applePrefab;

    //speed at which the appletree moves
    public  float speed = 1f;

    //distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    //Chance that the AppleTree will change directions
    public float changeDirChance =0.1f;

    //secounds betewen Apples instantiations
    public float appleDropDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //start dropping apples
        Invoke( "DropApple",2f); 
    }

    void DropApple(){
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke( "DropApple",appleDropDelay);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3  pos =  transform.position;
        //basic movement

        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //changing direction
        if(pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed); // moves right
        }
        else if(pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed); // move left 
        }
        // else if(Random.value  < changeDirChance){
        //     speed *= -1;
        // }
    }

    void FixedUpdate(){
        //random direction cahngees are now time based due to FixedUpdate()
        if(Random.value < changeDirChance){
            speed *= -1; // change direction
        }
    }
}
