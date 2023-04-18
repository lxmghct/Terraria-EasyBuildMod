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
            if (UISystem.CurrentMenuUI is null || UISystem.CurrentMenuUI.AreaSelectItem is null)
            {
                return;
            }
            AreaSelectItem currentItem = UISystem.CurrentMenuUI.AreaSelectItem;
            Player player = Main.player[Main.myPlayer];
            Item item = player.inventory[player.selectedItem];
            if (item.type != currentItem.Type)
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
                    UISystem.CurrentMenuUI.AreaSelectItem.HandleMouseUp();
                }
            }
        }

        public override void OnEnterWorld(Player player)
        {
            UISystem.Init();
            UISystem.ItemPlaceHelperUI.Init();
            UISystem.ItemDestroyHelperUI.Init();
        }

        // 重写CanUseItem方法，防止使用UI时不小心使用其他物品。
        public override bool CanUseItem(Item item)
        {
            if (!UISystem.UsingUI)
            {
                return true;
            }
            if (item.type == ModContent.ItemType<ItemPlaceHelper>() || item.type == ModContent.ItemType<ItemDestroyHelper>()) {
                return true;
            }
            return false;
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