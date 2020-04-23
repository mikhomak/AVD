using System;
using System.Collections;
using System.Collections.Generic;
using CreatorKitCode;
using UnityEngine;
using Random = UnityEngine.Random;


namespace CreatorKitCode 
{
    /// <summary>
    /// This class handle creating loot. It got a list of events and each events have a list of items with associated
    /// weight. When the spawn is triggered through the SpawnLoot function, it will spawn one item per events, with the
    /// item being picked randomly per event 
    /// </summary>
    public class LootSpawner : MonoBehaviour
    {
        [System.Serializable]
        public class SpawnEvent
        {
            public LootEntry[] Entries;
        }
    
        [System.Serializable]
        public class LootEntry
        {
            public int Weight = 1;
            public Item Item;
        }

        class InternalPurcentageEntry
        {
            public LootEntry Entry;
            public float Percentage;
        }
    
        public SpawnEvent[] Events;
        public AudioClip SpawnedClip;
    
        /// <summary>
        /// Call this to trigger the spawning of the loot. Will spawn one item per event, picking the item randomly
        /// per event using the defined weight. Every call will pick randomly again (but most of the time, the caller
        /// will destroy the LootSpawner too as you spawn loot from something only once)
        /// </summary>
        public void SpawnLoot()
        {
            Vector3 position = transform.position;
            SFXManager.PlaySound(SFXManager.Use.WorldSound, new SFXManager.PlayData()
            {
                Clip = SpawnedClip,
                Position = position
            });
        
            //we go over all the events.
            for (int i = 0; i < Events.Length; ++i)
            {
                SpawnEvent Event = Events[i];

                //first iterate over all object to make a total weight value.
                int totalWeight = 0;
                foreach (var entry in Event.Entries)
                {
                    totalWeight += entry.Weight;
                }

                //if we don't have any weight just exit
                if (totalWeight == 0)
                    continue;

                //then go back again on all the object to build a lookup table based on percentage.
                List<InternalPurcentageEntry> lookupTable = new List<InternalPurcentageEntry>();
                float previousPercent = 0.0f;
                foreach (var entry in Event.Entries)
                {
                    float percent = entry.Weight / (float)totalWeight;
                    InternalPurcentageEntry percentageEntry = new InternalPurcentageEntry();
                    percentageEntry.Entry = entry;
                    percentageEntry.Percentage = previousPercent + percent;

                    previousPercent = percentageEntry.Percentage;
                
                    lookupTable.Add(percentageEntry);
                }
            
                float rng = Random.value;
                for (int k = 0; k < lookupTable.Count; ++k)
                {
                    if (rng <= lookupTable[k].Percentage)
                    {
                        GameObject obj = new GameObject(lookupTable[k].Entry.Item.ItemName);
                        //GameObject obj = Instantiate(lookupTable[k].Entry.Item.WorldObjectPrefab);
                        var l = obj.AddComponent<Loot>();
                        l.Item = lookupTable[k].Entry.Item;
                    
                        l.Spawn(position);
                    
                        break;
                    }
                }
            }
        }
    }
}

