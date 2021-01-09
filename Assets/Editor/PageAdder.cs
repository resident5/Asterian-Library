using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Windows.Forms;

public class PageAdder : EditorWindow
{
    string nameText;
    string ageText;
    string raceText;
    string classText;

    string descText;

    [SerializeField] List<Sprite> imageAssets;

    [UnityEditor.MenuItem("Art Tools/Add Pages and Slides")]
    public static void ShowWindow()
    {
        EditorWindow editor = EditorWindow.GetWindow<PageAdder>();
        editor.titleContent = new GUIContent("Add Pages");
    }

    private void OnGUI()
    {
        //imageAssets = (DefaultAsset)EditorGUILayout.ObjectField("List of Pictures", imageAssets, typeof(DefaultAsset), true);

        SerializedObject serializeImageAsset = new SerializedObject(this);
        SerializedProperty imageProperty = serializeImageAsset.FindProperty("imageAssets");

        EditorGUILayout.PropertyField(imageProperty, true); // True means show children
        serializeImageAsset.ApplyModifiedProperties(); // Remember to apply modified properties

        

        nameText = EditorGUILayout.TextField("Character Name: ", nameText);
        ageText = EditorGUILayout.TextField("Character Age: ", ageText);
        raceText = EditorGUILayout.TextField("Character Race: ", raceText);
        classText = EditorGUILayout.TextField("Character Class: ", classText);
        descText = EditorGUILayout.TextField("Character Description: ", descText);

        if (GUILayout.Button("Search For Files"))
        {
            SearchForFiles();
        }

        if (GUILayout.Button("Create Page"))
        {
            //Find a way to create a page scriptable object and move it to the Assets/Preset/ folder
            
            /*
            Page page = new Page(nameText, ageText, raceText, classText, descText, imageAssets);  //new Page(nameText, ageText, raceText, classText, descText, imageAssets);
            
            AssetDatabase.CreateAsset(page, page.pagePath + page.name);
            */
        }

    }

    void SearchForFiles()
    {
        //string pathToCopy = EditorUtility.OpenFilePanel("File to import", "", "");
        string destinationPath = "D:/Projects/Github Repos/Asterian-Library/Assets/Sprites/";
        string unityPath = "Assets\\Sprites\\";

        OpenFileDialog ofd = new OpenFileDialog();
        //ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
        ofd.Multiselect = true;
        ofd.Title = "Select multiple images";

        DialogResult dr = ofd.ShowDialog();

        if (dr == DialogResult.OK)
        {
            foreach (string pathToCopy in ofd.FileNames)
            {
                File.Copy(pathToCopy, destinationPath + Path.GetFileName(pathToCopy));
                string importedFileName = pathToCopy.Remove(0, pathToCopy.LastIndexOf("\\") + 1);

                AssetDatabase.Refresh();

                var importedAsset = AssetDatabase.LoadAssetAtPath(unityPath + importedFileName, typeof(Sprite)) as Sprite;

                imageAssets.Add(importedAsset);

            }
        }
    }
}
