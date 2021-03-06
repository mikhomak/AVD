﻿using CreatorKitCode;
using CreatorKitCodeInternal;
using UnityEngine;

public class GroundCrack : MonoBehaviour {
    [SerializeField] private int damage = 50;
    public void Start() {
        Destroy(gameObject, 4f);
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")) {
            CharacterData target = other.gameObject.GetComponent<SimpleEnemyController>().GetCharacterData();
            if (target == null) return;
            CharacterData playerData = CharacterControl.Instance.Data;

            Weapon.AttackData attackData = new Weapon.AttackData(target, playerData);
            attackData.AddDamage(StatSystem.DamageType.Fire, damage);
            target.Damage(attackData);
        }
    }
}