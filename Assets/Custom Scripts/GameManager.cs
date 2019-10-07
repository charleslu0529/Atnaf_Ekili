using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public GameObject WallOne;
	public GameObject WallTwo;
	public GameObject Boss;
	public GameObject Player;
	public GameObject EnemyHPBar;
	public GameObject EnemyHPOutline;
	public GameObject PlayerHPBar;
	public GameObject PlayerHPOutline;
	public GameObject PlayerAmmoBar;
	public GameObject PlayerAmmoOutline;
	public int numberToSpawn;
	float maxEnemyHPWidth;
	float maxPlayerHPWidth;
	float maxPlayerAmmoWidth;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}else if(instance != this)
		{
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
		for(int i=0;i<numberToSpawn;i++)
		{
			float angle = i * Mathf.PI * 2/numberToSpawn;
			float xPos = Mathf.Sin(angle) * 1.5f;
			float yPos = Mathf.Cos(angle) * 1.5f;
			float angleDegrees = angle * 180 / Mathf.PI;
			Vector3 spawnPosition = new Vector3(xPos, yPos, 0);
			GameObject firstWall = Instantiate(WallOne, spawnPosition, Quaternion.identity);

			firstWall.transform.rotation = Quaternion.AngleAxis(angleDegrees, new Vector3(0,0,-1));

			xPos = Mathf.Sin(angle) * 1.8f;
			yPos = Mathf.Cos(angle) * 1.8f;
			spawnPosition = new Vector3(xPos, yPos, 0);
			GameObject secondWall = Instantiate(WallTwo, spawnPosition, Quaternion.identity);

			secondWall.transform.rotation = Quaternion.AngleAxis(angleDegrees, new Vector3(0,0,-1));
		}
		
		maxEnemyHPWidth = EnemyHPBar.GetComponent<RectTransform>().sizeDelta.x;
		maxPlayerHPWidth = PlayerHPBar.GetComponent<RectTransform>().sizeDelta.x;
		maxPlayerAmmoWidth = PlayerAmmoBar.GetComponent<RectTransform>().sizeDelta.x;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 positionDifference = Boss.transform.position - Player.transform.position;
		float turnAngle = Mathf.Atan2(positionDifference.y, positionDifference.x)*Mathf.Rad2Deg;
		Quaternion rot = Quaternion.LookRotation( new Vector3(0,0,1), positionDifference);
		Boss.transform.rotation = Quaternion.Slerp(Boss.transform.rotation, rot, 10 * Time.deltaTime * 2);

	}

	public void updateEnemyHP(float maxHealth, float currentHealth){
		EnemyHPBar.GetComponent<RectTransform>().sizeDelta = new Vector2(maxEnemyHPWidth * (currentHealth/maxHealth),EnemyHPBar.GetComponent<RectTransform>().sizeDelta.y);
		EnemyHPBar.GetComponent<RectTransform>().localPosition = new Vector3(-(maxEnemyHPWidth-EnemyHPBar.GetComponent<RectTransform>().sizeDelta.x)/2, 0,0);
	}

	public void updatePlayerHP(float maxHealth, float currentHealth){
		PlayerHPBar.GetComponent<RectTransform>().sizeDelta = new Vector2(maxPlayerHPWidth * (currentHealth/maxHealth),PlayerHPBar.GetComponent<RectTransform>().sizeDelta.y);
		PlayerHPBar.GetComponent<RectTransform>().localPosition = new Vector3(-(maxPlayerHPWidth-PlayerHPBar.GetComponent<RectTransform>().sizeDelta.x)/2, 0,0);
	}

	public void updatePlayerAmmo(float maxAmmo, float currentAmmo){
		PlayerAmmoBar.GetComponent<RectTransform>().sizeDelta = new Vector2(maxPlayerAmmoWidth * (currentAmmo/maxAmmo),PlayerAmmoBar.GetComponent<RectTransform>().sizeDelta.y);
		PlayerAmmoBar.GetComponent<RectTransform>().localPosition = new Vector3(-(maxPlayerAmmoWidth-PlayerAmmoBar.GetComponent<RectTransform>().sizeDelta.x)/2, 0,0);
	}
}
