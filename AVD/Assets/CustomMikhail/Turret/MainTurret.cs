using UnityEngine;

public class MainTurret : MonoBehaviour {
    private Turret turret;

    void Start() {
        turret = GetComponentInChildren<Turret>();
    }

    public void startShooting() {
        turret.startShooting();
    }

    public void stopShooting() {
        turret.selfDestroy();
    }
}