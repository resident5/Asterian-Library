using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PageTemplate : MonoBehaviour
{
    public delegate void OnSlideUpdate();
    public OnSlideUpdate slideChanged;

    public Image image;
    public int index = 0;

    public TMP_Text nameTMP;
    public TMP_Text ageTMP;
    public TMP_Text raceTMP;
    public TMP_Text classTMP;
    public TMP_Text descTMP;

    public Page currentPage;

    public int lowResMultiplier;
    public int highResMultiplier;

    public void UpdatePage()
    {
        try
        {
            image.sprite = currentPage.mainImages[index];
        }
        catch
        {
            Debug.LogError(currentPage.name + " does not have images to display");
        }


        nameTMP.text = "Name: " + currentPage.nameText;
        ageTMP.text = "Age: " + currentPage.ageText;
        raceTMP.text = "Race: " + currentPage.raceText;
        classTMP.text = "Class: " + currentPage.classText;

        descTMP.text = currentPage.descText;

    }

    public void NextSlide()
    {
        if (currentPage.mainImages.Count > 1 && index < currentPage.mainImages.Count - 1)
        {
            image.sprite = currentPage.mainImages[++index];
        }
        else
        {
            Debug.Log("This is the last slide");
        }

        CheckSprite();

    }

    public void PreviousSlide()
    {
        if (index > 0)
        {
            image.sprite = currentPage.mainImages[--index];
        }
        else
        {
            Debug.Log("This is the first slide");
        }
        CheckSprite();
    }

    public void CheckSprite()
    {
        Vector2 spriteResolution = image.sprite.bounds.size;
        Ratio ratio = new Ratio(spriteResolution.x, spriteResolution.y);


        //Debug.Log("X: " + ratio.width + " Y: " + ratio.height);

        if (ratio.width > 15)
        {
            image.rectTransform.sizeDelta = new Vector2(ratio.width * highResMultiplier, ratio.height * highResMultiplier);
        }
        else
        {
            image.rectTransform.sizeDelta = new Vector2(ratio.width * lowResMultiplier, ratio.height * lowResMultiplier);
        }
    }

    public struct Ratio
    {
        public float width;
        public float height;

        public Ratio(float w, float h)
        {
            width = w;
            height = h;
        }
    }
}
