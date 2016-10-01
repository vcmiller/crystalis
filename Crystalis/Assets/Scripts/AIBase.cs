using UnityEngine;
using System.Collections;

public class AIBase : MonoBehaviour {
    public Waypoint waypoint;
    private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = agent.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    if (agent.remainingDistance < 0.2f) {
            if (waypoint != null) {
                waypoint = waypoint.next;
                agent.destination = waypoint.transform.position;
            }
        }
	}
}
