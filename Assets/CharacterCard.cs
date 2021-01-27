using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using System;
using TMPro;

[Serializable]
public class CharacterCard : MonoBehaviour
{
    public Character character;
    public CharacterSheet sheet;
    public CharacterPlate plate;
    public Image cardImage;
    public string coverImageFilePath;

    public Button button;
    public TMP_Text nameText;

    private void Awake()
    {
        plate = transform.parent.parent.parent.GetComponent<CharacterPlate>();
        sheet = plate.characterSheet;

    }

    void Start()
    {
        nameText.text = character.characterName;

        if (string.IsNullOrEmpty(coverImageFilePath))
        {
            Debug.Log("FilePath = " + coverImageFilePath);
        }

        SetCoverImage();
    }

    public void ShowCharacterInfo()
    {
        sheet.gameObject.SetActive(true);
        sheet.character = character;
        sheet.SetInformation();
    }

    void SetCoverImage()
    {
        var loadedText = Texture2dLoadPNG(coverImageFilePath);
        var createdSprite = Sprite.Create(loadedText, new Rect(0, 0, loadedText.width, loadedText.height), Vector2.zero);
        cardImage.sprite = createdSprite;

    }

    Texture2D Texture2dLoadPNG(string filepath)
    {
        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filepath))
        {
            fileData = File.ReadAllBytes(filepath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
        }

        return tex;
    }

}
