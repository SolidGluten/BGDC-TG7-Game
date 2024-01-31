using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public List<MenuItem> menuItems;
    public MenuItem currentItemSelected;
    public int currentItemIndex = 0;

    private void Start()
    {
        currentItemIndex = 0;
        currentItemSelected = menuItems[currentItemIndex];
        //currentItemSelected.Selected();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectMenu();
        }
    }

    public void ChangeMenu(bool isUp)
    {
        //currentItemSelected.Unselect();
        currentItemIndex += isUp ? -1 : 1;
        currentItemIndex %= menuItems.Count;
        if (currentItemIndex < 0) currentItemIndex = menuItems.Count - 1;
        currentItemSelected = menuItems[currentItemIndex];
        //currentItemSelected.Selected();
    }

    public void SelectMenu()
    {
        menuItems[currentItemIndex].OnSelect();
    }
}
