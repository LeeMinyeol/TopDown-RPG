using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public  TMP_InputField inputName;
    public  TMP_Text playerName;
    public  string characterName = "Luna 0";
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        if (playerName != null)
        {
            playerName.text = PlayerPrefs.GetString("Name");

        }
        if (GameObject.FindWithTag("Player"))
        {
            player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"Resources/{characterName}.png");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
    public void ChooseCharacter(string name)
    {
        characterName = name;
        Console.WriteLine(characterName);

        if (GameObject.FindWithTag("Player"))
        {
            player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(characterName);
        }
    }
    public void SaveName()
    {
        PlayerPrefs.SetString("Name", inputName.text);
        playerName.text = PlayerPrefs.GetString("Name");
    }
}
