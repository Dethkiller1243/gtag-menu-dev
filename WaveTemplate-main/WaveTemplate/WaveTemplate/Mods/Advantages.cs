using BepInEx;
using ExitGames.Client.Photon;
using GorillaExtensions;
using GorillaGameModes;
using GorillaLocomotion;
using GorillaLocomotion.Gameplay;
using GorillaNetworking;
using GorillaTag.Shared.Scripts;
using GorillaTagScripts;
using GorillaTagScripts.ScavengerHunt;
using GunlibMagic;
using HarmonyLib;
using MagicMod.Mods;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.Unity;
using PlayFab.ClientModels;
using StupidTemplate.Classes;
using StupidTemplate.Menu;
using StupidTemplate.Mods.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Valve.VR.InteractionSystem;
using static StupidTemplate.Menu.Main;

namespace MagicMod.Mods
{
    internal class Advantages
    {
        // Credits to velx for the tag code


        public static void TagPlayer(VRRig p)
        {
            if (p != GorillaTagger.Instance.offlineVRRig)
            {
                if (!p.mainSkin.material.name.Contains("fected"))
                {
                    GameMode.ReportTag(p.OwningNetPlayer);

                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = p.headConstraint.position;
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
        }

        public static void TagClosest()
        {
            VRRig closest = null;
            float closestDistance = float.MaxValue;
            foreach (VRRig p in VRRigCache.ActiveRigs)
            {
                if (p != GorillaTagger.Instance.offlineVRRig)
                {
                    float distance = Vector3.Distance(GorillaTagger.Instance.offlineVRRig.headConstraint.position, p.headConstraint.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closest = p;
                    }
                }
            }
            if (closest != null)
            {
                TagPlayer(closest);
            }
        }

        public static void GripTagArua()
        {
            bool inRoom = PhotonNetwork.InRoom;
            if (inRoom)
            {
                try
                {
                    bool rightGrip = (ControllerInputPoller.instance.rightGrab);
                    if (rightGrip)
                    {
                        foreach (VRRig vrrig in VRRigCache.ActiveRigs)
                        {
                            bool flag = vrrig != GorillaTagger.Instance.offlineVRRig;
                            if (flag)
                            {
                                bool flag2 = Vector3.Distance(GorillaTagger.Instance.rightHandTransform.transform.position, vrrig.transform.position) < 6f || Vector3.Distance(GorillaTagger.Instance.leftHandTransform.transform.position, vrrig.transform.position) < 6f;
                                if (flag2)
                                {
                                    GameMode.ReportTag(vrrig.OwningNetPlayer);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.Log(ex);
                }
            }
        }

        public static void NoTagFreeze()
        {
            GTPlayer.Instance.disableMovement = false;
        }


        public static void TagAll()
        {
            foreach (VRRig p in VRRigCache.ActiveRigs)
            {
                if (p != GorillaTagger.Instance.offlineVRRig)
                {
                    TagPlayer(p);
                }
            }
        }
        public static void TagGun()
        {
            Gunlib.StartBothGuns(() =>
            {
                TagPlayer(Gunlib.LockedPlayer);
            }, true);
        }
        public static void TagSelf()
        {
            if (ControllerInputPoller.instance.rightControllerTriggerButton)
            {
                if (!GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                {
                    foreach (VRRig rig in VRRigCache.ActiveRigs)
                    {
                        if (rig.mainSkin.material.name.Contains("fected"))
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            GorillaTagger.Instance.offlineVRRig.transform.position = rig.rightHandTransform.position;
                            GameMode.ReportTag(GorillaTagger.Instance.offlineVRRig.OwningNetPlayer);
                            break;
                        }
                    }
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }
    }
}
