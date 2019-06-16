using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PageTemplate : MonoBehaviour
{
    public Image image;
    public TMP_Text nameTMP;
    public TMP_Text ageTMP;
    public TMP_Text raceTMP;
    public TMP_Text classTMP;
    public TMP_Text descTMP;

    public Page currentPage;

    public void UpdatePage()
    {
        image.sprite = currentPage.mainImage;

        nameTMP.text = "Name: " + currentPage.nameText;
        ageTMP.text = "Age: " + currentPage.ageText;
        raceTMP.text = "Race: " + currentPage.raceText;
        classTMP.text = "Class: " + currentPage.classText;

        descTMP.text = currentPage.descText;

    }

}
