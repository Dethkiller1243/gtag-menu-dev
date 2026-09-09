using GunlibMagic;
using MagicMod.Mods;
using Mane.Mods;
using StupidTemplate.Classes;
using StupidTemplate.Mods;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Settings;

namespace StupidTemplate.Menu
{
    public class Buttons
    {
        /*
         * Here is where all of your buttons are located.
         * To create a button, you may use the following code:
         * 
         * Move to Category:
         *   new ButtonInfo { buttonText = "Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Opens the main settings page for the menu."},
         *   new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
         * 
         * Togglable Mod:
         *   new ButtonInfo { buttonText = "Platforms", method =() => Movement.Platforms(), toolTip = "Spawns platforms on your hands when pressing grip."},
         */

        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods [0]
                new ButtonInfo { buttonText = "Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Join Discord", method =() => discord.JoinDiscord(), isTogglable = false, toolTip = "Join the discord server"},
                new ButtonInfo { buttonText = "Movement Mods", method =() => currentCategory = 7, isTogglable = false, toolTip = "Opens the movement mods page."},
                new ButtonInfo { buttonText = "Advantage Mods", method =() => currentCategory = 8, isTogglable = false, toolTip = "Opens the advantage mods page."},
                new ButtonInfo { buttonText = "Visual Mods", method =() => currentCategory = 9, isTogglable = false, toolTip = "Opens the visual mods page."},
                new ButtonInfo { buttonText = "RPC Mods", method =() => currentCategory = 10, isTogglable = false, toolTip = "Opens the RPC mods page."},
                new ButtonInfo { buttonText = "Rig Mods", method =() => currentCategory = 11, isTogglable = false, toolTip = "Opens the Rig mods page."},
                new ButtonInfo { buttonText = "TimeChange Mods", method =() => currentCategory = 12, isTogglable = false, toolTip = "Opens the TimeChange mods page."},
            },


            new ButtonInfo[] { // Settings [1]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Menu", method =() => currentCategory = 2, isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Movement", method =() => currentCategory = 3, isTogglable = false, toolTip = "Opens the movement settings for the menu."},
                new ButtonInfo { buttonText = "GunLib Settings", method =() => currentCategory = 5, isTogglable = false, toolTip = "Settings for our gunlib."},
            
            },

            new ButtonInfo[] { // Menu Settings [2]
                new ButtonInfo { buttonText = "Return to Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => rightHanded = true, disableMethod =() => rightHanded = false, toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => disableNotifications = false, disableMethod =() => disableNotifications = true, enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => fpsCounter = true, disableMethod =() => fpsCounter = false, enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => disconnectButton = true, disableMethod =() => disconnectButton = false, enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = "Join Random Room", method =() => Safety.JoinRandom(), isTogglable = false, toolTip = "Joins a random public room"},
                new ButtonInfo { buttonText = "", method =() => currentCategory = 6, isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
            },

            new ButtonInfo[] { // Movement Settings [3]
                new ButtonInfo { buttonText = "Return to Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Returns to the main settings page for the menu."},

                new ButtonInfo { buttonText = "Change Fly Speed", overlapText = "Change Fly Speed [Normal]", method =() => Mods.Settings.Movement.ChangeFlySpeed(), isTogglable = false, toolTip = "Changes the speed of the fly mod."},
            },

            new ButtonInfo[] { // Room Mods [4]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},

                new ButtonInfo { buttonText = "Disconnect", method =() => NetworkSystem.Instance.ReturnToSinglePlayer(), isTogglable = false, toolTip = "Disconnects you from the room."},
            },

            new ButtonInfo[] { // Movement Mods [5]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "IIDK Cube Pointer", method =() => Main.CubePointer(), toolTip = "Toggles the cube pointer."},
                new ButtonInfo { buttonText = "Update Pointer", method =() => Gunlib.UpdatePointer(), toolTip = "Toggles the cube pointer."},
            },

            new ButtonInfo[] { // Safety Mods [6]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "No Finger Movement", method =() => Safety.NoFingerMovement(), toolTip = "Disables finger movement on the controllers"},
                new ButtonInfo { buttonText = "Bypass VC Ban", method =() => Safety.BypassVCBan(), toolTip = "Bypasses the VC ban"},
                new ButtonInfo { buttonText = "Fake Report Menu", method =() => Safety.FakeReportMenu(), toolTip = "Fakes the report menu"},
                new ButtonInfo { buttonText = "Break Mod Check", method =() => Movement.BreakModCheck(), toolTip = "Breaks the mod check."},
                new ButtonInfo { buttonText = "Flush All RPCS", method =() => Fun.FlushRPCS(), toolTip = "Breaks the mod check."},
                new ButtonInfo { buttonText = "Join Random Room", method =() => Safety.JoinRandom(), isTogglable = false, toolTip = "Joins a random public room"},
            },

            new ButtonInfo[] { // Movement Mods [7]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Fly", method =() => Movement.Fly(), toolTip = "Sends you forward when holding A."},
                new ButtonInfo { buttonText = "Platforms", method =() => Movement.Platforms(), toolTip = "Spawns platforms on your hands when pressing grip."},
                new ButtonInfo { buttonText = "SlingShot", method =() => Movement.SlingShot(), toolTip = "Launches you forward when holding the right trigger."},
                new ButtonInfo { buttonText = "Mosa Speed", method =() => Movement.MosaSpeed(), toolTip = "Legit Speed Boost"},
                new ButtonInfo { buttonText = "Teleport Gun", method =() => Movement.TeleportGun(), toolTip = "Teleports you to wherever your pointer is when pressing trigger."},
                new ButtonInfo { buttonText = "Long Arms", method =() => Movement.LongArms(), toolTip = "Increases the length of your arms."},
                new ButtonInfo { buttonText = "WASD Fly", method =() => Movement.WASDFly(), toolTip = "Move on PC"},
                new ButtonInfo { buttonText = "Auto Funny Run", method =() => Troll_Fun.AutoFunnyRun(), toolTip = "Automatically runs the funny run mod."},
                new ButtonInfo { buttonText = "Iron Monke", method =() => Movement.IronMonke(), toolTip = "Press ur grips to fly"},
                new ButtonInfo { buttonText = "Air Swim", method =() => Movement.AirSwim(), toolTip = "Allows you to swim in the air"},
                new ButtonInfo { buttonText = "Disable AirSwim", method =() => Movement.DisableAirSwim(), toolTip = "Disables the air swim mod"},
                new ButtonInfo { buttonText = "Walk on Water", method =() => Movement.WalkOnWater(), toolTip = "Allows you to walk on water "},
            },

            new ButtonInfo[] { // Advantage Mods [8]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "No Tag on Joins", method =() => Advantages.TagAll(), toolTip = "Prevents you from being tagged when joining a game   ."},
                new ButtonInfo { buttonText = "Tag Gun", method =() => Advantages.TagGun(), toolTip = "Tags the player when you shoot the tag gun."},
                new ButtonInfo { buttonText = "Tag Self", method =() => Advantages.TagSelf(), toolTip = "Tags yourself."},
                new ButtonInfo { buttonText = "Tag All", method =() => Advantages.TagAll(), toolTip = "Tags all players."},
                new ButtonInfo { buttonText = "Tag Closest", method =() => Advantages.TagClosest(), toolTip = "Tags the closest player."},
                new ButtonInfo { buttonText = "No Tag Freeze", method =() => Advantages.NoTagFreeze(), toolTip = "Prevents you from being frozen when tagged."},
            },

            new ButtonInfo[] { // Visual Mods [9]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Box ESP", method =() => Visual.BoxESP(), toolTip = "Puts a box around players"},
                new ButtonInfo { buttonText = "NameTags", method =() => Visual.NameTags(), toolTip = "Displays names above players"},
                new ButtonInfo { buttonText = "Tracers", method =() => Visual.Tracers(), toolTip = "Draws lines to players"},
            },

            new ButtonInfo[] { // RPC Mods [10]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "AK47 Spammer", method =() => Fun.AK47SoundSpam(), toolTip = "Spams the AK47 sound"},
                new ButtonInfo { buttonText = "Big Crystal Spammer", method =() => Fun.BigCrystalSoundSpam(), toolTip = "Spams the Big Crystal sound"},
                new ButtonInfo { buttonText = "Cat Spam", method =() => Fun.CatSoundSpam(), toolTip = "Spams the Cat sound"},
                new ButtonInfo { buttonText = "Bass Sound Spam", method =() => Fun.BassSoundSpam(), toolTip = "Spams the Bass sound"},
                new ButtonInfo { buttonText = "Bee Sound Spam", method =() => Fun.BeeSoundSpam(), toolTip = "Spams the Bee sound"},
                new ButtonInfo { buttonText = "Earrape Sound Spam", method =() => Fun.EarrapeSoundSpam(), toolTip = "Spams the Earrape sound"},
                new ButtonInfo { buttonText = "Big Crystal Sound Spam", method =() => Fun.BigCrystalSoundSpam(), toolTip = "Spams the Big Crystal sound"},
                new ButtonInfo { buttonText = "Max Quest Score", method =() => Fun.MaxQuestScore(), toolTip = "Sets your quest score to the maximum value"},
                new ButtonInfo { buttonText = "Disable Network Triggers", method =() => Safety.DisableNetworkTriggers(), toolTip = "Disables network triggers"},
                new ButtonInfo { buttonText = "DrawGun", method =() => Gunlib.UpdatePointer(), toolTip = "Toggles the cube pointer."},
                new ButtonInfo { buttonText = "HoverBoard Spammer", method =() => Fun.HoverboardSpam(), toolTip = "Spawn HoverBoard"},
                new ButtonInfo { buttonText = "FlushRPCS", method =() => Fun.FlushRPCS(), toolTip = "Flushes all RPCs"},
                new ButtonInfo { buttonText = "Stump Kick All", method =() => Fun.Stumpkickall(), toolTip = "Stumps kicks players"},
            },

            new ButtonInfo[] { // Rig Mods [11]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Ghost Monke", method =() => Troll_Fun.GhostMonke(), toolTip = "Freezes your rig for trolling"},
                new ButtonInfo { buttonText = "Hold Rig", method =() => Troll_Fun.HoldRig(), toolTip = "Hold your rig in your hand"},
                new ButtonInfo { buttonText = "Spinbot", method =() => Troll_Fun.spinbot(), toolTip = "Spin around but can still play the game"},
                new ButtonInfo { buttonText = "Helicopter Monke", method =() => Troll_Fun.HelicopterMonke(), toolTip = "Makes you look like a helicopter."},
                new ButtonInfo { buttonText = "T Pose", method =() => Movement.TPose(), toolTip = "Makes a Tpose"},
                new ButtonInfo { buttonText = "Lag Rig Self", method =() => Troll_Fun.LagRigSelf(), toolTip = "Lags you rig but doesn't lag ur game."},
            },

            new ButtonInfo[] { // TimeChange Mods [12]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Morning", method =() => Weather.Morning(), toolTip = "Sets the time to morning."},
                new ButtonInfo { buttonText = "Evening", method =() => Weather.Evening(), toolTip = "Sets the time to evening."},
                new ButtonInfo { buttonText = "Day", method =() => Weather.Day(), toolTip = "Sets the time to day."},
                new ButtonInfo { buttonText = "Night", method =() => Weather.Night(), toolTip = "Sets the time to night."},
            },

            new ButtonInfo[] { // Credits [13]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "click me ", method =() => discord.JoinDiscord(), toolTip = "W for all the menus i have skidded"},
            },
        };
    }
}
