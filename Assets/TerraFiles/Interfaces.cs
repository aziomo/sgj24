using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth{
    public void TakeDamage(float damage);
    public void TakeHeal(float heal);
    public void TakeKnockBack(float force ,Vector3 dir);
}

public interface IInteract{
    public void Interact();
    public GameObject GetObjectReference();
}
