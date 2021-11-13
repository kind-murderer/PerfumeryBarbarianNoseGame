using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroTextChanger : MonoBehaviour
{
    private string intro1 = "Парфюмерная лавка \"Варварин нос\" - единственная в своем роде колдовская парфюмерная, " +
        "пользующаяся спросом среди множества гильдий. Их духи повышают магические способности волшебников, защиту воинов и мелодичность игры бардов. ";
    private string intro2 = "Вы, как большой любитель историй о приключениях путешественников, не могли пройти мимо листовки о горящей вакансии. " +
        "И подработать всегда неплохо, и ближе к магическому миру, который вас так пленит.\n" +
        "Все ночи выходных вы провели за чтением рецептов зелий и духов.\n\nСегодня ваш первый день стажировки в лавке. Покажите, на что вы способны!";

    [SerializeField] private Text introTextPlace;
    [SerializeField] private Text buttonTextPlace;
    [SerializeField] private GameObject introPanel;

    private void Start()
    {
        introTextPlace.text = intro1;
        buttonTextPlace.text = "ДАЛЕЕ";
    }
    public void FlipThroughIntro()
    {
        if (buttonTextPlace.text == "ХИМИЧИТЬ!")
        {
            introPanel.SetActive(false);
        }
        else
        {
            introTextPlace.text = intro2;
            buttonTextPlace.text = "ХИМИЧИТЬ!";
        }
    }
}
