using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class AddCharacters : MonoBehaviour
{
    public GameObject characterCard;
    public Transform characterCardContent;

    public void AddNewCharacterCard()
    {

        var obj = Instantiate(characterCard, characterCardContent);
        CharacterCard card = obj.GetComponent<CharacterCard>();
        card.coverImageFilePath = EditorUtility.OpenFilePanelWithFilters("Select Cover Image", "", new string[] { "Image files", "png", "All Files", "*" });

        card.character = setCharacterInfo();
    }

    Character setCharacterInfo()
    {
        Character newChar = new Character();

        newChar.picture = new Dictionary<string, string>();

        newChar.characterName = "Name";
        newChar.characterTitle = "Title";
        newChar.characterRace = "Race";
        newChar.characterAge = "Age 177";
        newChar.characterHeight = "Height";
        newChar.characterWeight = "Weight";
        newChar.characterClass = "Class";
        newChar.characterGender = "Gender";
        newChar.characterPronouns = "Pronouns";
        newChar.characterSex = "Sex";
        newChar.likes = "LINKING A LOT OF SHT";
        newChar.dislikes = "DISLINKING A LOT OF BAD SHT";
        newChar.trivia = "My butt is raw";

        return newChar;
    }
}
