using EasyBuildMod.Content.Items;
using Terraria.GameContent;
using System.IO;
namespace EasyBuildMod.Content.UIElements
{
    public class ItemSelectButton : RoundButton
    {
        private ItemPlaceHelper itemPlaceHelper;
        
        public void SetItemPlaceHelper(ItemPlaceHelper itemPlaceHelper)
        {
            this.itemPlaceHelper = itemPlaceHelper;
        }
        public override void Click(UIMouseEvent evt)
        {
            base.Click(evt);
            if (itemPlaceHelper == null)
            {
                return;
            }
            if (Main.mouseItem.type != 0)
            {
                // 如果物块可以放置，则添加进来
                if ((Main.mouseItem.createTile != -1 && Main.tileSolid[Main.mouseItem.createTile]) || Main.mouseItem.createWall != -1)
                {
                    itemPlaceHelper.PlaceItem = Main.mouseItem.Clone();
                    SetContent(TextureAssets.Item[Main.mouseItem.type]);
                }
            }
            else
            {
                SetContent(null);
                itemPlaceHelper.PlaceItem = null;
            }
        }
    }
}