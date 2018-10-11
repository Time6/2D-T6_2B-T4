using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathManager : MonoBehaviour {

private PlayerController player;
public BoxCollider2D[] roomSet;
public int[] path;
public ContactFilter2D playerMask;

public bool koalaPunkStarted;

	// Use this for initialization
	void Start () {


		 player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		 

	}
	
	// Update is called once per frame
	void Update () {

		if(player.talking == true)
		{
			
    if(roomSet[14].IsTouching(playerMask))
{
	if(!koalaPunkStarted)
	{
                    koalaPunkStarted = true;
    }

}


		}
		
	}

    void FixedUpdate()
    {

        if (koalaPunkStarted)
        {


        }

    }


	
}
