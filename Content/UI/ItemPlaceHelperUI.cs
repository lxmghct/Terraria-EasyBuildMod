using EasyBuildMod.Content.Items;
using EasyBuildMod.Content.UIElements;

namespace EasyBuildMod.Content.UI
{
    // 带有1个按钮的UI
    public class ItemPlaceHelperUI : UIState
    {
        internal ItemPlaceHelper itemPlaceHelper;

        public ItemSelectButton itemSelectButton;

        public UIElement MainContainer;

        public bool Visible;

        public override void OnInitialize()
        {
            base.OnInitialize();
            Append(MainContainer = new ());
            MainContainer.Width.Set(200, 0);
            MainContainer.Height.Set(200, 0);
            itemSelectButton = new ItemSelectButton();
            itemSelectButton.Left.Set(0, 0);
            itemSelectButton.Top.Set(0, 0);
            MainContainer.Append(itemSelectButton);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
        }

        public void Open(ItemPlaceHelper itemPlaceHelper)
        {
            this.itemPlaceHelper = itemPlaceHelper;
            Visible = true;
            // 注意要除以UIScale，否则如果缩放比例不是100%就会错位
            MainContainer.Left.Set(Main.mouseX / Main.UIScale - MainContainer.Width.Pixels / 2, 0);
            MainContainer.Top.Set(Main.mouseY / Main.UIScale - MainContainer.Height.Pixels / 2, 0);
            
        }

        public void Close()
        {
            Visible = false;
        }

    }
    
}