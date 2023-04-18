
using EasyBuildMod.Common.Systems;
using EasyBuildMod.Common.Utils;

namespace EasyBuildMod.Content.Items
{
    public class ItemDestroyHelper : AreaSelectItem
    {
        public override string Texture => "EasyBuildMod/Content/Items/ItemDestroyHelper";

        private int _maxPickPower;
        private int _maxHammerPower;

        public override void AddRecipes()
        {
            // 20个铁锭/铅锭
            CreateRecipe()
                .AddRecipeGroup("IronBar", 20)
                .AddTile(TileID.Anvils)
                .Register();
        }

        private void updateMaxPower(Player player)
        {
            _maxPickPower = 0;
            _maxHammerPower = 0;
            for (int i = 0; i < player.inventory.Length; i++)
            {
                Item item = player.inventory[i];
                if (item.IsAir)
                {
                    continue;
                }
                if (item.pick > _maxPickPower)
                {
                    _maxPickPower = item.pick;
                }
                if (item.hammer > _maxHammerPower)
                {
                    _maxHammerPower = item.hammer;
                }
            }
        }

        protected override bool useItemCondition(Player player)
        {
            if (!UISystem.ItemDestroyHelperUI.EnableTileDestroy && !UISystem.ItemDestroyHelperUI.EnableWallDestroy && !UISystem.ItemDestroyHelperUI.EnableLiquidDestroy)
            {
                return false;
            }
            updateMaxPower(player);
            bool t1 = UISystem.ItemDestroyHelperUI.EnableTileDestroy && _maxPickPower > 0;
            bool t2 = UISystem.ItemDestroyHelperUI.EnableWallDestroy && _maxHammerPower > 0;
            return t1 || t2 || UISystem.ItemDestroyHelperUI.EnableLiquidDestroy;
        }

        public override bool CanUseItem(Player player)
        {
            _menuUI = UISystem.ItemDestroyHelperUI;
            return base.CanUseItem(player);
        }

        protected override void StartAction(Player player)
        {
            updateMaxPower(player);
            bool t1 = UISystem.ItemDestroyHelperUI.EnableTileDestroy && _maxPickPower > 0;
            bool t2 = UISystem.ItemDestroyHelperUI.EnableWallDestroy && _maxHammerPower > 0;
            bool t3 = UISystem.ItemDestroyHelperUI.EnableLiquidDestroy;
            var rect = GetRectangle(_beginPoint, _endPoint);
            bool isMultiplayer = Main.netMode == NetmodeID.MultiplayerClient;
            // 从上到下，从左到右
            for (int y = rect.Y; y < rect.Y + rect.Height; y++)
            {
                for (int x = rect.X; x < rect.X + rect.Width; x++)
                {
                    Tile tile = Main.tile[x, y];
                    if (t1 && tile.HasTile)
                    {
                        if (player.HasEnoughPickPowerToHurtTile(x, y))
                        {
                            WorldGen.KillTile(x, y, false, false, false);
                            if (isMultiplayer)
                            {
                                NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, (float)x, (float)y, 0f, 0, 0, 0);
                            }
                            // player.PickTile(x, y, 100000);
                        }
                    }
                    if (t2 && tile.WallType != 0)
                    {
                        WorldGen.KillWall(x, y, false);
                        if (isMultiplayer)
                        {
                            NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 2, (float)x, (float)y, 0f, 0, 0, 0);
                        }
                    }
                    if (t3 && tile.LiquidAmount > 0)
                    {
                        LiquidUtils.clearLiquid(x, y);
                    }
                }
            }
            // if (Main.netMode == NetmodeID.MultiplayerClient)
            // {
            //     NetMessage.SendData(MessageID.TileSquare, Main.myPlayer, -1, null, rect.X, rect.Y, rect.Width, rect.Height);
            // }
        }
                
    }
}