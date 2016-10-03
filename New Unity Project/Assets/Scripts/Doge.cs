using UnityEngine;
using System.Collections;

public class Doge : Player {
    public GameObject projectile;
    protected override void UseAbility1()
    {
        Vector3 dir = transform.forward;

        Vector3 toOther = (other.transform.position - transform.position).normalized;

        if (Vector3.Dot(transform.forward, toOther) > 0.2f)
        {
            dir = toOther;
        }


        GameObject proj = Instantiate(projectile);
        proj.transform.position = transform.position + dir * 3;
        

        proj.GetComponent<Rigidbody>().velocity = dir * 40;
    }

    protected override void UseAbility2() {
        rb.AddTorque(0, 0, 10, ForceMode.VelocityChange);
    }
}
