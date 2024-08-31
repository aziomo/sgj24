using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingInteract : MonoBehaviour
{
    private List<IInteract> interactables = new List<IInteract>();

    void Start()
    {
        // Find all objects that implement IInteract
        MonoBehaviour[] allObjects = FindObjectsOfType<MonoBehaviour>();
        foreach (MonoBehaviour obj in allObjects)
        {
            IInteract interactable = obj as IInteract;
            if (interactable != null)
            {
                interactables.Add(interactable);
            }
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Interact with all interactable objects found
            foreach (IInteract interactable in interactables)
            {
                interactable.Interact();
            }
        }
    }

}
