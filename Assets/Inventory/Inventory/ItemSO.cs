using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public AttributeToChange attributeToChange = new AttributeToChange();
    public int amountToChangeAttribute;

    // Example of using an item in game to change stats
    //public void UseItem()
    //{
    //    return;
    //    if (statToChange == StatToChange.health)
    //    {
    //        GameObject.Find("HealthManager").GetComponent<PlayerHealth>().ChangeHealth(amountToChangeAttribute);
    //    }
    //}

    public enum StatToChange
    {
        none,
        health,
        mana,
        stamina
    };

    public enum AttributeToChange
    {
        none,
        attack,
        defense,
        agility,
        luck
    };
}
