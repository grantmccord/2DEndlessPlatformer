using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EquipmentSO : ScriptableObject
{
    public string itemName;
    public int attack, defense, agility, luck;

    public void EquipItem()
    {
        //Update Stats
        PlayerStats playerStats = GameObject.Find("StatManager").GetComponent<PlayerStats>();
        playerStats.attack += attack;
        playerStats.defense += defense;
        playerStats.agility += agility;
        playerStats.luck += luck;

        playerStats.UpdateEquipmentStats();
    }

    public void UnEquipItem()
    {
        //Update Stats
        PlayerStats playerStats = GameObject.Find("StatManager").GetComponent<PlayerStats>();
        playerStats.attack -= attack;
        playerStats.defense -= defense;
        playerStats.agility -= agility;
        playerStats.luck -= luck;

        playerStats.UpdateEquipmentStats();
    }
}
