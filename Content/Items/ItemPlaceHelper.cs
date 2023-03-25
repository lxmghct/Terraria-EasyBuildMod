
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
            // 这种顺序可以保证某些具有自由落体性质的方块(如沙块)能够被正确的放置
            // 不过也会导致替换方块时, 像沙块这样的方块无法被从下往上替换
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
                            if (!player.TileReplacementEnabled || !player.HasEnoughPickPowerToHurtTile(x, y))
                            {
                                continue;
                            }
                            // 判断是否是同一种方块，是则跳过
                            WorldGen.KillTile_GetItemDrops(x, y, tile, out int tileType, out _, out _, out _);
                            if (tileType == item.type)
                            {
                                continue;
                            }
                            // if (WorldGen.ReplaceTile(x, y, (ushort)item.createTile, item.placeStyle))
                            // {
                            //     consumeCount++;
                            // }
                            player.PickTile(x, y, 100000);
                        }
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
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                NetMessage.SendData(MessageID.TileSquare, Main.myPlayer, -1, null, rect.X, rect.Y, rect.Width, rect.Height);
            }
        }
                
    }
}