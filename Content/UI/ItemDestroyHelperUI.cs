
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

        public bool EnableTileDestroy;
        public bool EnableWallDestroy;

        public override void OnInitialize()
        {
            base.OnInitialize();

            TileDestroyButton = new RoundButton();
            TileDestroyButton.Left.Set(50, 0);
            TileDestroyButton.Top.Set(40, 0);
            MainContainer.Append(TileDestroyButton);
            TileDestroyButton.SetContent(ModContent.Request<Texture2D>("EasyBuildMod/Assets/images/pickaxe"));
            EnableTileDestroy = false;
            TileDestroyButton.SetHoverText(GetText("DestroyTile") + ":" + GetText("Off"));

            WallDestroyButton = new RoundButton();
            WallDestroyButton.Left.Set(110, 0);
            WallDestroyButton.Top.Set(40, 0);
            MainContainer.Append(WallDestroyButton);
            WallDestroyButton.SetContent(ModContent.Request<Texture2D>("EasyBuildMod/Assets/images/hammer"));
            EnableWallDestroy = false;
            WallDestroyButton.SetHoverText(GetText("DestroyWall") + ":" + GetText("Off"));

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
        }

    }
    
}