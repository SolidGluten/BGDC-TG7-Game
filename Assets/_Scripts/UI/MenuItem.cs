using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject selectorIcon;
    public bool isHovered;
    public bool isHoverable;

    private void Awake()
    {
        selectorIcon.SetActive(false);
        isHoverable = true;
    }

    private void OnDisable()
    {
        selectorIcon.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isHoverable) return;
        isHovered = true;
        selectorIcon.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
        selectorIcon.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData) => OnSelect();

    public virtual void OnSelect()
    {

    }
}
