using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class CharacterCard : MonoBehaviour
{
    Character character;
    public string cardName;
    public Image cardImage;
    public string filepath;

    void Start()
    {
        cardName = character.characterName;

        if (string.IsNullOrEmpty(filepath))
        {
            filepath = EditorUtility.OpenFilePanelWithFilters("Select Cover Image", "", new string[]{ "Image files","png","All Files", "*"});
            Debug.Log("FilePath = " + filepath);
        }
        var loadedText = Texture2dLoadPNG(filepath);
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
