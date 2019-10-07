using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	public GameObject BossTransform;
	public GameObject Bullet;
	public int RotateSpeed = 30;
	float SpeedRange = 0;
	int varDirection;
	public float Health = 40f;
	public float SpeedDecay = 0.1f;
	public bool OutsideWall = false;
	float waitTime = 5f;
	bool rotating = false;
	float maxHP;
	float shootTime = 1f;
	float shootCoolDown = 1f;

	// Use this for initialization
	void Start () {
		maxHP = Health;
	}
	
	// Update is called once per frame
	void Update () {

		if(SpeedRange < 0.1f || SpeedRange < -0.1f)
		{
			if(waitTime < 0)
			{
				rotate();
				waitTime = 5f;	
			}else{
				waitTime -= Time.deltaTime;
				rotating = false;
			}
		}else{
			rotate();
			rotating = true;
		}

		if(Health < 0)
		{
			Destroy(gameObject);
		}

		int shoot = Random.Range(0, 2);
		if(shoot > 0)
		{
			if(OutsideWall)
			{
				if(rotating)
				{
					if(shootCoolDown < 0)
					{
						if(shootTime > 0)
						{
							GameObject currentBullet = Instantiate(Bullet, transform.position + (transform.position * 0.1f), Quaternion.identity);
							currentBullet.GetComponent<Rigidbody2D>().velocity = transform.position;
							shootTime -= Time.deltaTime;
						}else{
							
							shootCoolDown = 1f;
						}
					}else{
						shootCoolDown -= Time.deltaTime;
						shootTime = 1f;
					}
				}
			}
		}
	}

	void FixedUpdate(){
		GetComponent<SpriteRenderer>().color = new Color(1,0.65f,0.278f,1);	
	}

	void OnCollisionEnter2D(Collision2D col2D){
		if(!rotating)
		{
			Health -= 0.5f;
			GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
			GameManager.instance.updateEnemyHP(maxHP, Health);
		}
		
	}

	void rotate(){
		transform.RotateAround(Vector3.zero, new Vector3(0,0,1), RotateSpeed * Time.deltaTime * SpeedRange);
		if (SpeedRange < 0.01f)
		{
			varDirection = 1;
		}else if(SpeedRange > 10)
		{
			varDirection = -1;;
		}

		SpeedRange = SpeedRange + SpeedDecay * varDirection;
	}
}
