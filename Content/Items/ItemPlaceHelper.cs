using EasyBuildMod.Common;

namespace EasyBuildMod.Content.Items
{
    public class ItemPlaceHelper : ModItem
    {

        private Item _placeItem;
        public Item PlaceItem
        {
            get => _placeItem;
            set
            {
                _placeItem = value;
                updateSelectedItem();
            }
        }

        internal static string GetText(string str, params object[] args)
        {
            return Language.GetTextValue($"Mods.EasyBuildMod.Content.Items.ItemPlaceHelper.{str}", args);
        }

        public override string Texture => "EasyBuildMod/Content/Items/ItemPlaceHelper";

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
            PlaceItem = null;
            UISystem.ItemPlaceHelperUI.Init();
        }

        ///<summary>将角标的剩余物品数更新为PlaceItem的</summary>
        internal void updateSelectedItem()
        {
            if (PlaceItem != null)
            {
                
            }
            else
            {
                
            }
            
        }

        public override void AddRecipes()
        {
            // 20个铁锭/铅锭
            CreateRecipe()
                .AddRecipeGroup("IronBar", 20)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override bool AltFunctionUse(Player player) => true;

        public override bool? UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                // 右键
                if (UISystem.ItemPlaceHelperUI.Visible)
                {
                    UISystem.ItemPlaceHelperUI.Close();
                }
                else
                {
                    UISystem.ItemPlaceHelperUI.Open(this);
                }
            }
            return true;
        }
                
    }
}