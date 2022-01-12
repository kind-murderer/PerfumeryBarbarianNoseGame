using System;
using UnityEngine;
using UnityEngine.UI;

public class PotionsScript : MonoBehaviour
{
    private int[] currentState = new int [3];
    private int[,] possibleInitialStates = { { 6, 9, 5 }, { 7, 10, 3 }, { 9, 6, 4 } };


    [SerializeField] private Text[] numberSlots = new Text[3];
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private Text resultMainText;
    [SerializeField] private Text resultTittleText;

    TimerScript timer;

    private void Start()
    {
        timer = gameObject.GetComponent<TimerScript>();
        timer.TimeIsOut += TimeIsOutHandler;
    }
   public void StartMakingPotion()
    {
        SelectPotion();
        DisplayCurrentState();
        timer.StartTimer();
    }
    public void StopMakingPotion()
    {
        timer.StopTimer();
    }
    public void ShowResult(string caseResult)
    {
        resultPanel.SetActive(true);
        switch (caseResult)
        {
            case "timeIsOut":
                resultMainText.text = "Основа для духов испортилась. Клиенту лучше дать другой экземпляр. " + 
                    "Но вы хорошо попрактиковались. Стоит попробовать еще разок!";
                resultTittleText.text = "ВРЕМЯ ВЫШЛО";
                break;
            case "win":
                resultMainText.text = "Вы справились на отлично! Довольный клиент жмёт вам руку.";
                resultTittleText.text = "УСПЕХ";
                break;
        }
    }
    private void TimeIsOutHandler()
    {
        StopMakingPotion();
        ShowResult("timeIsOut");
    }
    private void SelectPotion()
    {
        System.Random rand = new System.Random();
        int potionNumber = rand.Next(0, 3);
        for (int i = 0; i < 3; ++i)
        {
            currentState[i] = possibleInitialStates[potionNumber, i];
        }
    }
    private void DisplayCurrentState()
    {
        for (int i = 0; i < 3; ++i)
        {
            numberSlots[i].text = currentState[i].ToString();
        }
    }
    public void AddUnicornHair()
    {
        if (isAcceptableTransformation(new int[3] { currentState[0] + 2 , currentState[1] - 1, currentState[2] - 1 }))
        {
            currentState[0] += 2;
            currentState[1] -= 1;
            currentState[2] -= 1;
            DisplayCurrentState();
        }
        if (isRowOFSevens())
        {
            StopMakingPotion();
            ShowResult("win");
        }
    }
    public void AddLilyPollen()
    {
        if (isAcceptableTransformation(new int[3] { currentState[0] - 2, currentState[1] + 1, currentState[2] + 2 }))
        {
            currentState[0] -= 2;
            currentState[1] += 1;
            currentState[2] += 2;
            DisplayCurrentState();
        }
        if (isRowOFSevens())
        {
            StopMakingPotion();
            ShowResult("win");
        }
    }
    public void AddStarDust()
    {
        if (isAcceptableTransformation(new int[3] { currentState[0] + 1, currentState[1] - 2, currentState[2] + 1 }))
        {
            currentState[0] += 1;
            currentState[1] -= 2;
            currentState[2] += 1;
            DisplayCurrentState();
        }
        if (isRowOFSevens())
        {
            StopMakingPotion();
            ShowResult("win");
        }
    }
    private bool isRowOFSevens()
    {
        for(int i = 0; i < 3; ++i)
        {
            if (currentState[i] != 7)
            {
                return false;
            }
        }
        return true;
    }
    private bool isAcceptableTransformation(int[] resultingState)
    {
        for (int i = 0; i < 3; ++i)
        {
            if (resultingState[i] < 0 || resultingState[i] > 10)
            {
                return false;
            }
        }
        return true;
    }
    public void ExitApplication()
    {
        Application.Quit();
    }
}
