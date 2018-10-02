using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {

    public GameObject player;


	private static Singleton instance;

	public static Singleton GetInstance{
		get{
			if(instance == null){
				instance = GameObject.FindObjectOfType<Singleton>();
			}
			return instance;
		}
	}
}
