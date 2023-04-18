
namespace EasyBuildMod.Common.Utils
{
    public static class LiquidUtils
    {
        public static void clearLiquid(int x, int y)
        {
            Tile tile = Main.tile[x, y];
            tile.LiquidAmount = 0;
            WorldGen.SquareTileFrame(x, y, false);
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                NetMessage.sendWater(x, y);
            }
            else
            {
                Liquid.AddWater(x, y);
            }
        }

        public static void placeLiquid(int x, int y, int liquidId)
        {
            Tile tile = Main.tile[x, y];
            tile.LiquidType = liquidId;
            tile.LiquidAmount = 255;
            WorldGen.SquareTileFrame(x, y, false);
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                NetMessage.sendWater(x, y);
            }
            else
            {
                Liquid.AddWater(x, y);
            }
        }

        public static int getLiquidType(int itemType)
        {
            switch (itemType)
            {
                case ItemID.WaterBucket:
                case ItemID.BottomlessBucket:
                    return LiquidID.Water;
                case ItemID.LavaBucket:
                case ItemID.BottomlessLavaBucket:
                    return LiquidID.Lava;
                case ItemID.HoneyBucket:
                    return LiquidID.Honey;
                default:
                    return -1;
            }
        }
    }
}