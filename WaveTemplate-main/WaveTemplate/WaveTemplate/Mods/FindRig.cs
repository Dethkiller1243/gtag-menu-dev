using System;
using System.Collections.Generic;
using UnityEngine;

internal class FindRig : MonoBehaviour
{
    public static VRRig[] GetAll()
    {
        bool flag = Time.time > FindRig.nextUpdate || FindRig.allRigs == null;
        if (flag)
        {
            FindRig.allRigs = GameObject.FindObjectsOfType<VRRig>();
            FindRig.nextUpdate = Time.time + 2f;
        }
        return FindRig.allRigs;
    }

    public static IEnumerable<VRRig> GetRigs()
    {
        VRRig[] rigs = FindRig.GetAll();
        int num;
        for (int i = 0; i < rigs.Length; i = num + 1)
        {
            VRRig rig = rigs[i];
            bool flag = rig == null;
            if (!flag)
            {
                bool flag2 = rig.OwningNetPlayer != null;
                if (flag2)
                {
                    yield return rig;
                }
                rig = null;
            }
            num = i;
        }
        yield break;
    }

    private static VRRig[] allRigs;
    private static float nextUpdate;
}
