
using EasyBuildMod.Content.UIElements;
using Terraria.GameContent;

namespace EasyBuildMod.Content.UI
{
    public class ItemDestroyHelperUI : MenuUI
    {
        internal static string GetText(string str, params object[] args)
        {
            return Language.GetTextValue($"Mods.EasyBuildMod.Content.Items.ItemDestroyHelper.{str}", args);
        }
        protected RoundButton TileDestroyButton;
        protected RoundButton WallDestroyButton;
        protected RoundButton LiquidDestroyButton;

        public bool EnableTileDestroy;
        public bool EnableWallDestroy;
        public bool EnableLiquidDestroy;

        public override void OnInitialize()
        {
            base.OnInitialize();

            TileDestroyButton = new RoundButton();
            TileDestroyButton.Left.Set(20, 0);
            TileDestroyButton.Top.Set(40, 0);
            MainContainer.Append(TileDestroyButton);
            TileDestroyButton.SetContent(ModContent.Request<Texture2D>("EasyBuildMod/Assets/images/pickaxe"));
            EnableTileDestroy = false;
            TileDestroyButton.SetHoverText(GetText("DestroyTile") + ":" + GetText("Off"));

            WallDestroyButton = new RoundButton();
            WallDestroyButton.Left.Set(80, 0);
            WallDestroyButton.Top.Set(40, 0);
            MainContainer.Append(WallDestroyButton);
            WallDestroyButton.SetContent(ModContent.Request<Texture2D>("EasyBuildMod/Assets/images/hammer"));
            EnableWallDestroy = false;
            WallDestroyButton.SetHoverText(GetText("DestroyWall") + ":" + GetText("Off"));

            LiquidDestroyButton = new RoundButton();
            LiquidDestroyButton.Left.Set(140, 0);
            LiquidDestroyButton.Top.Set(40, 0);
            MainContainer.Append(LiquidDestroyButton);
            LiquidDestroyButton.SetContent(ModContent.Request<Texture2D>("EasyBuildMod/Assets/images/bucket"));
            EnableLiquidDestroy = false;
            LiquidDestroyButton.SetHoverText(GetText("DestroyLiquid") + ":" + GetText("Off"));

            TileDestroyButton.OnClick += (evt, element) =>
            {
                EnableTileDestroy = !EnableTileDestroy;
                TileDestroyButton.SetChosen(EnableTileDestroy);
                TileDestroyButton.SetHoverText(GetText("DestroyTile") + ":" + (EnableTileDestroy ? GetText("On") : GetText("Off")));
            };

            WallDestroyButton.OnClick += (evt, element) =>
            {
                EnableWallDestroy = !EnableWallDestroy;
                WallDestroyButton.SetChosen(EnableWallDestroy);
                WallDestroyButton.SetHoverText(GetText("DestroyWall") + ":" + (EnableWallDestroy ? GetText("On") : GetText("Off")));
            };

            LiquidDestroyButton.OnClick += (evt, element) =>
            {
                EnableLiquidDestroy = !EnableLiquidDestroy;
                LiquidDestroyButton.SetChosen(EnableLiquidDestroy);
                LiquidDestroyButton.SetHoverText(GetText("DestroyLiquid") + ":" + (EnableLiquidDestroy ? GetText("On") : GetText("Off")));
            };
        }

    }
    
}