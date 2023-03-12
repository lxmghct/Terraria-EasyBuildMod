using EasyBuildMod.Common.Players;
namespace EasyBuildMod.Content.Buffs
{
    public class ItemGrabBuff : ModBuff
    {
        internal static string GetText(string str, params object[] args)
        {
            return Language.GetTextValue($"Mods.EasyBuildMod.Content.Buffs.ItemGrabBuff.{str}", args);
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(GetText("Name"));
            Description.SetDefault(GetText("Description"));
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<EasyBuildModPlayer>().ItemGrabBuff = true;
        }

    }
}