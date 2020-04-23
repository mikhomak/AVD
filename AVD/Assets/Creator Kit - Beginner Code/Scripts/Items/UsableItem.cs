using System.Collections;
using System.Collections.Generic;
using CreatorKitCode;
using UnityEngine;
using System.Linq;


namespace CreatorKitCode {
    /// <summary>
    /// Describe an usable item. A usable item is an item that can be used in the inventory by double clicking on it.
    /// When it is used, all the stored UsageEffects will be run, allowing to specify what that item does.
    /// (e.g. a AddHealth effect will give health point back to the user)
    /// </summary>
    [CreateAssetMenu(fileName = "UsableItem", menuName = "Beginner Code/Usable Item", order = -999)]
    public class UsableItem : Item
    {
        public abstract class UsageEffect : ScriptableObject
        {
            public string Description;
            //return true if could be used, false otherwise.
            public abstract bool Use(CharacterData user);
        }

        public List<UsageEffect> UsageEffects;

        public override bool UsedBy(CharacterData user)
        {
            bool wasUsed = false;
            foreach (var effect in UsageEffects)
            {
                wasUsed |= effect.Use(user);
            }
        
            return wasUsed;
        }

        public override string GetDescription()
        {
            string description = base.GetDescription();
        
            if(!string.IsNullOrWhiteSpace(description))
                description += "\n";
            else
                description = "";

        
            foreach (var effect in UsageEffects)
            {
                description += effect.Description + "\n";
            }

            return description;
        }
    }
}

