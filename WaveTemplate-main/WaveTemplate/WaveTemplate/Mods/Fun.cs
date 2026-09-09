using BepInEx;
using ExitGames.Client.Photon;
using GorillaNetworking;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.Windows;

namespace MagicMod.Mods
{
    internal class Fun
    {
        public static void FlushRPCS()
        {
            bool flag = Time.time - Fun.lastRpcFlushTime < 0.05f;
            if (!flag)
            {
                Fun.lastRpcFlushTime = Time.time;
                Fun.rpcFilterByViewId[0] = GorillaTagger.Instance.myVRRig.ViewID;
                RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                {
                    CachingOption = (EventCaching)6,
                    TargetActors = new int[]
                    {
                        PhotonNetwork.LocalPlayer.ActorNumber
                    }
                };
                MonkeAgent.instance.rpcErrorMax = int.MaxValue;
                MonkeAgent.instance.rpcCallLimit = int.MaxValue;
                MonkeAgent.instance.logErrorMax = int.MaxValue;
                PhotonNetwork.MaxResendsBeforeDisconnect = int.MaxValue;
                PhotonNetwork.QuickResends = int.MaxValue;
                PhotonNetwork.SendAllOutgoingCommands();
                PhotonNetwork.NetworkingClient.OpRaiseEvent(200, Fun.rpcFilterByViewId, raiseEventOptions, SendOptions.SendReliable);
            }
        }

        public static void Stumpkickall()
        {
            GorillaComputer.instance.OnGroupJoinButtonPress(0, GorillaComputer.instance.friendJoinCollider);
        }

        private static void EnableAllProjs()
        {
            string[] array = new string[]
            {
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/GrowingSnowballRightAnchor(Clone)/LMAVR. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/SnowballRightAnchor(Clone)/LMACF. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/WaterBalloonRightAnchor(Clone)/LMAEY. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/TrickTreatFunctionalAnchorRIGHT Variant(Clone)/LMAMO. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/AppleRightAnchor(Clone)/LMAMV.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/ScienceCandyRightAnchor(Clone)/LMAIF. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/BucketGiftFunctionalAnchor_Right(Clone)/LMAHR. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/VotingRockAnchor_RIGHT(Clone)/LMAMT. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/FishFoodRightAnchor(Clone)/LMAIP. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/LavaRockAnchor(Clone)/LMAGE. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/BookRightAnchor(Clone)/LMAQA. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/CoinRightAnchor(Clone)/LMAQC.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/EggRightHand_Anchor Variant(Clone)/LMAPS. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/IceCreamRightAnchor(Clone)/LMARA. LEFT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/HotDogRightAnchor(Clone)/LMARC.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/Fireworks_Anchor Variant_Right Hand(Clone)/LMAQU. LEFT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/ChipsRightAnchor(Clone)/LMAUC. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/SalsaRightAnchor(Clone)/LMAUD. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/ApplePieRightAnchor(Clone)/LMAUJ. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/GrowingMashedPotatoRightAnchor(Clone)/LMAUH. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/BerryPieRightAnchor(Clone)/LMAUL. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/LayerDipRightAnchor(Clone)/LMAUF. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/PumpkinPieRightAnchor(Clone)/LMAUN.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/GrowingStuffingRightAnchor(Clone)/LMAUP. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/CornRightAnchor(Clone)/LMAUT. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/TurkeyLegRightAnchor(Clone)/LMAUR. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/GoalpostFootball_Anchor_RightHand(Clone)/LMATL.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/PopcornBall_Anchor_Right(Clone)/LMATP.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/CrackedPlate_Lump_Projectile_Anchor_RIGHT(Clone)/LMAUA.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/PortableBonfire_Sticks_Anchor_RightHand(Clone)/LMATY.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/Walnut_Anchor_Right(Clone)/LMAVT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/HotCocoaCup_Anchor_RIGHT(Clone)/LMAWE.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/Papers_Anchor Variant_Right Hand(Clone)/LMASG. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/BalloonAnimalProjectile_Anchor_RIGHT(Clone)/LMAXI. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/CakePieces_Anchor_RIGHT(Clone)/LMAXG. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/PillowProjectile_Anchor_RIGHT(Clone)/LMAWB. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/EnergyWafer_Anchor_RIGHT(Clone)/LMAYC.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/PineconeGrenadePin_Anchor_RIGHT(Clone)/LMAZJ.",
                "Player Objects/Local VRRig/Local Gorilla Player/Holdables/PlaceableStrikezone_Baseball_Projectile_Anchor_RIGHT(Clone)/LMBBD."
            };
            string[] array2 = new string[]
            {
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/GrowingSnowballRightAnchor(Clone)/LMAVR. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor(Clone)/LMACF. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/WaterBalloonRightAnchor(Clone)/LMAEY. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/TrickTreatFunctionalAnchorRIGHT Variant(Clone)/LMAMO. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/AppleRightAnchor(Clone)/LMAMV.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/ScienceCandyRightAnchor(Clone)/LMAIF. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/BucketGiftFunctionalAnchor_Right(Clone)/LMAHR. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/VotingRockAnchor_RIGHT(Clone)/LMAMT. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/FishFoodRightAnchor(Clone)/LMAIP. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/LavaRockAnchor(Clone)/LMAGE. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/BookRightAnchor(Clone)/LMAQA. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/CoinRightAnchor(Clone)/LMAQC.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/EggRightHand_Anchor Variant(Clone)/LMAPS. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/IceCreamRightAnchor(Clone)/LMARA. LEFT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/HotDogRightAnchor(Clone)/LMARC.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/Fireworks_Anchor Variant_Right Hand(Clone)/LMAQU. LEFT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/ChipsRightAnchor(Clone)/LMAUC. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/SalsaRightAnchor(Clone)/LMAUD. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/ApplePieRightAnchor(Clone)/LMAUJ. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/GrowingMashedPotatoRightAnchor(Clone)/LMAUH. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/BerryPieRightAnchor(Clone)/LMAUL. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/LayerDipRightAnchor(Clone)/LMAUF. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/PumpkinPieRightAnchor(Clone)/LMAUN.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/GrowingStuffingRightAnchor(Clone)/LMAUP. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/CornRightAnchor(Clone)/LMAUT. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/TurkeyLegRightAnchor(Clone)/LMAUR. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/GoalpostFootball_Anchor_RightHand(Clone)/LMATL.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/PopcornBall_Anchor_Right(Clone)/LMATP.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/CrackedPlate_Lump_Projectile_Anchor_RIGHT(Clone)/LMAUA.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/PortableBonfire_Sticks_Anchor_RightHand(Clone)/LMATY.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/Walnut_Anchor_Right(Clone)/LMAVT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/HotCocoaCup_Anchor_RIGHT(Clone)/LMAWE.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/Papers_Anchor Variant_Right Hand(Clone)/LMASG. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/BalloonAnimalProjectile_Anchor_RIGHT(Clone)/LMAXI. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/CakePieces_Anchor_RIGHT(Clone)/LMAXG. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/PillowProjectile_Anchor_RIGHT(Clone)/LMAWB. RIGHT.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/EnergyWafer_Anchor_RIGHT(Clone)/LMAYC.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/PineconeGrenadePin_Anchor_RIGHT(Clone)/LMAZJ.",
                "Player Objects/Local VRRig/Local Gorilla Player/rig/hand.R/palm.01.R/TransferrableItemRightHand/PlaceableStrikezone_Baseball_Projectile_Anchor_RIGHT(Clone)/LMBBD."
            };
            for (int i = 0; i < array.Length; i++)
            {
                GameObject gameObject = GameObject.Find(array[i]);
                GameObject gameObject2 = GameObject.Find(array2[i]);
                bool flag = gameObject != null && !gameObject.activeInHierarchy;
                if (flag)
                {
                    gameObject.SetActive(true);
                }
                bool flag2 = gameObject2 != null && gameObject2.activeInHierarchy;
                if (flag2)
                {
                    gameObject2.GetComponent<SnowballThrowable>().SetSnowballActiveLocal(false);
                }
            }
        }

        public static void HoverboardSpam()
        {
            bool flag = (ControllerInputPoller.instance.rightGrab && Time.time > Fun.hoverboardSpamDelay) || (UnityInput.Current.GetMouseButton(0) && Time.time > Fun.hoverboardSpamDelay);
            if (flag)
            {
                Fun.hoverboardSpamDelay = Time.time + 0.3f;
                FreeHoverboardManager.instance.SendDropBoardRPC(VRRig.LocalRig.rightHandTransform.position, VRRig.LocalRig.rightHandTransform.rotation, VRRig.LocalRig.rightHandTransform.up * 100f, new Vector3(900f, 900f, 900f), Color.white);
            }
        }

        public static float hoverboardSpamDelay;

        public static void Flush()
        {
            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            PhotonNetwork.RemoveBufferedRPCs(0, null, null);
            PhotonNetwork.MaxResendsBeforeDisconnect = int.MaxValue;
            PhotonNetwork.QuickResends = int.MaxValue;
            bool flag = GorillaTagger.Instance.myVRRig != null;
            if (flag)
            {
                PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig.GetView);
            }
            MonkeAgent.instance.rpcErrorMax = int.MaxValue;
            MonkeAgent.instance.rpcCallLimit = int.MaxValue;
            MonkeAgent.instance.logErrorMax = int.MaxValue;
            PhotonNetwork.SendAllOutgoingCommands();
        }

        public static bool usingPC;

        private static Hashtable rpcFilterByViewId = new Hashtable();
        private static float lastRpcFlushTime = 0f;

        public static float delay;
        public static void SoundSpammer(int num)
        {
            bool flag = ControllerInputPoller.instance.rightGrab || ControllerInputPoller.instance.leftGrab;
            if (flag)
            {
                bool flag2 = Time.time > Fun.delay;
                if (flag2)
                {
                    Fun.delay = Time.time + 0.1f;
                    if (PhotonNetwork.InLobby)
                    {
                        GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlayHandTap", 0, new object[]
                        {
                            num,
                            false,
                            999999f
                        });
                    }
                    else
                    {
                        GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(num, false, 999999f);
                    }
                }
            }
            Fun.FlushRPCS();
        }

        public static void AK47SoundSpam()
        {
            Fun.SoundSpammer(203);
        }

        public static void BassSoundSpam()
        {
            Fun.SoundSpammer(68);
        }

        public static void BeeSoundSpam()
        {
            Fun.SoundSpammer(191);
        }

        public static void BigCrystalSoundSpam()
        {
            Fun.SoundSpammer(213);
        }

        public static void CatSoundSpam()
        {
            Fun.SoundSpammer(236);
        }

        public static void EarrapeSoundSpam()
        {
            Fun.SoundSpammer(215);
        }

        public static void MaxQuestScore()
        {
            VRRig.LocalRig.SetQuestScore(int.MaxValue);
        }
    }
}
