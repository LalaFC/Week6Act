using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

[CreateAssetMenu (fileName = "HealthBuff", menuName = "PowerUps/HealthBuff")]
public class HealthBuff : PowerUPScriptable
{
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerMech>().Health += amount;
        PlayerPrefs.SetFloat("PlayerHP", target.GetComponent<PlayerMech>().Health);
        PlayerPrefs.Save();
    }
    public override void Remove(GameObject target)
    {
        throw new System.NotImplementedException();
    }
}
