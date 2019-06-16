using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "Page")]
public class Page : ScriptableObject
{
    public Sprite mainImage;

    public string nameText;
    public string ageText;
    public string raceText;
    public string classText;

    [TextArea(2, 10)]
    public string descText;
}

[CustomEditor(typeof(Page))]
public class PageEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Page myTarget = (Page)target;

        if (myTarget.mainImage != null && string.IsNullOrEmpty(myTarget.nameText))
        {
            myTarget.nameText = myTarget.mainImage.name;
            myTarget.ageText = "18";
            myTarget.raceText = "Race";
            myTarget.classText = "Warrior";
            myTarget.descText = "Bacon Eater";
        }
    }
}
