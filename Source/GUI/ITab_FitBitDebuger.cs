﻿#region

using PumpingSteel.Tools;
using RimWorld;
using UnityEngine;
using Verse;

#endregion

namespace PumpingSteel.GymUI
{
    public class Tab_InspecterFitnessDebuger : ITab_BasePlus
    {
        public Vector2 Size = new Vector2(300f, 500f);

        public Tab_InspecterFitnessDebuger()
        {
            labelKey = "TabFitBitDebug";
            tutorTag = "FitBitDebug";

            size = Size;
        }

        public override bool IsVisible => SelPawn.RaceProps.Humanlike && Prefs.DevMode;

        public override void TabUpdate()
        {
            base.TabUpdate();
        }


        protected override void FillTab()
        {
            if (Finder.StaminaTracker.TryGet(SelPawn, out var unit))
            {
                var yOffset = 35f;
                var tyOffset = yOffset;

                Text.Font = GameFont.Small;

                Widgets.DrawLine(new Vector2(10, yOffset), new Vector2(290f, yOffset), Color.white, 2f);
                yOffset += 5;

                Widgets.Label(new Rect(10, yOffset, 280f, 35), "Set body size");
                yOffset += 25;

                if (Widgets.ButtonText(new Rect(10, yOffset, 70, 30), "skinny"))
                    SelPawn.SetBodySize(BodyTypeDefOf.Thin);

                if (Widgets.ButtonText(new Rect(80, yOffset, 70, 30), "medium"))
                {
                    if (SelPawn.gender == Gender.Male)
                        SelPawn.SetBodySize(BodyTypeDefOf.Male);
                    else
                        SelPawn.SetBodySize(BodyTypeDefOf.Female);
                }

                if (Widgets.ButtonText(new Rect(150, yOffset, 70, 30), "hulk")) SelPawn.SetBodySize(BodyTypeDefOf.Hulk);

                if (Widgets.ButtonText(new Rect(220, yOffset, 70, 30), "fat")) SelPawn.SetBodySize(BodyTypeDefOf.Fat);

                yOffset += 35;

                Widgets.DrawLine(new Vector2(10, yOffset), new Vector2(290f, yOffset), Color.white, 2f);
                yOffset += 5;

                Text.Font = GameFont.Tiny;

                if (Widgets.ButtonText(new Rect(10, yOffset, 80, 30), "Toggle Logging"))
                    unit.DEBUG = !unit.DEBUG;

                Widgets.Label(new Rect(110, yOffset, 70, 30), "Stamina Level " + unit.staminaLevel);
                Widgets.Label(new Rect(220, yOffset, 70, 30), "Stamina Capacity " + unit.maxStaminaLevel);
                yOffset += 45;

                Widgets.DrawLine(new Vector2(10, yOffset), new Vector2(290f, yOffset), Color.white, 2f);
                yOffset += 5;
            }
            else
            {
                Widgets.Label(new Rect(10, 10, 100, 30), "No Fitness Component Found");
                Logging.Error("No Fitness Component Found");
            }
        }

        public override void OnOpen()
        {
            base.OnOpen();
        }

        protected override void CloseTab()
        {
            base.CloseTab();
        }
    }
}