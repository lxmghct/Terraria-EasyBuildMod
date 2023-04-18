
using EasyBuildMod.Content.UIElements;
using Terraria.GameContent;
using EasyBuildMod.Common.Utils;

namespace EasyBuildMod.Content.UI
{
    public class ItemPlaceHelperUI : MenuUI
    {
        protected RoundButton itemSelectButton;

        public override void OnInitialize()
        {
            base.OnInitialize();
            itemSelectButton = new RoundButton();
            itemSelectButton.Left.Set(50, 0);
            itemSelectButton.Top.Set(40, 0);
            MainContainer.Append(itemSelectButton);

            itemSelectButton.OnClick += (evt, element) =>
            {
                if (AreaSelectItem == null)
                {
                    return;
                }
                if (Main.mouseItem.type != 0)
                {
                    // 如果物块可以放置，则添加进来
                    if ((Main.mouseItem.createTile != -1 && Main.tileSolid[Main.mouseItem.createTile]) ||
                         Main.mouseItem.createWall != -1 ||
                         LiquidUtils.getLiquidType(Main.mouseItem.type) != -1)
                    {
                        AreaSelectItem.ContentItemType = Main.mouseItem.type;
                        itemSelectButton.SetContent(TextureAssets.Item[Main.mouseItem.type]);
                    }
                }
                else
                {
                    itemSelectButton.SetContent(null);
                    AreaSelectItem.ContentItemType = 0;
                }
            };
        }

        public override void Init()
        {
            base.Init();
            itemSelectButton.SetContent(null);
        }

    }
    
}