using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using static SharpShooter.ChampionCore;

namespace SharpShooter.Champions
{
    /// <summary>
    ///    Vayne script
    /// </summary>
    public class Vayne
    {
        public Vayne()
        {
            // set spell
            Q = new Spell(SpellSlot.Q, 300f);
            W = new Spell(SpellSlot.W);
            E = new Spell(SpellSlot.E, 650f) { Delay = 0.25f };
            R = new Spell(SpellSlot.R);

            // set menu
            QMenu = MainMenu.Add(new Menu("Q", "[Q] Tumble"));

            WMenu = MainMenu.Add(new Menu("W", "[W] Silver Bolts"));

            EMenu = MainMenu.Add(new Menu("E", "[E] Condemn"));

            RMenu = MainMenu.Add(new Menu("R", "[R] Final Hour"));

            // event delegate
            AIBaseClient.OnDoCast += OnDoCast;
            AntiGapcloser.OnGapcloser += OnGapcloser;
        }

        // This event is fired before starting spell cast.
        private void OnDoCast(AIBaseClient sender, AIBaseClientProcessSpellCastEventArgs args)
        {
            if (sender == null || !sender.IsValid || sender.GetType() != typeof(AIHeroClient) || !sender.IsEnemy)
            {
                return;
            }

            // fuck off alistar
            if (sender.CharacterName == "Alistar" && args.Slot == SpellSlot.W && args.Target != null && args.Target.IsValid && args.Target.IsMe)
            {
                if (E.IsReady())
                {
                    E.CastOnUnit(sender);
                }
            }
        }

        // This event is detection of AntiGapcloser.
        private void OnGapcloser(AIHeroClient sender, AntiGapcloser.GapcloserArgs args)
        {
            if (sender == null || !sender.IsValid || !sender.IsEnemy)
            {
                return;
            }

            // too far
            if (args.Type == AntiGapcloser.GapcloserType.SkillShot && args.EndPosition.DistanceToPlayer() > 300f)
            {
                return;
            }

            // not player
            if (args.Type == AntiGapcloser.GapcloserType.Targeted && (args.Target == null || !args.Target.IsValid || !args.Target.IsMe))
            {
                return;
            }

            E.CastOnUnit(sender);
        }
    }
}
