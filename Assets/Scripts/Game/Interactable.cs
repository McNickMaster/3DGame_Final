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
            SetAllMaterialsEmmisive(GetComponentsInChildren<SkinnedMeshRenderer>(), true);
        } else 
        {
            SetAllMaterialsEmmisive(GetComponentsInChildren<MeshRenderer>(), true);
        }
    }

    public void DeSelect()
    {
        if(skinned)
        {
            SetAllMaterialsEmmisive(GetComponentsInChildren<SkinnedMeshRenderer>(), false);
        } else 
        {
            SetAllMaterialsEmmisive(GetComponentsInChildren<MeshRenderer>(), false);
        }
    }


    void SetAllMaterialsEmmisive(MeshRenderer[] renderers, bool emmisive)
    {
        Color color;
        color = emmisive ? selectedColor : Color.black;
        foreach(MeshRenderer rend in renderers)
        {
            rend.material.SetColor("_EmissionColor", color);
        }
    }

    void SetAllMaterialsEmmisive(SkinnedMeshRenderer[] renderers, bool emmisive)
    {
        Color color;
        color = emmisive ? selectedColor : Color.black;
        foreach(SkinnedMeshRenderer rend in renderers)
        {
            rend.material.SetColor("_EmissionColor", color);
        }
    }
}
