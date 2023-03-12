using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace EasyBuildMod.Common.Config
{
    [Label("$Mods.EasyBuildMod.Config.Label")]
    public class EasyBuildModConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("$Mods.EasyBuildMod.Config.MagnetRange")]
        [Slider]
        [SliderColor(255, 255, 50)]
        [Range(10, 200)]
        [Increment(1)]
        [DefaultValue(20)]
        public int MagnetRange { get; set; }
    }
}