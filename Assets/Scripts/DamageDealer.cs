using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;



    // ▬▬▬▬▬▬▬▬▬▬ "Getter" - "Get Damage()" Method ▬▬▬▬▬▬▬▬▬▬
    public int GetDamage()
    {
        // ▼ "Returns" the "Damage" variable's value ▼
        return damage;
    }



    // ▬▬▬▬▬▬▬▬▬▬ "Hit()" Method ▬▬▬▬▬▬▬▬▬▬
    public void Hit()
    {
        // ▼ "Destroys" the "Damage Dealer" Game Object ▼
        Destroy(gameObject);
    }
}
