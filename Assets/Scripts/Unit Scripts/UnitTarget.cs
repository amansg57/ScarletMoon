using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Handles the targetting object attached to each Unit
public class UnitTarget : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public TargetSystem targetSystem;
    private Image image;
    private BoxCollider2D boxCollider2D;
    private Unit _unit;

    public int ID {get; set;}

    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        _unit = gameObject.GetComponentInParent<Unit>();
        ID = _unit.ID;
        AddToTargetSystem();
    }

    public void EnableTarget()
    {
        image.enabled = true;
        boxCollider2D.enabled = true;
    }

    public void DisableTarget()
    {
        image.enabled = false;
        boxCollider2D.enabled = false;
    }

    public Unit UnitParent
    {
        get => _unit;
    }

    public virtual void AddToTargetSystem() {}

    public void OnPointerClick(PointerEventData eventData)
    {
        targetSystem.SendTarget(_unit);
    }
    
    // These have to be implemented in order for OnPointerClick to work it seems
    public void OnPointerDown(PointerEventData eventData) {}

    public void OnPointerUp(PointerEventData eventData) {}

}
