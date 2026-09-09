using HarmonyLib;
using MagicMod.Mods;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace StupidTemplate.Classes
{
    // Token: 0x02000046 RID: 70
    public class RigManager
    {
        // Token: 0x06000178 RID: 376 RVA: 0x0000A531 File Offset: 0x00008731
        public static VRRig GetVRRigFromPlayer(Player p)
        {
            return GorillaGameManager.instance.FindPlayerVRRig(p);
        }

        // Token: 0x06000179 RID: 377 RVA: 0x0000A544 File Offset: 0x00008744
        public static VRRig GetRandomVRRig(bool includeSelf)
        {
            VRRig[] array = GameObject.FindObjectsOfType<VRRig>();
            List<VRRig> list = new List<VRRig>();
            foreach (VRRig vrrig in array)
            {
                bool flag = includeSelf || vrrig != VRRig.LocalRig;
                if (flag)
                {
                    list.Add(vrrig);
                }
            }
            bool flag2 = list.Count == 0;
            VRRig result;
            if (flag2)
            {
                result = null;
            }
            else
            {
                result = list[UnityEngine.Random.Range(0, list.Count)];
            }
            return result;
        }

        // Token: 0x0600017A RID: 378 RVA: 0x0000A5C4 File Offset: 0x000087C4
        public static VRRig GetClosestVRRig()
        {
            float num = float.MaxValue;
            VRRig result = null;
            VRRig[] array = GameObject.FindObjectsOfType<VRRig>();
            foreach (VRRig vrrig in array)
            {
                bool flag = vrrig == VRRig.LocalRig;
                if (!flag)
                {
                    float num2 = Vector3.Distance(GorillaTagger.Instance.bodyCollider.transform.position, vrrig.transform.position);
                    bool flag2 = num2 < num;
                    if (flag2)
                    {
                        num = num2;
                        result = vrrig;
                    }
                }
            }
            return result;
        }

        // Token: 0x0600017B RID: 379 RVA: 0x0000A652 File Offset: 0x00008852
        public static PhotonView GetPhotonViewFromVRRig(VRRig p)
        {
            return (PhotonView)Traverse.Create(p).Field("photonView").GetValue();
        }

        // Token: 0x0600017C RID: 380 RVA: 0x0000A670 File Offset: 0x00008870
        public static Player GetRandomPlayer(bool includeSelf)
        {
            Player result;
            if (includeSelf)
            {
                result = PhotonNetwork.PlayerList[UnityEngine.Random.Range(0, PhotonNetwork.PlayerList.Length - 1)];
            }
            else
            {
                result = PhotonNetwork.PlayerListOthers[UnityEngine.Random.Range(0, PhotonNetwork.PlayerListOthers.Length - 1)];
            }
            return result;
        }

        // Token: 0x0600017D RID: 381 RVA: 0x0000A6B4 File Offset: 0x000088B4
        public static Player GetPlayerFromVRRig(VRRig p)
        {
            return RigManager.GetPhotonViewFromVRRig(p).Owner;
        }

        // Token: 0x0600017E RID: 382 RVA: 0x0000A6C4 File Offset: 0x000088C4
        public static Player GetPlayerFromID(string id)
        {
            Player result = null;
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                bool flag = player.UserId == id;
                if (flag)
                {
                    result = player;
                    break;
                }
            }
            return result;
        }

        public static bool RigIsInfected(VRRig vrrig)
        {
            bool flag = vrrig == null || vrrig.mainSkin == null || vrrig.mainSkin.material == null;
            bool result;
            if (flag)
            {
                result = false;
            }
            else
            {
                string name = vrrig.mainSkin.material.name;
                result = (name.Contains("fected") || name.Contains("It"));
            }
            return result;
        }


        // Token: 0x0600017F RID: 383 RVA: 0x0000A710 File Offset: 0x00008910
        public static Color GetPlayerColor(VRRig Player)
        {
            bool flag;
            if (Player != null)
            {
                Transform transform = Player.transform.Find("BodyMesh");
                flag = (transform != null && transform.name.ToLower().Contains("skeleton"));
            }
            else
            {
                flag = false;
            }
            bool flag2 = flag;
            Color result;
            if (flag2)
            {
                result = Color.green;
            }
            else
            {
                int setMatIndex = Player.setMatIndex;
                int num = setMatIndex;
                switch (num)
                {
                    case 1:
                        return Color.red;
                    case 2:
                        break;
                    case 3:
                    case 7:
                        return Color.blue;
                    case 4:
                    case 5:
                    case 6:
                        goto IL_B6;
                    default:
                        if (num != 11)
                        {
                            if (num != 12)
                            {
                                goto IL_B6;
                            }
                            return Color.green;
                        }
                        break;
                }
                return new Color32(byte.MaxValue, 128, 0, byte.MaxValue);
            IL_B6:
                result = Player.playerColor;
            }
            return result;
        }
    }
}
