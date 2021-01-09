using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionPageList : MonoBehaviour
{
    public PageTemplate template;
    public List<Page> pages;

    public delegate void OnPageUpdate();
    public OnPageUpdate pageChanged;

    public int currentPageIndex = 0;

    void Start()
    {
        pageChanged += template.UpdatePage;
        template.currentPage = pages[0];
        pageChanged();
    }

    public void NextPage()
    {
        if (currentPageIndex < pages.Count - 1)
        {
            template.index = 0;
            template.currentPage = pages[++currentPageIndex];
            pageChanged();
            template.CheckSprite();
        }
        else
        {
            Debug.Log("There are no more pages");
        }
    }

    public void PreviousPage()
    {
        if (currentPageIndex > 0)
        {
            template.index = 0;
            template.currentPage = pages[--currentPageIndex];
            pageChanged();
            template.CheckSprite();
        }
        else
        {
            Debug.Log("This is the first page");
        }
    }


}
