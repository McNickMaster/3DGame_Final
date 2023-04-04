using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public Color selectedColor;

    public abstract void Interact();

    public void Select()
    {
        GetComponentInChildren<MeshRenderer>().material.color = selectedColor;
    }

    public void DeSelect()
    {
        GetComponentInChildren<MeshRenderer>().material.color = Color.white;
    }
}
