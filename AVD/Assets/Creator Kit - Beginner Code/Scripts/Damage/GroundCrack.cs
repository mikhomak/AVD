using CreatorKitCode;
using CreatorKitCodeInternal;
using UnityEngine;

public class GroundCrack : MonoBehaviour {
    public void Start() {
        Destroy(gameObject, 6.7f);
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")) {
            CharacterData target = other.gameObject.GetComponent<SimpleEnemyController>().GetCharacterData();
            if (target == null) return;
            CharacterData playerData = CharacterControl.Instance.Data;

            Weapon.AttackData attackData = new Weapon.AttackData(target, playerData);
            attackData.AddDamage(StatSystem.DamageType.Fire, 50);
            target.Damage(attackData);
        }
    }
}