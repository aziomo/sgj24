using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingInteract : MonoBehaviour{
    public static TestingInteract instance;
    public List<SampleI> interactables = new();
    void Start(){
        instance = this;
        SampleI[] allObjects = FindObjectsOfType<SampleI>();
        interactables.AddRange(allObjects);
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.E)){
            for(int i = 0; i < interactables.Count; i++){
                interactables[i].Interact(); 
            }
        }
    }
}
