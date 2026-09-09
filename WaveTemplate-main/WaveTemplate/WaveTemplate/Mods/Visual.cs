using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Runtime.CompilerServices;
using GorillaLocomotion;
using GorillaNetworking;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using BepInEx;
using Photon.Realtime;
using StupidTemplate.Classes;
using StupidTemplate.Menu;
using StupidTemplate.Mods;
using StupidTemplate.Mods.Settings;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using static StupidTemplate.Menu.Main;
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
using Photon.Voice.Unity;
using TMPro;
using Valve.VR;
using MagicMod.Mods;

namespace MagicMod.Mods
{
    internal class Visual
    {
        public static Shader GUIShader = Shader.Find("GUI/Text Shader");

        public static void BoxESP()
        {
            foreach (VRRig vrrig in FindRig.GetRigs())
            {
                bool flag = !vrrig.isOfflineVRRig && !vrrig.isMyPlayer;
                if (flag)
                {
                    bool flag2 = vrrig == null;
                    if (!flag2)
                    {
                        bool flag3 = vrrig.transform.Find("ESPBox") != null;
                        if (!flag3)
                        {
                            GameObject gameObject = GameObject.CreatePrimitive((PrimitiveType)3);
                            gameObject.name = "ESPBox";
                            gameObject.transform.localScale = new Vector3(0.5f, 0.8f, 0.5f);
                            gameObject.transform.SetParent(vrrig.transform);
                            gameObject.transform.localPosition = Vector3.zero;
                            GameObject.Destroy(gameObject, 0.15f);
                            Renderer component = gameObject.GetComponent<Renderer>();
                            bool flag4 = component != null;
                            if (flag4)
                            {
                                component.material = new Material(Mods.Visual.GUIShader);
                                Color playerColor = vrrig.playerColor;
                                playerColor.a = 0.5f;
                                component.material.color = playerColor;
                            }
                            Collider component2 = gameObject.GetComponent<Collider>();
                            bool flag5 = component2 != null;
                            if (flag5)
                            {
                                component2.enabled = false;
                            }
                        }
                    }
                }
            }
        }

        public static void Tracers()
        {
            foreach (VRRig vrrig in FindRig.GetRigs())
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    GameObject line = new GameObject("line"); 
                    LineRenderer lr = line.AddComponent<LineRenderer>();
                    var color = Color.blue; 
                    lr.startColor = vrrig.playerColor;
                    lr.endColor = Color.gray;
                    lr.startWidth = 0.01f;
                    lr.endWidth = 0.01f;
                    lr.positionCount = 2;
                    lr.useWorldSpace = true;
                    lr.SetPosition(0, GorillaTagger.Instance.rightHandTransform.position);
                    lr.SetPosition(1, vrrig.transform.position);
                    GameObject.Destroy(lr, Time.deltaTime);
                    GameObject.Destroy(line, Time.deltaTime);
                }
            }
        }


        public static void NameTags()
        {
            foreach (VRRig vrrig in FindRig.GetRigs())
            {
                bool flag = !vrrig.isOfflineVRRig && !vrrig.isMyPlayer;
                if (flag)
                {
                    bool flag2 = vrrig == null;
                    if (!flag2)
                    {
                        bool flag3 = vrrig.transform.Find("ESPNameTag") != null;
                        if (!flag3)
                        {
                            GameObject gameObject = new GameObject("ESPNameTag");
                            gameObject.transform.SetParent(vrrig.transform);
                            gameObject.transform.localPosition = new Vector3(0f, 0.5f, 0f);
                            TextMeshPro textMeshPro = gameObject.AddComponent<TextMeshPro>();
                            textMeshPro.text = vrrig.playerNameVisible;
                            textMeshPro.fontSize = 0.1f;
                            textMeshPro.alignment = TextAlignmentOptions.Center;
                            textMeshPro.color = vrrig.playerColor;
                        }
                    }
                }
            }
        }
    }
}
