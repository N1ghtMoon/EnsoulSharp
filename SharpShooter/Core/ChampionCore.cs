using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;

namespace SharpShooter
{
    /// <summary>
    ///    this class include usage with champion
    /// </summary>
    public static class ChampionCore
    {
        // menu
        public static Menu MainMenu;
        public static Menu QMenu, WMenu, EMenu, RMenu;

        // localPlayer
        public static AIHeroClient Player;

        // player spell
        public static Spell Q, W, E, R;


    }
}
