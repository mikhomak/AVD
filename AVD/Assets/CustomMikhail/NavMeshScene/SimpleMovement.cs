using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(NavMeshAgent))]
public class SimpleMovement : MonoBehaviour {
    private Animator animator;
    private NavMeshAgent agent;
    RaycastHit hitInfo = new RaycastHit();

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate() {
        if (Input.GetMouseButton(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo)) {
                agent.destination = hitInfo.point;
            }
        }
    }

}