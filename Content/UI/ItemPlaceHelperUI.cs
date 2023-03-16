using EasyBuildMod.Content.Items;
using EasyBuildMod.Content.UIElements;
using Terraria.GameContent;

namespace EasyBuildMod.Content.UI
{
    // 带有1个按钮的UI
    public class ItemPlaceHelperUI : UIState
    {
        internal ItemPlaceHelper itemPlaceHelper;

        public RoundButton itemSelectButton;

        public UIElement MainContainer;

        public bool Visible;

        public override void OnInitialize()
        {
            base.OnInitialize();
            Append(MainContainer = new ());
            MainContainer.Width.Set(200, 0);
            MainContainer.Height.Set(200, 0);
            itemSelectButton = new RoundButton();
            itemSelectButton.Left.Set(0, 0);
            itemSelectButton.Top.Set(0, 0);
            MainContainer.Append(itemSelectButton);

            itemSelectButton.OnClick += (evt, element) =>
            {
                if (itemPlaceHelper == null)
                {
                    return;
                }
                if (Main.mouseItem.type != 0)
                {
                    // 如果物块可以放置，则添加进来
                    if ((Main.mouseItem.createTile != -1 && Main.tileSolid[Main.mouseItem.createTile]) || Main.mouseItem.createWall != -1)
                    {
                        itemPlaceHelper.PlaceItemType = Main.mouseItem.type;
                        itemSelectButton.SetContent(TextureAssets.Item[Main.mouseItem.type]);
                    }
                }
                else
                {
                    itemSelectButton.SetContent(null);
                    itemPlaceHelper.PlaceItemType = 0;
                }
            };
        }

        public void Init()
        {
            Visible = false;
            itemSelectButton.SetContent(null);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            // if (Main.LocalPlayer.HeldItem != itemPlaceHelper.Item)
            // {
            //     Close();
            // }
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

        public void Hide()
        {
            Visible = false;
            itemPlaceHelper?.StopUse();
        }

    }
    
}