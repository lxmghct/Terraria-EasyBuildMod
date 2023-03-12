
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace EasyBuildMod.Content.Items
{
    public class ItemGrabMagnet : ModItem
    {
        internal static string GetText(string str, params object[] args)
        {
            return Language.GetTextValue($"Mods.EasyBuildMod.Content.Items.ItemGrabMagnet.{str}", args);
        }

        public override string Texture => "EasyBuildMod/Content/Items/ItemGrabMagnet";

        private Player currentPlayer;
        private bool _isMagnetOn;
        public bool IsMagnetOn
        {
            get => _isMagnetOn;
            set
            {
                if (_isMagnetOn != value)
                {
                    _isMagnetOn = value;
                    HandleMagnetStatusChange();
                }
            }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(GetText("Name"));
            Tooltip.SetDefault(GetText("Description") + $"\n{GetText("Usage")}");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 15;
            Item.useTime = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
            IsMagnetOn = false;
        }

        public override void AddRecipes()
        {
            // 20个铁锭/铅锭
            CreateRecipe()
                .AddRecipeGroup("IronBar", 20)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override bool? UseItem(Player player)
        {
            currentPlayer = player;
            IsMagnetOn = !IsMagnetOn;
            return true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string color = IsMagnetOn ? "00FF00" : "FF0000";
            string tooltop = IsMagnetOn ? GetText("OnTooltip") : GetText("OffTooltip");
            var line = new TooltipLine(Mod, GetText("StatusName"), $"[c/{color}:{tooltop}]");
            tooltips.Add(line);
        }

        internal void HandleMagnetStatusChange()
        {
            if (currentPlayer == null)
            {
                return;
            }
            if (IsMagnetOn)
            {
                CombatText.NewText(currentPlayer.Hitbox, Color.Green, GetText("OnTooltip"));
                currentPlayer.AddBuff(ModContent.BuffType<Buffs.ItemGrabBuff>(), 2592000);
            }
            else
            {
                CombatText.NewText(currentPlayer.Hitbox, Color.Red, GetText("OffTooltip"));
                currentPlayer.ClearBuff(ModContent.BuffType<Buffs.ItemGrabBuff>());
            }
        }

    }
}