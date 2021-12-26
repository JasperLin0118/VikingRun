using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Obstacle")
        {
            Destroy(gameObject);
            return;
        }
        //check the object we collided is player
        if (other.gameObject.name != "Viking_Axes")
            return;
        //Add to the player's score
        GameManager.inst.IncrementScore();
        //Destroy this coin object
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
