
namespace EasyBuildMod.Common.Utils
{
    public static partial class WallUtils
    {
        /// <summary>
        /// 摧毁墙壁，并确保在多人模式下产生掉落物并同步
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="fail"></param>
        public static void KillWall(int x, int y, bool fail = false)
        {
            WorldGen.KillWall(x, y, fail);
            if (!fail && Main.netMode == NetmodeID.MultiplayerClient)
            {
                // Wall对应的SendData第5个参数值为2
                NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 2, (float)x, (float)y, 0f, 0, 0, 0);
            }
        }

    }

    public static class TileUtils
    {
        /// <summary>
        /// 摧毁砖块，并确保在多人模式下产生掉落物并同步
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="fail"></param>
        /// <param name="effectOnly"></param>
        /// <param name="noItem"></param>
        public static void KillTile(int x, int y, bool fail = false, bool effectOnly = false, bool noItem = false)
        {
            WorldGen.KillTile(x, y, fail, effectOnly, noItem);
            if (!fail && Main.netMode == NetmodeID.MultiplayerClient)
            {
                // Tile对应的SendData第5个参数值为0
                NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, (float)x, (float)y, 0f, 0, 0, 0);
            }
        }

    }

}