using System.Collections;
using System.Collections.Generic;
using CreatorKitCode;
using UnityEngine;

namespace CreatorKitCode 
{
    /// <summary>
    /// Base clase of all items in the game. This is an abstract class and need to be inherited to specify behaviour.
    /// The project offer 3 type of items : UsableItem, Equipment and Weapon
    /// </summary>
    public abstract class Item : ScriptableObject
    {
        public string ItemName;
        public Sprite ItemSprite;
        public string Description;
        public GameObject WorldObjectPrefab;

        /// <summary>
        /// Called by the inventory system when the object is "used" (double clicked)
        /// </summary>
        /// <param name="user">The CharacterDate that used that item</param>
        /// <returns>If it was actually used (allow the inventory to know if it can remove the object or not)</returns>
        public virtual bool UsedBy(CharacterData user)
        {
            return false;
        }

        public virtual string GetDescription()
        {
            return Description;
        }
    }
}

