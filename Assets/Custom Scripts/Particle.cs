﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<ParticleSystem>())
		{
			if(!GetComponent<ParticleSystem>().IsAlive())
             {
                Destroy(gameObject);
             }
		}
	}
}
