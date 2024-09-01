using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour, IHealth{
    public float hp = 100;
    [SerializeField] private GameObject _splashVfx;
    [SerializeField] private GameObject _deathVfx;
    public void TakeDamage(float damage){
        hp -= damage;
        if(hp <= 0){
            // tu enumerator do animacji śmierci kerfusia
            GameManager.Instance.ConditionCalled();
            Instantiate(_deathVfx, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_splashVfx, Sausage.Active.transform.position, Quaternion.identity);
        }
    }
    public void TakeHeal(float heal){}

}
