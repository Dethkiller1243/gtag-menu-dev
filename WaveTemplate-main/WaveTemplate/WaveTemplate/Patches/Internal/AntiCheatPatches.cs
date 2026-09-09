using HarmonyLib;
using UnityEngine;

namespace StupidTemplate.Patches.Internal
{
    public class AntiCheatPatches
    {
        [HarmonyPatch(typeof(GorillaTelemetry), "SendReport")]
        public class SendReportPatch
        {
            private static bool Prefix(string susReason, string susId, string susNick) => false;
        }

        [HarmonyPatch(typeof(GorillaTelemetry), "CloseInvalidRoom")]
        public class NoCloseInvalidRoom
        {
            private static bool Prefix() =>
                false;
        }

        [HarmonyPatch(typeof(GorillaTelemetry), "CheckReports")]
        public class NoCheckReports
        {
            private static bool Prefix() =>
                false;
        }

        [HarmonyPatch(typeof(GorillaTelemetry), "DispatchReport")]
        public class NoDispatchReport
        {
            private static bool Prefix() =>
                false;
        }

        [HarmonyPatch(typeof(GorillaTelemetry), "GetRPCCallTracker")]
        internal class NoGetRPCCallTracker
        {
            private static bool Prefix() =>
                false;
        }

        [HarmonyPatch(typeof(GorillaTelemetry), "LogErrorCount")]
        public class NoLogErrorCount
        {
            private static bool Prefix(string logString, string stackTrace, LogType type) =>
                false;
        }

        [HarmonyPatch(typeof(GorillaTelemetry), "QuitDelay", MethodType.Enumerator)]
        public class NoQuitDelay
        {
            private static bool Prefix() =>
                false;
        }

        [HarmonyPatch(typeof(GorillaGameManager), "ForceStopGame_DisconnectAndDestroy")]
        public class NoQuitOnBan
        {
            private static bool Prefix() =>
                false;
        }

        [HarmonyPatch(typeof(GorillaTelemetry), "ShouldDisconnectFromRoom")]
        public class NoShouldDisconnectFromRoom
        {
            private static bool Prefix() =>
                false;
        }

        [HarmonyPatch(typeof(GorillaNetworkPublicTestsJoin), "GracePeriod")]
        public class GracePeriodPatch1
        {
            private static bool Prefix() =>
                false;
        }

        [HarmonyPatch(typeof(GorillaNetworkPublicTestJoin2), "GracePeriod")]
        public class GracePeriodPatch2
        {
            private static bool Prefix() =>
                false;
        }
    }
}
