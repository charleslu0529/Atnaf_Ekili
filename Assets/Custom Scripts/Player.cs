using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float Speed = 100f;
	public GameObject Bullet;
	public float Health = 250f;
	public float Ammo = 100;
	float maxAmmo;
	float maxHP;
	// Use this for initialization
	void Start () {
		maxHP = Health;
		maxAmmo = Ammo;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.RotateAround(Vector3.zero, new Vector3(0,0,1), Speed*Input.GetAxisRaw("Horizontal") * Time.deltaTime);
		
		if(Ammo > 0)
		{
			if(Input.GetKey(KeyCode.Space))
			{
				GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2((-1*transform.position.x),(-1*transform.position.y));
				Ammo -= 1;
				GameManager.instance.updatePlayerAmmo(maxAmmo, Ammo);
			}
		}

		if(Ammo < 100)
		{
			if(Input.GetAxisRaw("Vertical") < 0)
			{
				if(!Input.GetKey(KeyCode.Space))
				{
					Ammo += 0.5f;
					GameManager.instance.updatePlayerAmmo(maxAmmo, Ammo);
				}
				
			}
		}

		

	}

	void FixedUpdate(){
		/*if(Input.GetKey(KeyCode.Space))
		{
			GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
			bullet.GetComponent<Rigidbody2D>().velocity = new Vector2((-1*transform.position.x),(-1*transform.position.y));
		}*/
	}

	void OnCollisionEnter2D(Collision2D col2D){

		if(col2D.gameObject.tag == "Enemy Bullet")
		{
			Health -= 0.5f;
			GameManager.instance.updatePlayerHP(maxHP, Health);
		}
		
	}
}
