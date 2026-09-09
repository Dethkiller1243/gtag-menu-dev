using GorillaLocomotion;
using StupidTemplate.Classes;
using StupidTemplate.Notifications;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.XR;
using static StupidTemplate.Classes.RigManager;
using static StupidTemplate.Menu.Main;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using GorillaNetworking;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using PlayFab;
using PlayFab.Internal;
using UnityEngine.InputSystem;

namespace StupidTemplate.Mods
{
    public class Safety
    {
        public static void NoFingerMovement()
        {
            ControllerInputPoller.instance.leftControllerGripFloat = 0f;
            ControllerInputPoller.instance.rightControllerGripFloat = 0f;
            ControllerInputPoller.instance.leftControllerIndexFloat = 0f;
            ControllerInputPoller.instance.rightControllerIndexFloat = 0f;
            ControllerInputPoller.instance.leftControllerPrimaryButton = false;
            ControllerInputPoller.instance.leftControllerSecondaryButton = false;
            ControllerInputPoller.instance.rightControllerPrimaryButton = false;
            ControllerInputPoller.instance.rightControllerSecondaryButton = false;
            ControllerInputPoller.instance.leftControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.leftControllerSecondaryButtonTouch = false;
            ControllerInputPoller.instance.rightControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.rightControllerSecondaryButtonTouch = false;
        }

        public static void DisableNetworkTriggers()
        {
            bool inRoom = PhotonNetwork.InRoom;
            if (inRoom)
            {
                GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab").SetActive(false);
            }
            else
            {
                GameObject.Find("Environment Objects/TriggerZones_Prefab/ZoneTransitions_Prefab").SetActive(true);
            }
        }




        public static void NoFinger()
        {
            ControllerInputPoller.instance.leftControllerGripFloat = 0f;
            ControllerInputPoller.instance.rightControllerGripFloat = 0f;
            ControllerInputPoller.instance.leftControllerIndexFloat = 0f;
            ControllerInputPoller.instance.rightControllerIndexFloat = 0f;
        }

        public static Player GetPlayer(VRRig r)
        {
            return r.Creator.GetPlayerRef();
        }


        public static void JoinRandom()
        {
            bool inRoom = PhotonNetwork.InRoom;
            if (inRoom)
            {
                PhotonNetwork.Disconnect();
            }
            else
            {
                string text = (PhotonNetworkController.Instance.currentJoinTrigger == null) ? "forest" : PhotonNetworkController.Instance.currentJoinTrigger.networkZone;
                PhotonNetworkController.Instance.AttemptToJoinPublicRoom(GorillaComputer.instance.GetJoinTriggerForZone(text), 0, null, false);
            }
        }

        public static void AntiKick()
        {
            bool inRoom = PhotonNetwork.InRoom;
            if (inRoom)
            {
                PhotonNetworkController.Instance.disableAFKKick = true;
            }
            else
            {
                PhotonNetworkController.Instance.disableAFKKick = false;
            }
        }
        public static void FakeReportMenu()
        {
            if (ControllerInputPoller.instance.leftControllerSecondaryButton)
            {
                Safety.NoFinger();
                GTPlayer.Instance.InReportMenu = true;
            }
            else
            {
                GTPlayer.Instance.InReportMenu = false;
            }
        }



        public static void BypassVCBan()
        {
            GorillaTagger.moderationMutedTime = -1f;
            GorillaTelemetry.PostNotificationEvent("Unmute");
            GorillaTagger.Instance.myRecorder.TransmitEnabled = true;
            bool flag = KIDManager.Instance != null;
            if (flag)
            {
                GameObject.Destroy(KIDManager.Instance);
            }
        }
    }
}
