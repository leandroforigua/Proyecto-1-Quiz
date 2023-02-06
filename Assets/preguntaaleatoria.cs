using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class preguntaaleatoria : MonoBehaviour
{
	public int numberQuestions;
	public int count = 0;
	public int countQuestions = 0;
	public List<int> randomsNumbers;
	public bool stop = false;
	public GameObject[] questions;	
	public int points = 100;
	public GameObject finalPanel;
	public TextMeshProUGUI finalePoints;
	
    void Start()
	{
		while (!stop)
		//for(int i = 0; i < 100; i++)
	    {
			int temp = Random.Range(0, numberQuestions-1);
			if (!randomsNumbers.Contains(temp))
			{
				randomsNumbers.Add(temp);
				count ++;
			}
		    
			if (count == numberQuestions - 1)
			{
				break;
			}
		    
	    }
		ActiveQuestion();
    }

   
    void Update()
    {
	    if (questions.Length == countQuestions)
	    {
	    	finalPanel.SetActive(true);
	    	finalePoints.text = points.ToString();
	    	
	    }
	    
    }
    
	public void ActiveQuestion()
	{
		if(countQuestions != 0)
		{
			questions[randomsNumbers[countQuestions]].SetActive(false);
			countQuestions++;
			questions[randomsNumbers[countQuestions]].SetActive(true);
		}
		else
		{
			questions[randomsNumbers[countQuestions]].SetActive(true);
			countQuestions++;
		}
	}
	
	public void respuestaCorrecta(Button _boton)
	{
		StartCoroutine(respuestaCorrectaCoroutine(_boton));
	}
	
	public void respuestaIncorrecta(Button _boton)
	{
		StartCoroutine(respuestaIncorrectaCoroutine(_boton));
	}
	
	public IEnumerator respuestaCorrectaCoroutine(Button _boton)
	{
		_boton.image.color = Color.green;
		yield return new WaitForSeconds(1);
		points ++;
		ActiveQuestion();
	}
	
	public IEnumerator respuestaIncorrectaCoroutine(Button _boton)
	{
		_boton.image.color = Color.red;
		yield return new WaitForSeconds(1);
		ActiveQuestion();
	}
}
