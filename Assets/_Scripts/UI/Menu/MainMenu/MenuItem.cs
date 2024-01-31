using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject selectorIcon;

    private void Start()
    {
        selectorIcon.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData) => selectorIcon.SetActive(true);
    public void OnPointerExit(PointerEventData eventData) => selectorIcon.SetActive(false);
    public void OnPointerClick(PointerEventData eventData) => OnSelect();
    public virtual void OnSelect()
    {

    }
}
