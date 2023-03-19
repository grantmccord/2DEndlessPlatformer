using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int attack, defense, agility, luck;

    [SerializeField] private TMP_Text attackText, defenseText, agilityText, luckText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateEquipmentStats();
    }

    public void UpdateEquipmentStats()
    {
        attackText.text = attack.ToString();
        defenseText.text = defense.ToString();
        agilityText.text = agility.ToString();
        luckText.text = luck.ToString();
    }
}
