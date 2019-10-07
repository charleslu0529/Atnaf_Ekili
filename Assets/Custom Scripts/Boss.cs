using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	public GameObject ParticleSystem;
	public float BossHealth = 500;
	Color originalColour;
	float maxHP;

	// Use this for initialization
	void Start () {
		originalColour = GetComponent<SpriteRenderer>().color;
		maxHP = BossHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(BossHealth < 0)
		{
			Instantiate(ParticleSystem, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

	void FixedUpdate(){
		GetComponent<SpriteRenderer>().color = originalColour;
	}

	void OnCollisionEnter2D(Collision2D col2D){
		BossHealth -= 0.5f;
		GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
		GameManager.instance.updateEnemyHP(maxHP, BossHealth);
	}
}
