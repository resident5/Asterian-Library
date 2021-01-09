using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "Page")]
public class Page : ScriptableObject
{
    Page page;
    public List<Sprite> mainImages;

    public int index;

    public string nameText;
    public string ageText;
    public string raceText;
    public string classText;

    [TextArea(2, 10)]
    public string descText;

    public string pagePath;

    public Page(string name, string age, string race, string clas, string desc, List<Sprite> sprites)
    {
        page = this;
        nameText = name;
        ageText = age;
        raceText = race;
        classText = clas;
        descText = desc;
        pagePath = "Assets\\Presets\\";
    }

    public void AddPageToFolder()
    {
        //AssetDatabase.MoveAsset("Asset\\" + page.name);
    }

}

[CustomEditor(typeof(Page))]
public class PageEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Page myTarget = (Page)target;

        if (myTarget.mainImages != null && string.IsNullOrEmpty(myTarget.nameText))
        {
            myTarget.nameText = myTarget.mainImages[0].name;
            myTarget.ageText = "18";
            myTarget.raceText = "Race";
            myTarget.classText = "Warrior";
            myTarget.descText = "Bacon Eater";
        }
    }
}
