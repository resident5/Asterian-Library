using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSheet : MonoBehaviour
{
    public Character character;

    public TMP_Text characterName;
    public TMP_Text characterTitle;
    public TMP_Text characterRace;
    public TMP_Text characterAge;
    public TMP_Text characterHeight;
    public TMP_Text characterWeight;
    public TMP_Text characterClass;
    public TMP_Text characterGender;
    public TMP_Text characterPronouns;
    public TMP_Text characterSex;
    public TMP_Text likes;
    public TMP_Text dislikes;
    public TMP_Text trivia;

    public void SetInformation()
    {
        characterName.text = character.characterName;
        characterTitle.text = character.characterTitle;
        characterRace.text = character.characterRace;
        characterAge.text = character.characterAge;
        characterHeight.text = character.characterHeight;
        characterWeight.text = character.characterWeight;
        characterClass.text = character.characterClass;
        characterGender.text = character.characterGender;
        characterPronouns.text = character.characterPronouns;
        characterSex.text = character.characterSex;
        likes.text = character.likes;
        dislikes.text = character.dislikes;
        trivia.text = character.trivia;

    }

    public void Clear()
    {

    }

}
