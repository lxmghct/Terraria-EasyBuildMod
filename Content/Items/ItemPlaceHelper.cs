
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

        public int getMaxHammerPower(Player player)
        {
            int maxHammerPower = 0;
            for (int i = 0; i < player.inventory.Length; i++)
            {
                Item item = player.inventory[i];
                if (item.IsAir)
                {
                    continue;
                }
                if (item.hammer > maxHammerPower)
                {
                    maxHammerPower = item.hammer;
                }
            }
            return maxHammerPower;
        }

        protected override void StartAction(Player player)
        {
            var rect = GetRectangle(_beginPoint, _endPoint);
            int consumeCount = 0;
            int total = GetItemCountOfInventory(player.inventory, ContentItemType);
            Item item = new Item();
            item.SetDefaults(ContentItemType);
            bool isWall = item.createWall > 0;
            bool hasHammer = getMaxHammerPower(player) > 0;
            // 从下到上，从左到右
            for (int y = rect.Y + rect.Height - 1; y >= rect.Y; y--)
            {
                for (int x = rect.X; x < rect.X + rect.Width; x++)
                {
                    if (consumeCount >= total)
                    {
                        break;
                    }
                    Tile tile = Main.tile[x, y];
                    if (isWall)
                    {
                        if (tile.WallType > 0)
                        {
                            if (!player.TileReplacementEnabled)
                            {
                                continue;
                            }
                            if (hasHammer)
                            {
                                WorldGen.KillWall(x, y, false);
                                WorldGen.PlaceWall(x, y, (ushort)item.createWall, true);
                                consumeCount++;
                            }
                        }
                        else
                        {
                            WorldGen.PlaceWall(x, y, (ushort)item.createWall, true);
                            consumeCount++;
                        }
                    }
                    else
                    {
                        if (tile.HasTile)
                        {
                            if (!player.TileReplacementEnabled)
                            {
                                continue;
                            }
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