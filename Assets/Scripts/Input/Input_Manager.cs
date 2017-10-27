﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input_Manager : MonoBehaviour {

    //Singleton
    private static Input_Manager inputManager;

    public static Input_Manager Instance()
    {
        if (!inputManager)
        {
            inputManager = FindObjectOfType(typeof(Input_Manager)) as Input_Manager;
            if (!inputManager)
                Debug.LogError("There needs to be at least one GameObject with an Input_Manager script attached to it!");
        }

        return inputManager;
    }

    [SerializeField]
    private Button[] phrasesButtons;

    private void Start()
    {
        if (phrasesButtons == null || phrasesButtons.Length == 0)
        {
            Debug.Log("Should add Buttons to Input Manager");

            Phrase_Selector[] tempPhraseSelector = FindObjectsOfType<Phrase_Selector>();

            phrasesButtons = new Button[tempPhraseSelector.Length];

            for (int i = 0; i < tempPhraseSelector.Length; i++)
            {
                phrasesButtons[i] = tempPhraseSelector[i].gameObject.GetComponent<Button>();
            }
        }

        for (int i = 0; i < phrasesButtons.Length; i++)
        {
            int temp = i;
            phrasesButtons[i].onClick.AddListener(() => ButtonPressed(phrasesButtons[temp].GetComponent<Phrase_Selector>()));
        }
    }

    public void ButtonPressed(Phrase_Selector phraseSelectorInButton)
    {

        //Todo a partir de aca es temporal
        //Debug.Log(phraseSelectorInButton.chosenPhrase.love);
        Nuevasfrases();

    }

    [SerializeField]
    private Phrase_Selector_Controller phraseSelectorController;

    private void Nuevasfrases()
    {
        phraseSelectorController.PickNewPhrases();
    }
}
