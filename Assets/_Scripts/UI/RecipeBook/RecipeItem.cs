using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RecipeItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public FoodScriptable food;
    public Image recipeImg;
    public GameObject textBox;
    public TextMeshProUGUI textMesh;

    private void Awake()
    {
        recipeImg.sprite = food._foodSprite;
        textMesh.text = food._foodName;
    }

    private void Start()
    {
        textBox.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textBox.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        textBox.SetActive(false);
    }
}
