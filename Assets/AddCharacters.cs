using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCharacters : MonoBehaviour
{
    public GameObject characterCard;
    public Transform characterCardContent;

    void AddNewCharacterCard()
    {
        var obj = Instantiate(characterCard, characterCardContent);
        CharacterCard card = obj.GetComponent<CharacterCard>();


    }
}
