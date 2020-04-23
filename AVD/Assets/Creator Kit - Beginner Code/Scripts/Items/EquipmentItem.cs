using System.Collections.Generic;
using CreatorKitCode;
using UnityEngine;
using System.Linq;



namespace CreatorKitCode 
{
    /// <summary>
    /// Special Item than can be equipped. They can have a minimum stats value needed to equip them, and you can add
    /// EquippedEffect which will be executed when the object is equipped and unequipped, allowing to code special
    /// behaviour when the player equipped those object, like raising stats.
    /// </summary>
    [CreateAssetMenu(fileName = "EquipmentItem", menuName = "Beginner Code/Equipment Item", order = -999)]
    public class EquipmentItem : Item
    {
        public enum EquipmentSlot
        {
            Head,
            Torso,
            Legs,
            Feet,
            Accessory
        }
    
        public abstract class EquippedEffect : ScriptableObject
        {
            public string Description;
            //return true if could be used, false otherwise.
            public abstract void Equipped(CharacterData user);
            public abstract void Removed(CharacterData user);
  
            public virtual string GetDescription()
            {
                return Description;
            }
        }

        public EquipmentSlot Slot;
    
        [Header("Minimum Stats")]
        public int MinimumStrength;
        public int MinimumAgility;
        public int MinimumDefense;

        public List<EquippedEffect> EquippedEffects;
    
        public override bool UsedBy(CharacterData user)
        {
            var userStat = user.Stats.stats;

            if (userStat.agility < MinimumAgility
                || userStat.strength < MinimumStrength
                || userStat.defense < MinimumDefense)
            {
                return false;
            }

            user.Equipment.Equip(this);
        
            return true;
        }

        public override string GetDescription()
        {
            string desc = base.GetDescription();

            foreach (var effect in EquippedEffects)
                desc += "\n" + effect.GetDescription();
        
            bool requireStrength = MinimumStrength > 0;
            bool requireDefense = MinimumDefense > 0;
            bool requireAgility = MinimumAgility > 0;

            if (requireStrength || requireAgility || requireDefense)
            {
                desc += "\nRequire : \n";

                if (requireStrength)
                    desc += $"Strength : {MinimumStrength}";

                if (requireAgility)
                {
                    if (requireStrength) desc += " & ";
                    desc += $"Defense : {MinimumDefense}";
                }
            
                if (requireDefense)
                {
                    if (requireStrength || requireAgility) desc += " & ";
                    desc += $"Agility : {MinimumAgility}";
                }
            }

            return desc;
        }


        public void EquippedBy(CharacterData user)
        {
            foreach (var effect in EquippedEffects)
                effect.Equipped(user);
        }
    
        public void UnequippedBy(CharacterData user)
        {
            foreach (var effect in EquippedEffects)
                effect.Removed(user);
        }
    }
}
