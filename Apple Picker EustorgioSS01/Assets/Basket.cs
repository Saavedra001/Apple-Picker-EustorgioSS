using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;


    // Start is called before the first frame update
    void Start()
    {
        //find a GameObject nameed ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //Get the ScoreCounter (Script) component of scoreGo
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();

    }

    // Update is called once per frame
    void Update()
    {
        //get the curren screen position of the mouse from input
        Vector3 mousePos2D = Input.mousePosition;

        //the zmers z position sets how far to push the mouse int 3d
        // if the line causes a nullrefereenceException, select the main camera
        // in the hierarchy and set its tag to maincamera in the inspector
        mousePos2D.z = -Camera.main.transform.position.z;

        //Convert the point from 2d screen space into 3d game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //move the x position to this bakset to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        //Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
            //Increse the score
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
    }
}
