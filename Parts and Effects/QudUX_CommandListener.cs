using System;

namespace XRL.World.Parts
{
    [Serializable]
    public class QudUX_CommandListener : IPart
    {
        public static readonly string CmdOpenAutogetMenu = "QudUX_OpenAutogetMenu";
        public static readonly string cmdOpenGameStatsMenu = "QudUX_OpenGameStatsMenu";

        public override void Register(GameObject Object)
        {
            Object.RegisterPartEvent(this, CmdOpenAutogetMenu);
            Object.RegisterPartEvent(this, cmdOpenGameStatsMenu);

            base.Register(Object);
        }

		public override bool AllowStaticRegistration()
		{
			return true;
		}

        public override bool FireEvent(Event E)
        {
            if (E.ID == CmdOpenAutogetMenu)
            {
                QudUX.Wishes.AutopickupMenu.Wish();
            }
            if (E.ID == cmdOpenGameStatsMenu)
            {
                QudUX.Wishes.GameStatsMenu.Wish();
            }
            return base.FireEvent(E);
        }
    }
}


// === QudUX 2.0 Errors ===
// <...>\Mods\QudUX_old\Parts and Effects\QudUX_CommandListener.cs(30,17): error CS0234: The type or namespace name 'SpriteMenu' does not exist in the namespace 'QudUX.Wishes' (are you missing an assembly reference?)
// <...>\Mods\QudUX_old\Concepts\Constants.cs(99,50): error CS0103: The name 'AbilityManagerExtender' does not exist in the current context
// <...>\Mods\QudUX_old\Concepts\Constants.cs(217,72): error CS0117: 'Events' does not contain a definition for 'EmbarkEvent'
// == Warnings ==
// None
