using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public GameObject ParticleSystem;
	public bool isPlayerBullet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameInvisible(){
		Destroy(gameObject);
	}

	void OnCollisionEnter2D(Collision2D col2D){
		if(isPlayerBullet)
		{
			if(col2D.gameObject.tag != gameObject.tag)
			{
				Instantiate(ParticleSystem, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
		}else{
			if(col2D.gameObject.tag != gameObject.tag)
			{
				if(col2D.gameObject.tag != "Wall")
				{
					Instantiate(ParticleSystem, transform.position, Quaternion.identity);
					Destroy(gameObject);
				}
			}
		}

		
	}
}
