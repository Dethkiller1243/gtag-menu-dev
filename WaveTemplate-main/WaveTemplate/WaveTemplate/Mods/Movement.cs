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
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.Unity;
using StupidTemplate.Classes;
using StupidTemplate.Menu;
using StupidTemplate.Mods;
using StupidTemplate.Mods.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using Valve.VR;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate.Mods
{
    public class Movement
    {
        public static void Fly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GTPlayer.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Settings.Movement.flySpeed;
                GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.zero;
            }
        }
        public static void MosaSpeed()
        {
            GTPlayer.Instance.maxJumpSpeed = 7.25f;
            GTPlayer.Instance.jumpMultiplier = 1.95f;
        }

        public static void Noclip()
        {
            if(ControllerInputPoller.instance.rightControllerTriggerButton)
            {
                bool flag = GTPlayer.Instance.AddComponent<MeshCollider>();
                Component[] components = GTPlayer.Instance.GetComponents<MeshCollider>();
                foreach (Component component in components) { if (component.GetComponent<MeshCollider>() != false) {
                    }
                }
            }
            else
            {
                MeshCollider meshCollider = GTPlayer.Instance.GetComponent<MeshCollider>(); if (meshCollider != false) 
                meshCollider.enabled = true;
            }
        }


        public static void ViewGhost()
        {
            GameObject gameObject = GameObject.CreatePrimitive(0);
            GameObject.Destroy(gameObject.GetComponent<Rigidbody>());
            GameObject.Destroy(gameObject.GetComponent<SphereCollider>());
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            gameObject.transform.position = GorillaTagger.Instance.leftHandTransform.position;
            GameObject gameObject2 = GameObject.CreatePrimitive(0);
            GameObject.Destroy(gameObject2.GetComponent<Rigidbody>());
            GameObject.Destroy(gameObject2.GetComponent<SphereCollider>());
            gameObject2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            gameObject2.transform.position = GorillaTagger.Instance.rightHandTransform.position;
            gameObject.GetComponent<Renderer>().material.color = Color.black;
            gameObject2.GetComponent<Renderer>().material.color = Color.black;
            GameObject.Destroy(gameObject, Time.deltaTime);
            GameObject.Destroy(gameObject2, Time.deltaTime);
        }
        public static GameObject airSwimPart;
        public static void AirSwim()
        {
            bool flag = (GameObject)Movement.airSwimPart == null;
            if (flag)
            {
                Movement.airSwimPart = GameObject.Instantiate<GameObject>(GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach/ForestToBeach_Prefab_V4/CaveWaterVolume"));
                Movement.airSwimPart.transform.localScale = new Vector3(5f, 5f, 5f);
                Movement.airSwimPart.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                GTPlayer.Instance.audioManager.UnsetMixerSnapshot(0.1f);
                Movement.airSwimPart.transform.position = GorillaTagger.Instance.headCollider.transform.position + new Vector3(0f, 2.5f, 0f);
            }
        }
        public static void DisableAirSwim()
        {
            bool flag = (GameObject)Movement.airSwimPart != null;
            if (flag)
            {
                GameObject.Destroy((GameObject)Movement.airSwimPart);
                Movement.airSwimPart = null;
            }
        }
        public static void WalkOnWater()
        {
            GameObject gameObject = GameObject.Find("Beach/B_WaterVolumes");
            Transform transform = gameObject.transform;
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject gameObject2 = transform.GetChild(i).gameObject;
                gameObject2.layer = LayerMask.NameToLayer("Default");
            }
        }


        public static void TPose()
        {
            bool flag = ControllerInputPoller.instance.leftControllerTriggerButton || ControllerInputPoller.instance.rightControllerTriggerButton;
            bool flag2 = flag;
            if (flag2)
            {
                Movement.ViewGhost();
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * -1f;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * 1f;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }
        private static bool PlatformRightMade;
        private static GameObject PlatformRight;
        private static GameObject PlatformLeft;
        private static bool PlatformLeftMade;
        
        public static void Platforms()
        {
            bool flag = ControllerInputPoller.instance.rightGrab || UnityInput.Current.GetKey((KeyCode)306);
            if (flag)
            {
                bool flag2 = !Movement.PlatformRightMade;
                if (flag2)
                {
                    Movement.PlatformRight = GameObject.CreatePrimitive((PrimitiveType)3);
                    Movement.PlatformRight.name = "MenuPlatformsR";
                    Movement.PlatformRight.transform.localScale = new Vector3(0.03f, 0.3f, 0.3f);
                    Movement.PlatformRight.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    Movement.PlatformRight.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    Movement.PlatformRight.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
                    Movement.PlatformRightMade = true;
                }
                bool flag3 = Movement.PlatformRight != null;
                if (flag3)
                {
                    Movement.PlatformRight.GetComponent<Renderer>().material.color = Color.black;
                }
            }
            else
            {
                GameObject.Destroy(Movement.PlatformRight);
                Movement.PlatformRightMade = false;
            }
            bool leftGrab = ControllerInputPoller.instance.leftGrab;
            if (leftGrab)
            {
                bool flag4 = !Movement.PlatformLeftMade;
                if (flag4)
                {
                    Movement.PlatformLeft = GameObject.CreatePrimitive((PrimitiveType)3);
                    Movement.PlatformLeft.name = "MenuPlatformsL";
                    Movement.PlatformLeft.transform.localScale = new Vector3(0.03f, 0.3f, 0.3f);
                    Movement.PlatformLeft.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    Movement.PlatformLeft.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    Movement.PlatformLeft.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                    Movement.PlatformLeftMade = true;
                }
                bool flag5 = Movement.PlatformLeft != null;
                if (flag5)
                {
                    Movement.PlatformLeft.GetComponent<Renderer>().material.color = Color.black;
                }
            }
            else
            {
                GameObject.Destroy(Movement.PlatformLeft);
                Movement.PlatformLeftMade = false;
            }
        }

        public static void LongArms()
        {
            GameObject.Find("GorillaPlayer").transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        }

        public static void SlingShot()
        {
            if (ControllerInputPoller.instance.rightControllerPrimary2DAxis.y > 0.5)
            {
                GTPlayer.Instance.bodyCollider.attachedRigidbody.AddForce(GTPlayer.Instance.bodyCollider.transform.forward * (Time.deltaTime * (20f / Time.deltaTime)), ForceMode.Acceleration);
            }
        }

        public static void JoystickFly()
        {
            Transform transform = GTPlayer.Instance.bodyCollider.transform;
            Physics.gravity = Vector3.zero;
            Vector2 leftControllerPrimary2DAxis = ControllerInputPoller.instance.leftControllerPrimary2DAxis;
            Vector2 rightControllerPrimary2DAxis = ControllerInputPoller.instance.rightControllerPrimary2DAxis;
            Vector3 vector = transform.forward * leftControllerPrimary2DAxis.y;
            Vector3 vector2 = transform.right * leftControllerPrimary2DAxis.x;
            Vector3 vector3 = transform.up * rightControllerPrimary2DAxis.y;
            Vector3 normalized = (vector + vector2 + vector3).normalized;
            Transform transform2 = GTPlayer.Instance.transform;
            transform2.position += normalized * 9f * Time.deltaTime;
            GTPlayer.Instance.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            Physics.gravity = new Vector3(0f, -9.81f, 0f);
        }


        public static void GripSpeed()
        {
            bool Grab = ControllerInputPoller.instance.rightGrab || ControllerInputPoller.instance.leftGrab;
            {
                if (Grab)
                {
                    GTPlayer.Instance.maxJumpSpeed = 15f;
                    GTPlayer.Instance.jumpMultiplier = 2.5f;

                }
                else
                {
                    GTPlayer.Instance.maxJumpSpeed = 7.25f;
                    GTPlayer.Instance.jumpMultiplier = 1.95f;
                }
            }
        }

        public static bool previousTeleportTrigger;
        public static void TeleportGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                var GunData = RenderGun();
                GameObject NewPointer = GunData.NewPointer;

                if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f && !previousTeleportTrigger)
                {
                    GTPlayer.Instance.TeleportTo(NewPointer.transform.position + Vector3.up, GTPlayer.Instance.transform.rotation);
                    GorillaTagger.Instance.rigidbody.linearVelocity = Vector3.zero;
                }

                previousTeleportTrigger = ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f;
            }
        }
        public static Vector3 surfaceNormal;
        public static Vector3 lastHitPoint;
        public static void WallWalk()
        {
            GTPlayer instance = GTPlayer.Instance;
            bool flag = GTPlayer.Instance.IsHandTouching(true) || GTPlayer.Instance.IsHandTouching(false);
            if (flag)
            {
                FieldInfo field = typeof(GTPlayer).GetField("lastHitInfoHand", BindingFlags.Instance | BindingFlags.NonPublic);
                bool flag2 = field != null;
                if (flag2)
                {
                    RaycastHit raycastHit = (RaycastHit)field.GetValue(instance);
                    Movement.lastHitPoint = raycastHit.point;
                    Movement.surfaceNormal = raycastHit.normal;
                }
            }
            bool flag3 = ControllerInputPoller.instance.rightGrab || UnityInput.Current.GetMouseButton(0);
            bool flag4 = Movement.lastHitPoint != Vector3.zero && flag3;
            if (flag4)
            {
                Rigidbody attachedRigidbody = instance.bodyCollider.attachedRigidbody;
                if (attachedRigidbody != null)
                {
                    attachedRigidbody.AddForce(Movement.surfaceNormal * -9.81f, (ForceMode)5);
                }
                GTPlayer.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.unscaledDeltaTime * (9.81f / Time.unscaledDeltaTime)), (ForceMode)5);
            }
        }

        private static Dictionary<string, string> modsForModCheck = new Dictionary<string, string>
        {
            {
                "genesis",
                "Genesis"
            },
            {
                "HP_Left",
                "Holdable Pad"
            },
            {
                "GrateVersion",
                "Grate"
            },
            {
                "void",
                "Void"
            },
            {
                "BANANAOS",
                "Banana OS"
            },
            {
                "GC",
                "Gorilla Craft"
            },
            {
                "CarName",
                "Gorilla Vehicles"
            },
            {
                "6p72ly3j85pau2g9mda6ib8px",
                "CCM V2"
            },
            {
                "FPS-Nametags for Zlothy",
                "FPS Tags"
            },
            {
                "ORBIT",
                "Orbit"
            },
            {
                "Violet On Top",
                "Violet"
            },
            {
                "MP25",
                "Monke Phone"
            },
            {
                "GorillaWatch",
                "Gorilla Watch"
            },
            {
                "InfoWatch",
                "Gorilla Info Watch"
            },
            {
                "BananaPhone",
                "Banana Phone"
            },
            {
                "Vivid",
                "Vivid"
            },
            {
                "RGBA",
                "Custom Cosmetics"
            },
            {
                "cheese is gouda",
                "Whos Icheating"
            },
            {
                "shirtversion",
                "Gorilla Shirts"
            },
            {
                "gpronouns",
                "Gorilla Pronouns"
            },
            {
                "gfaces",
                "Gorilla Faces"
            },
            {
                "monkephone",
                "Monke Phone"
            },
            {
                "pmversion",
                "Player Models"
            },
            {
                "gtrials",
                "Gorilla Trials"
            },
            {
                "msp",
                "Monke Smartphone"
            },
            {
                "gorillastats",
                "Gorilla Stats"
            },
            {
                "MediaPad",
                "Media Pad"
            },
            {
                "using gorilladrift",
                "Gorilla Drift"
            },
            {
                "monkehavocversion",
                "Monke Havoc"
            },
            {
                "tictactoe",
                "Tic Tac Toe"
            },
            {
                "ccolor",
                "Index"
            },
            {
                "imposter",
                "Gorilla Among Us"
            },
            {
                "spectapeversion",
                "Spec Tape"
            },
            {
                "cats",
                "Cats"
            },
            {
                "made by biotest05 :3",
                "Dogs"
            },
            {
                "fys cool magic mod",
                "Fys Magic Mod"
            },
            {
                "colour",
                "Custom Cosmetics"
            },
            {
                "chainedtogether",
                "Chained Together"
            },
            {
                "goofywalkversion",
                "Goofy Walk"
            },
            {
                "void_menu_open",
                "Void"
            },
            {
                "violetpaiduser",
                "Violet Paid"
            },
            {
                "violetfree",
                "Violet Free"
            },
            {
                "obsidianmc",
                "Obsidian.Lol"
            },
            {
                "dark",
                "Shiba GT Dark"
            },
            {
                "hidden menu",
                "Hidden"
            },
            {
                "oblivionuser",
                "Oblivion"
            },
            {
                "hgrehngio889584739_hugb\n",
                "Resurgence"
            },
            {
                "eyerock reborn",
                "Eye Rock"
            },
            {
                "asteroidlite",
                "Asteroid Lite"
            },
            {
                "elux",
                "Elux"
            },
            {
                "cokecosmetics",
                "Coke Cosmetx"
            },
            {
                "GFaces",
                "G Faces"
            },
            {
                "github.com/maroon-shadow/SimpleBoards",
                "Simple Boards"
            },
            {
                "ObsidianMC",
                "Obsidian"
            },
            {
                "hgrehngio889584739_hugb",
                "Resurgence"
            },
            {
                "GTrials",
                "G Trials"
            },
            {
                "github.com/ZlothY29IQ/GorillaMediaDisplay",
                "Gorilla Media Display"
            },
            {
                "github.com/ZlothY29IQ/TooMuchInfo",
                "Too Much Info"
            },
            {
                "github.com/ZlothY29IQ/RoomUtils-IW",
                "Room Utils IW"
            },
            {
                "github.com/ZlothY29IQ/MonkeClick",
                "Monke Click"
            },
            {
                "github.com/ZlothY29IQ/MonkeClick-CI",
                "Monke Click CI"
            },
            {
                "github.com/ZlothY29IQ/MonkeRealism",
                "Monke Realism"
            },
            {
                "GorillaCinema",
                "Gorilla Cinema"
            },
            {
                "ChainedTogetherActive",
                "Chained Together"
            },
            {
                "GPronouns",
                "G Pronouns"
            },
            {
                "CSVersion",
                "Custom Skin"
            },
            {
                "github.com/ZlothY29IQ/Zloth-RecRoomRig",
                "Zloth Rec Room Rig"
            },
            {
                "ShirtProperties",
                "Shirts Old"
            },
            {
                "GorillaShirts",
                "Shirts"
            },
            {
                "GS",
                "Old Shirts"
            },
            {
                "6XpyykmrCthKhFeUfkYGxv7xnXpoe2",
                "CCM V2"
            },
            {
                "Body Tracking",
                "Body Track Old"
            },
            {
                "Body Estimation",
                "Han Body Est"
            },
            {
                "Gorilla Track",
                "Body Track"
            },
            {
                "CustomMaterial",
                "Custom Cosmetics"
            },
            {
                "I like cheese",
                "Rec Room Rig"
            },
            {
                "silliness",
                "Silliness"
            },
            {
                "EmoteWheel",
                "Fortnite Emote Wheel"
            },
            {
                "untitled",
                "Untitled"
            },
            {
                "BoyDoILoveInformation Public",
                "BoyDoILoveInformation"
            },
            {
                "DTAOI",
                "DTAOI"
            },
            {
                "GorillaShop",
                "GorillaShop"
            },
            {
                "Fusioned",
                "Fusioned"
            },
            {
                "y u lookin in here weirdo",
                "Malachi Menu Reborn"
            },
            {
                "ØƦƁƖƬ",
                "Orbit"
            },
            {
                "Atlas",
                "Atlas"
            },
            {
                "Magic Client",
                "Magic Client"
            }
        };
    
        public static void BreakModCheck()
        {
            ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
            foreach (string text in Movement.modsForModCheck.Keys)
            {
                hashtable[text] = true;
            }
            PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable, null, null);
        }

        public static void Water()
        {
            GameObject waterPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            waterPlane.transform.position = new Vector3(0f, 0f, 0f);
            waterPlane.transform.localScale = new Vector3(10f, 1f, 10f);
            waterPlane.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
            waterPlane.GetComponent<Renderer>().material.color = Color.blue;
        }

        public static void IronMonke()
        {
            Rigidbody component = GTPlayer.Instance.GetComponent<Rigidbody>();
            bool rightGrab = ControllerInputPoller.instance.rightGrab;
            if (rightGrab)
            {
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(115, false, 0.1f);
                GorillaTagger.Instance.StartVibration(false, GorillaTagger.Instance.tapHapticStrength / 10f, GorillaTagger.Instance.tapHapticDuration);
                Vector3 vector = 15f * GTPlayer.Instance.RightHand.controllerTransform.right;
                component.AddForce(vector, (ForceMode)1);
            }
            bool leftGrab = ControllerInputPoller.instance.leftGrab;
            if (leftGrab)
            {
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(115, true, 0.1f);
                GorillaTagger.Instance.StartVibration(true, GorillaTagger.Instance.tapHapticStrength / 10f, GorillaTagger.Instance.tapHapticDuration);
                Vector3 vector2 = 15f * GTPlayer.Instance.LeftHand.controllerTransform.right * -1f;
                component.AddForce(vector2, (ForceMode)1);
            }
        }

        public static void GrabAllRPCS()
        {
            string text = "=======================RPC INFO!=========================";
            foreach (string str in PhotonNetwork.PhotonServerSettings.RpcList)
            {
                text = text + "RPC: " + str + "\n\n";
            }
            text += "\n==========================================================\n";
            bool flag = !Directory.Exists("Magic Client");
            if (flag)
            {
                Directory.CreateDirectory("Magic Client");
            }
            File.AppendAllText("Magic Client/RPC Info.txt", text);
        }


        private static bool lastDash;
        private static float flySpeed = 15f;
        public static void Dash()
        {
            Movement.lastDash = ControllerInputPoller.instance.rightControllerSecondaryButton;
            bool flag = ControllerInputPoller.instance.rightControllerSecondaryButton && !Movement.lastDash;
            if (flag)
            {
                GorillaTagger.Instance.rigidbody.linearVelocity += GTPlayer.Instance.headCollider.transform.forward * Movement.flySpeed;
            }
        }


        public static void WASDFly()
        {
            float num = 5f;
            float num2 = 2.5f;
            float num3 = 0.3f;
            Transform transform = Camera.main.transform;
            Rigidbody rigidbody = GorillaTagger.Instance.rigidbody;
            rigidbody.useGravity = false;
            rigidbody.linearVelocity = Vector3.zero;
            float num4 = UnityInput.Current.GetKey((KeyCode)304) ? (num * num2) : num;
            float num5 = num4 * Time.deltaTime;
            Vector3 vector = Vector3.zero;
            bool flag = UnityInput.Current.GetKey((KeyCode)119) || UnityInput.Current.GetKey((KeyCode)273);
            if (flag)
            {
                vector += transform.forward;
            }
            bool flag2 = UnityInput.Current.GetKey((KeyCode)115) || UnityInput.Current.GetKey((KeyCode)274);
            if (flag2)
            {
                vector -= transform.forward;
            }
            bool flag3 = UnityInput.Current.GetKey((KeyCode)100) || UnityInput.Current.GetKey((KeyCode)275);
            if (flag3)
            {
                vector += transform.right;
            }
            bool flag4 = UnityInput.Current.GetKey((KeyCode)97) || UnityInput.Current.GetKey((KeyCode)276);
            if (flag4)
            {
                vector -= transform.right;
            }
            bool key = UnityInput.Current.GetKey((KeyCode)32);
            if (key)
            {
                vector += transform.up;
            }
            bool key2 = UnityInput.Current.GetKey((KeyCode)306);
            if (key2)
            {
                vector -= transform.up;
            }
            transform.position += vector * num5;
            bool mouseButton = UnityInput.Current.GetMouseButton(1);
            if (mouseButton)
            {
                Vector3 vector2 = UnityInput.Current.mousePosition - Movement.pos;
                float num6 = transform.localEulerAngles.x - vector2.y * num3;
                float num7 = transform.localEulerAngles.y + vector2.x * num3;
                transform.localEulerAngles = new Vector3(num6, num7, 0f);
            }
            Movement.pos = UnityInput.Current.mousePosition;
        }



        public static Vector3 pos;

        internal static void RigReset()
        {
            throw new NotImplementedException();
        }
    }
}
