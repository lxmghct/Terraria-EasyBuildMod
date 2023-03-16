
using EasyBuildMod.Common.Systems;
namespace EasyBuildMod.Content.Items
{
    public class ItemPlaceHelper : AreaSelectItem
    {
        public override string Texture => "EasyBuildMod/Content/Items/ItemPlaceHelper";

        public override void AddRecipes()
        {
            // 20个铁锭/铅锭
            CreateRecipe()
                .AddRecipeGroup("IronBar", 20)
                .AddTile(TileID.Anvils)
                .Register();
        }

        protected override bool useItemCondition(Player player)
        {
            return GetItemCountOfInventory(player.inventory, ContentItemType) > 0;
        }

        public override bool CanUseItem(Player player)
        {
            _menuUI = UISystem.ItemPlaceHelperUI;
            return base.CanUseItem(player);
        }

        protected override void StartAction(Player player)
        {
            var rect = GetRectangle(_beginPoint, _endPoint);
            int consumeCount = 0;
            int total = GetItemCountOfInventory(player.inventory, ContentItemType);
            Item item = new Item();
            item.SetDefaults(ContentItemType);
            // 从下到上，从左到右
            for (int y = rect.Y + rect.Height - 1; y >= rect.Y; y--)
            {
                for (int x = rect.X; x < rect.X + rect.Width; x++)
                {
                    if (consumeCount >= total)
                    {
                        break;
                    }
                    if (Main.tile[x, y].HasTile)
                    {
                        if (!player.TileReplacementEnabled)
                        {
                            continue;
                        }
                        var tile = Main.tile[x, y];
                        if (!player.HasEnoughPickPowerToHurtTile(x, y))
                        {
                            continue;
                        }
                        if (WorldGen.ReplaceTile(x, y, (ushort)item.createTile, item.placeStyle))
                        {
                            consumeCount++;
                        }
                        // else // 无法替换，强行破坏后放置
                        // {
                        //     player.PickTile(x, y, 10000);
                        //     if (!Main.tile[x, y].HasTile && WorldGen.PlaceTile(x, y, (ushort)item.createTile, true, true, player.whoAmI, item.placeStyle))
                        //     {
                        //         consumeCount++;
                        //     }
                        // }
                    }
                    else
                    {
                        if (WorldGen.PlaceTile(x, y, (ushort)item.createTile, true, true, player.whoAmI, item.placeStyle))
                        {
                            consumeCount++;
                        }
                    }
                }
            }
            if (consumeCount > 0)
            {
                for (int i = 0; i < player.inventory.Length; i++)
                {
                    if (player.inventory[i].type == ContentItemType)
                    {
                        if (player.inventory[i].stack > consumeCount)
                        {
                            player.inventory[i].stack -= consumeCount;
                            break;
                        }
                        else
                        {
                            consumeCount -= player.inventory[i].stack;
                            player.inventory[i].SetDefaults();
                        }
                    }
                }
            }
        }
                
    }
}