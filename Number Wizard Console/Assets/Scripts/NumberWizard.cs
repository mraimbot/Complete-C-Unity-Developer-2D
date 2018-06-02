using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
	int maximumGuess = 1000;
	int minimumGuess = 1;
	int currentGuess = 0;
	int currentMaximumGuess = 0;
	int currentMinimumGuess = 0;

	void Start ()
	{
		StartGame();
	}

	void StartGame()
	{
		ResetGame();
		Introduction();
		NextGuess();
	}

	void ResetGame()
	{
		currentMaximumGuess = maximumGuess + 1;
		currentMinimumGuess = minimumGuess;
	}

	void Introduction()
	{
		Debug.Log("<< Welcome to Number Wizard >>");
		Debug.Log("<< Pick a integer number of your choice between " + minimumGuess.ToString() + " and " + maximumGuess.ToString() + " >>");

		Debug.Log("<< Controls >>\n" +
			"- Arrow Up = number is higher; Arrow Down = number is lower; Enter = number is correct; Space = new game");
	}

	void Update ()
	{
		GetPlayerInput();
	}

	void GetPlayerInput()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			GuessIsHigher();
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{

			GuessIsLower();
		}
		else if (Input.GetKeyDown(KeyCode.Return))
		{
			GuessIsCorrect();
		}
		else if (Input.GetKeyDown(KeyCode.Space))
		{
			StartGame();
		}
	}

	void GuessIsCorrect()
	{
		Debug.Log("You: The number " + currentGuess.ToString() + " was correct!");
		Debug.Log("<< Press Space key to start a new game. >>");
	}

	void GuessIsHigher()
	{
		Debug.Log("You: The number is higher.");
		currentMinimumGuess = currentGuess;
		NextGuess();
	}

	void GuessIsLower()
	{
		Debug.Log("You: The number is lower.");
		currentMaximumGuess = currentGuess;
		NextGuess();
	}

	void NextGuess()
	{
		currentGuess = (currentMinimumGuess + currentMaximumGuess) / 2;
		Debug.Log("NPC: Is your number " + currentGuess.ToString() + "?");
	}
}
