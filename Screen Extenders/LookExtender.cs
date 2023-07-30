using ConsoleLib.Console;
using XRL.UI;
using XRL.World;
using XRL.World.Parts;
using static XRL.World.Parts.QudUX_LegendaryInteractionListener;

namespace QudUX.ScreenExtenders
{
    public class LookExtender
    {
        private static Keys? MarkKey = null;

        public static void AddMarkLegendaryOptionToLooker(ScreenBuffer buffer, GameObject target, string uiHotkeyString)
        {
            if ((target.HasProperty("Hero") || target.GetStringProperty("Role") == "Hero") && target.HasPart(typeof(GivesRep)))
            {
                if ((Keys)CommandBindingManager.GetKeyFromCommand("CmdWalk") != Keys.M)
                {
                    MarkKey = Keys.M;
                    buffer.WriteAt(1, 0, uiHotkeyString + " | {{hotkey|M}} - mark in journal");
                }
                else if ((Keys)CommandBindingManager.GetKeyFromCommand("CmdWalk") != Keys.J)
                {
                    MarkKey = Keys.J;
                    buffer.WriteAt(1, 0, uiHotkeyString + " | {{hotkey|J}} - mark in journal");
                }
            }
        }

        public static bool CheckKeyPress(Keys key, GameObject target, bool currentKeyFlag)
        {
            if (currentKeyFlag == true) //already processing a different key request
            {
                return true;
            }
            if (MarkKey != null && key == MarkKey && (target.HasProperty("Hero") || target.GetStringProperty("Role") == "Hero") && target.HasPart(typeof(GivesRep)))
            {
                ToggleLegendaryLocationMarker(target);
                return true;
            }
            return false;
        }
    }
}

// === QudUX 2.0 Errors ===
// <...>\Mods\QudUX_old\Screen Extenders\LookExtender.cs(17,27): error CS0103: The name 'LegacyKeyMapping' does not exist in the current context
// <...>\Mods\QudUX_old\Screen Extenders\LookExtender.cs(22,32): error CS0103: The name 'LegacyKeyMapping' does not exist in the current context

// ScreenExtenders/LookExtender.cs: Search for LegacyKeyMapping and replace it by CommandBindingManager (keep the (Keys) just before it)

// Screen Extenders: AbilityManagerExtender, CharacterTileScreenExtender, CreateCharacterExtender
// Screens: QudUx_CharacterTileScreen
// Wishes: SpriteMenu.cs
// Utilities: FileHandler.cs
// HarmonyPatches: Patch_XRL_UI_AbilityManager

// Now you'll delete some things by groups of 4 lines:

// Concepts/Events.cs : Delete 4 lines from line 17 EmbarkEvent
// Concepts/Constants.cs: Delete 4 lines from line 97 AbilityManagerExtender_UpdateAbilityText, Delete 4 lines from Events_EmbarkEvent
// Patch_XRL_Core_XRLCore.cs: Delete line 26 that mentions EmbarkEvent
// Parts and Effects/QudUX_CommandListener.cs: Delete 4 lines from line 28
// if... CmdOpenSpriteMenu, delete lines 14 and 8 where CmdOpenSpriteMenu
// appear too

// For those who play input beta (205.37) here are the fixes. Devs made massive changes to the ability screen and they managed to make them very enjoyable so I'll also make you delete QudUX ones.

// Apply those fixes after applying both fixes from my earlier msgs:

// - In Screen Extenders/LookExtender.cs: Replace both LegacyKeyMapping by CommandBindingManager (keep the (Keys) right before it and the comma after)

// Character sprite changing options didn't work for a while and are further
// broken by changes that prevent you from starting a game, so let's just
// delete everything related to them (see next msg):
// Delete those files:
// - In Screen Extenders: CharacterTileScreenExtender, CreateCharacterExtender, AbilityManagerExtender
// - Screens: QudUx_CharacterTileScreen
// - Wishes: SpriteMenu.cs
// - Utilities: FileHandler.cs
// - HarmonyPatches: Patch_XRL_UI_AbilityManager

// Then delete those lines/groups:
// - In Concepts/Events.cs: Delete 4 lines from line 17 (included, last brace included too) where EmbarkEvent is mentionned
// - Concepts/Constants.cs: Delete 4 lines from line 97 (AbilityManagerExtender), delete 4 lines from 215 (Events_EmbarkEvent)
// - Patch_XRL_Core_XRLCore.cs: Delete line 26 that mentions EmbarkEvent
// - Parts and Effects/QudUX_CommandListener.cs: Delete 4 lines from 28 (CmdOpenSpriteMenu), delete lines 8 and 14 (same name appears)

// Now QudUX should start fine. Improved Inventory, Disabling Autopickup, Visited Locations, Trader Restock, Legendary Mark all work (see below if the last two don't). Enjoy ;)
