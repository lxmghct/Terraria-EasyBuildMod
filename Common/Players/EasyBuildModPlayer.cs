using EasyBuildMod.Common.Systems;
using EasyBuildMod.Common.Config;
using EasyBuildMod.Content.Items;

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

        public override void OnRespawn(Player player)
        {
            UISystem.Hide();
            DrawingSystem.StopDraw();
        }

        public override void UpdateDead()
        {
            UISystem.Hide();
            DrawingSystem.StopDraw();
        }

        public override void PostUpdate()
        {
            if (UISystem.ItemPlaceHelperUI.itemPlaceHelper is null)
            {
                return;
            }
            Player player = Main.player[Main.myPlayer];
            Item item = player.inventory[player.selectedItem];
            if (item.type != ModContent.ItemType<ItemPlaceHelper>())
            {
                if (!Main.playerInventory)
                {
                    UISystem.Hide();
                }
                DrawingSystem.Close();
            }
            else
            {
                DrawingSystem.Init();
                if (!Main.mouseLeft)
                {
                    UISystem.ItemPlaceHelperUI.itemPlaceHelper.HandleMouseUp();
                }
            }
        }

        public override void OnEnterWorld(Player player)
        {
            UISystem.Init();
        }
        
    }

    public class EasyBuildModGlobalItem : GlobalItem
    {
        public override void GrabRange(Item item, Player player, ref int grabRange)
        {
            if (player.GetModPlayer<EasyBuildModPlayer>().ItemGrabBuff)
            {
                grabRange = ModContent.GetInstance<EasyBuildModConfig>().MagnetRange * 16;
            }
        }
    }
}