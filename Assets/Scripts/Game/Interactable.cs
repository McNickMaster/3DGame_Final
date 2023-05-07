using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public Color selectedColor;
    public bool skinned = true;
    public abstract void Interact();

    public void Select()
    {
        if(skinned)
        {
            GetComponentInChildren<SkinnedMeshRenderer>().material.color = selectedColor;
        } else 
        {
            GetComponentInChildren<MeshRenderer>().material.color = selectedColor;
        }
    }

    public void DeSelect()
    {
        if(skinned)
        {
            GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.white;
        } else 
        {
            GetComponentInChildren<MeshRenderer>().material.color = Color.white;
        }
    }
}
