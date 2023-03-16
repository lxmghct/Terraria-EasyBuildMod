
using EasyBuildMod.Content.UIElements;
using Terraria.GameContent;

namespace EasyBuildMod.Content.UI
{
    public class ItemDestroyHelperUI : MenuUI
    {
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

            WallDestroyButton = new RoundButton();
            WallDestroyButton.Left.Set(110, 0);
            WallDestroyButton.Top.Set(40, 0);
            MainContainer.Append(WallDestroyButton);
            WallDestroyButton.SetContent(ModContent.Request<Texture2D>("EasyBuildMod/Assets/images/hammer"));
        }

    }
    
}