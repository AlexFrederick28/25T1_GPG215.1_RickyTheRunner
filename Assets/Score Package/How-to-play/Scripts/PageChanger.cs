using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class PageChanger : MonoBehaviour
{

    #region Variables

    [Tooltip("Game objects that are used for the pages")]
    [SerializeField] private GameObject[] PagesToFlip; // list to manage all the pages in one variable
    [SerializeField] private int pageNumber; // page number used to keep track of page number


    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DeactivateObjects());
         // turn off all pages initially

        pageNumber = 0;
        SetPageToLoadActive();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPageToLoadActive() // loads a specific page
    {        
        PagesToFlip[pageNumber].SetActive(true);
        Debug.Log("New page active");
    }

    public IEnumerator DeactivateObjects() // set all objects "pages" off
    {
        foreach (GameObject page in PagesToFlip)
        page.SetActive(false);

        yield return null;
    }

    public void LoadNextPage()
    {
        if (pageNumber < PagesToFlip.Length - 1)
        {
            pageNumber++; // set target next page
            StartCoroutine(DeactivateObjects()); // turn off everything
            SetPageToLoadActive(); // load page
        }

        else
        {
            Debug.Log("cannot load next page");
        }

    }

    public void LoadPreviousPage()
    {
        if (pageNumber > 0)
        {
            pageNumber--; // set target prevuiys page
            StartCoroutine(DeactivateObjects()); // turn off everything
            SetPageToLoadActive(); // load page
        }

        else
        {
            Debug.Log("cannot load previous page");
        }

    }

}
