using System;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField]
    private int _highlightIntensity = 4;  
    [SerializeField] private Transform _inventoryHolder;
    private Outline _outline;
    private Collider _collider;
    public bool isLifted { get; private set; } = false;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
        _collider = GetComponent<Collider>();
    }

    public void SetFocus()
    {
        _outline.OutlineWidth = _highlightIntensity;
    }
    
    public void RemoveFocus()
    {
        _outline.OutlineWidth = 0;
    }

    public void ChangeLiftedStatus()
    {
        isLifted = !isLifted;
    }

    private void Update()
    {
        if (isLifted)
        {
            transform.position = _inventoryHolder.transform.position;
            _collider.enabled = false;
        }
        else
        {
            _collider.enabled = true;
        }
    }
}