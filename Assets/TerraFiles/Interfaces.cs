using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth{
    public void TakeDamage(float damage);
    public void TakeHeal(float heal);
}

public interface IInteract
{
    public void Interact();
}
