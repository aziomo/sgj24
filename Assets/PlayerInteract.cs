using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour{
    public List<IInteract> items = new();
    private void OnTriggerEnter(Collider col){
        if(col.TryGetComponent(out IInteract interact)){
            if(!items.Contains(interact)){
                items.Add(interact);
            }
        }
    }
    private void OnTriggerExit(Collider col){
        if(col.TryGetComponent(out IInteract interact)){
            if(items.Contains(interact)){
                items.Remove(interact);
            }
        }
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            foreach(IInteract interact in items){
                interact.Interact();
            }
            items.Clear();
        }
    }
}
