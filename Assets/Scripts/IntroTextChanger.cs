using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroTextChanger : MonoBehaviour
{
    private string intro1 = "����������� ����� \"�������� ���\" - ������������ � ����� ���� ���������� �����������, " +
        "������������ ������� ����� ��������� �������. �� ���� �������� ���������� ����������� �����������, ������ ������ � ������������ ���� ������. ";
    private string intro2 = "��, ��� ������� �������� ������� � ������������ ����������������, �� ����� ������ ���� �������� � ������� ��������. " +
        "� ����������� ������ �������, � ����� � ����������� ����, ������� ��� ��� ������.\n" +
        "��� ���� �������� �� ������� �� ������� �������� ����� � �����.\n\n������� ��� ������ ���� ���������� � �����. ��������, �� ��� �� ��������!";

    [SerializeField] private Text introTextPlace;
    [SerializeField] private Text buttonTextPlace;
    [SerializeField] private GameObject introPanel;

    private void Start()
    {
        introTextPlace.text = intro1;
        buttonTextPlace.text = "�����";
    }
    public void FlipThroughIntro()
    {
        if (buttonTextPlace.text == "��������!")
        {
            introPanel.SetActive(false);
        }
        else
        {
            introTextPlace.text = intro2;
            buttonTextPlace.text = "��������!";
        }
    }
}
