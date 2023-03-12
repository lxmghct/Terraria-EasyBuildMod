using EasyBuildMod.Content.Items;
using EasyBuildMod.Content.UIElements;

namespace EasyBuildMod.Content.UI
{
    // 带有1个按钮的UI
    public class ItemPlaceHelperUI : UIState
    {
        internal ItemPlaceHelper itemPlaceHelper;

        public ItemSelectButton itemSelectButton;

        public UIElement MainPanel;

        public bool Visible;

        public override void OnInitialize()
        {
            base.OnInitialize();
            Append(MainPanel = new ());
            MainPanel.Width.Set(200, 0);
            MainPanel.Height.Set(200, 0);
            itemSelectButton = new ItemSelectButton();
            itemSelectButton.Left.Set(0, 0);
            itemSelectButton.Top.Set(0, 0);
            MainPanel.Append(itemSelectButton);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            itemSelectButton.Draw(spriteBatch);
        }

        public void Open(ItemPlaceHelper itemPlaceHelper)
        {
            this.itemPlaceHelper = itemPlaceHelper;
            Visible = true;
            Left.Set(Main.MouseScreen.X - Width.Pixels / 2, 0);
            Top.Set(Main.MouseScreen.Y - Height.Pixels / 2, 0);
            Main.LocalPlayer.mouseInterface = true;
        }

        public void Close()
        {
            Visible = false;
        }

    }
    
}