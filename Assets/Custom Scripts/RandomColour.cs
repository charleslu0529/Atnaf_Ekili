using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColour : MonoBehaviour {

	public bool ChangeRed = false;
	public bool ChangeGreen = false;
	public bool ChangeBlue = false;
	float greenLimit = 1;
	float blueLimit = 1;
	float redLimit = 1;
	float currentRed = 0;
	float currentGreen = 0;
	float currentBlue = 0;
	int colourDirection = 1;
	// Use this for initialization
	void Start () {
		greenLimit = gameObject.GetComponent<Image>().color.g;
		blueLimit = gameObject.GetComponent<Image>().color.b;
		redLimit = gameObject.GetComponent<Image>().color.r;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(ChangeRed)
		{
			if(currentRed > redLimit)
			{
				colourDirection = -1;
			}
			else if(currentGreen < 0f)
			{
				colourDirection = 1;
			}

			currentRed = currentRed + 0.1f*colourDirection;

			}else if(ChangeGreen){
				if(currentGreen > greenLimit)
				{
					colourDirection = -1;
				}
				else if(currentGreen < 0f)
				{
					colourDirection = 1;
				}
				}else if(ChangeBlue){

				}
		

		currentGreen = currentGreen + 0.1f*colourDirection;
		currentBlue = currentBlue + 0.1f*colourDirection;

		gameObject.GetComponent<Image>().color = new Color( currentRed, currentGreen, currentBlue, 1.0f );
	}
}
