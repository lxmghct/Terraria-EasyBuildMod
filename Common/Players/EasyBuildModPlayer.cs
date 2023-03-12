
namespace EasyBuildMod.Common.Players
{
    public class EasyBuildModPlayer : ModPlayer
    {
        public bool ItemGrabBuff { get; set; }

        public override void ResetEffects()
        {
            ItemGrabBuff = false;
        }

        public override void PreUpdate()
        {
            ItemGrabBuff = false;
        }

    }

    public class EasyBuildModGlobalItem : GlobalItem
    {
        public override void GrabRange(Item item, Player player, ref int grabRange)
        {
            if (player.GetModPlayer<EasyBuildModPlayer>().ItemGrabBuff)
            {
                grabRange *= 10;
            }
        }
    }
}