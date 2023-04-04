using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public bool interactable = false;
    public GameObject interactableObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(interactable && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

    }

    void Interact()
    {
        interactableObject.GetComponent<Interactable>().Interact();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer.Equals(12))
        {
            interactable = true;
            interactableObject = other.gameObject;
            
            interactableObject.GetComponent<Interactable>().Select();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer.Equals(12))
        {
            interactable = false;
            interactableObject.GetComponent<Interactable>().DeSelect();
            interactableObject = null;
        }
    }


}
