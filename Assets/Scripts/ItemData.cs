using UnityEngine;

public enum ItemType
{
    Resource,
    Equipable,
    Consumable
}

public enum StatsToChange
{
    Stamina,
    Health,
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public string description;
    public ItemType type;
    public StatsToChange statsToChange = new StatsToChange();
    public float amountToChange;

    public void UseItem()
    {
        if (statsToChange == StatsToChange.Health)
        {
            CharacterManager.Instance.Player.condition.HealHP(amountToChange);
        }
    
    }





}

