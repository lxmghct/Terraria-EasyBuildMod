using EasyBuildMod.Common.Players;

namespace EasyBuildMod.Content.Buffs
{
    public class ItemGrabBuff : ModBuff
    {
        
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<EasyBuildModPlayer>().ItemGrabBuff = true;
        }

    }
}