using BepInEx;
using GorillaLocomotion;
using GorillaNetworking;
using StupidTemplate.Menu;
using StupidTemplate.Mods;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using ExitGames.Client.Photon;
using GorillaExtensions;
using GorillaGameModes;
using GorillaLocomotion.Gameplay;
using GorillaTag.Shared.Scripts;
using GorillaTagScripts;
using GorillaTagScripts.ScavengerHunt;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.Unity;
using TMPro;
using UnityEngine.InputSystem;

namespace StupidTemplate.Mods
{
    internal class Troll_Fun
    {
        public static bool bothHands;
        public static void AutoFunnyRun()
        {
            bool flag = (double)ControllerInputPoller.instance.rightControllerIndexFloat >= 0.1;
            bool flag2 = flag;
            if (flag2)
            {
                bool flag3 = Main.bothHands;
                bool flag4 = flag3;
                if (flag4)
                {
                    float num = (float)Time.frameCount;
                    GorillaTagger.Instance.rightHandTransform.position = GorillaTagger.Instance.headCollider.transform.position + GorillaTagger.Instance.headCollider.transform.forward * Mathf.Cos(num) / 10f + new Vector3(0f, -0.5f - Mathf.Sin(num) / 7f, 0f) + GorillaTagger.Instance.headCollider.transform.right * -0.05f;
                    GorillaTagger.Instance.leftHandTransform.position = GorillaTagger.Instance.headCollider.transform.position + GorillaTagger.Instance.headCollider.transform.forward * Mathf.Cos(num + 180f) / 10f + new Vector3(0f, -0.5f - Mathf.Sin(num + 180f) / 7f, 0f) + GorillaTagger.Instance.headCollider.transform.right * 0.05f;
                }
                else
                {
                    float num2 = (float)Time.frameCount;
                    GorillaTagger.Instance.rightHandTransform.position = GorillaTagger.Instance.headCollider.transform.position + GorillaTagger.Instance.headCollider.transform.forward * Mathf.Cos(num2) / 10f + new Vector3(0f, -0.5f - Mathf.Sin(num2) / 7f, 0f);
                }
            }
        }




        public static void HoldRig()
        {
            bool flag = ControllerInputPoller.instance.rightGrab || UnityInput.Current.GetMouseButton(0);
            if (flag)
            {
                VRRig.LocalRig.enabled = false;
                VRRig.LocalRig.transform.position = GorillaTagger.Instance.rightHandTransform.transform.position;
                VRRig.LocalRig.transform.rotation = GorillaTagger.Instance.rightHandTransform.transform.rotation;
            }
            else
            {
                VRRig.LocalRig.enabled = true;
            }
        }



        public static void spinbot()
        {
            bool flag = ControllerInputPoller.instance.leftControllerIndexFloat >= 0.1 || ControllerInputPoller.instance.rightControllerIndexFloat >= 0.1;
            bool flag2 = flag;
            if (flag2)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.rotation = Quaternion.Euler(GorillaTagger.Instance.offlineVRRig.transform.rotation.eulerAngles + new Vector3(0f, 10f, 0f));
                GorillaTagger.Instance.offlineVRRig.transform.position = GTPlayer.Instance.headCollider.transform.position;
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * -1f;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * 1f;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void GhostMonke()
        {
            if(ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                Movement.ViewGhost();
                GorillaTagger.Instance.offlineVRRig.enabled = false;

            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void RigReset()
        {
            GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation *= Quaternion.Euler(GorillaTagger.Instance.offlineVRRig.leftHand.trackingRotationOffset);
            GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation *= Quaternion.Euler(GorillaTagger.Instance.offlineVRRig.rightHand.trackingRotationOffset);
        }
        public static void HelicopterMonke()
        {
            bool flag = ControllerInputPoller.instance.rightControllerGripFloat > 0.1f;
            bool flag2 = flag;
            if (flag2)
            {
                Movement.ViewGhost();
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position += new Vector3(0f, 0.05f, 0f);
                try
                {
                    GorillaTagger.Instance.myVRRig.transform.position += new Vector3(0f, 0.05f, 0f);
                }
                catch
                {
                }
                GorillaTagger.Instance.offlineVRRig.transform.rotation = Quaternion.Euler(GorillaTagger.Instance.offlineVRRig.transform.rotation.eulerAngles + new Vector3(0f, 10f, 0f));
                try
                {
                    GorillaTagger.Instance.myVRRig.transform.rotation = Quaternion.Euler(GorillaTagger.Instance.offlineVRRig.transform.rotation.eulerAngles + new Vector3(0f, 10f, 0f));
                }
                catch
                {
                }
                GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * -1f;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * 1f;
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
                Mods.Movement.RigReset();
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void UnlockComp()
        {
            GorillaComputer.instance.CompQueueUnlockButtonPress();
        }

        

        public static void LagRigSelf()
        {
            Movement.ViewGhost();
            bool flag = Time.time > Main.laggyRigDelay;
            bool flag2 = flag;
            if (flag2)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                Main.laggyRigDelay = Time.time + 0.211f;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
            }
        }
    }
}
