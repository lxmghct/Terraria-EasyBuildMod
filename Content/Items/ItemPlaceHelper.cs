using EasyBuildMod.Common.Systems;
using Terraria.GameContent.Creative;
using System;


namespace EasyBuildMod.Content.Items
{
    public class ItemPlaceHelper : ModItem
    {

        private int _placeItemType;
        public int PlaceItemType
        {
            get => _placeItemType;
            set
            {
                _placeItemType = value;
            }
        }

        public Point _beginPoint;
        public Point _endPoint;
        public bool _startPlacing;

        internal static string GetText(string str, params object[] args)
        {
            return Language.GetTextValue($"Mods.EasyBuildMod.Content.Items.ItemPlaceHelper.{str}", args);
        }

        public override string Texture => "EasyBuildMod/Content/Items/ItemPlaceHelper";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(GetText("Name"));
            Tooltip.SetDefault(GetText("Description") + $"\n{GetText("Usage")}");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Item.staff[Type] = true;
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
            Item.autoReuse = true;
            Item.channel = true;
            Item.consumable = false;
            PlaceItemType = 0;
            _startPlacing = false;
            UISystem.ItemPlaceHelperUI.Init();
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

        public override bool CanUseItem(Player player)
        {
            if (player.noBuilding)
            {
                return false;
            }
            if (player.altFunctionUse == 2)
            {
                if (UISystem.ItemPlaceHelperUI.Visible)
                {
                    UISystem.ItemPlaceHelperUI.Close();
                }
                else
                {
                    UISystem.ItemPlaceHelperUI.Open(this);
                }
                return false;
            }
            if (GetItemCountOfInventory(player.inventory, PlaceItemType) == 0)
            {
                return false;
            }
            if (!_startPlacing)
            {
                _beginPoint = Main.MouseWorld.ToTileCoordinates();
                _startPlacing = true;
            }
            return true;
        }
        
        public override bool? UseItem(Player player)
        {
            _endPoint = Main.MouseWorld.ToTileCoordinates();
            if (!Main.mouseLeft)
            {
                // 鼠标左键松开
                StartPlaceItem(player);
                stopDraw(player);
                _startPlacing = false;
                return true;
            }
            if (Main.mouseRight && _startPlacing)
            {
                // 鼠标右键按下
                stopDraw(player);
                _startPlacing = false;
            }
            else
            {
                DrawingSystem.StartDraw(PlaceItemType, GetRectangle(_beginPoint, _endPoint));
            }
            // 绘制矩形
            return base.UseItem(player);
        }

        private void stopDraw(Player player)
        {
            DrawingSystem.StopDraw();
        }

        public void StopUse()
        {
            _startPlacing = false;
        }

        public int GetItemCountOfInventory(Item[] inventory, int type)
        {
            int count = 0;
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].type == type)
                {
                    count += inventory[i].stack;
                }
            }
            return count;
        }

        private Rectangle GetRectangle(Point begin, Point end)
        {
            var beginVector = begin.ToVector2();
            var endVector = end.ToVector2();
            int startX = Math.Min((int)beginVector.X, (int)endVector.X);
            int startY = Math.Min((int)beginVector.Y, (int)endVector.Y);
            int endX = Math.Max((int)beginVector.X, (int)endVector.X);
            int endY = Math.Max((int)beginVector.Y, (int)endVector.Y);
            return new Rectangle(startX, startY, endX - startX, endY - startY);
        }

        private void StartPlaceItem(Player player)
        {
            if (!_startPlacing)
            {
                return;
            }
            var rect = GetRectangle(_beginPoint, _endPoint);
            int consumeCount = 0;
            int total = GetItemCountOfInventory(player.inventory, PlaceItemType);
            Item item = new Item();
            item.SetDefaults(PlaceItemType);
            // 从下到上，从左到右
            for (int y = rect.Y + rect.Height; y >= rect.Y; y--)
            {
                for (int x = rect.X; x <= rect.X + rect.Width; x++)
                {
                    if (consumeCount >= total)
                    {
                        break;
                    }
                    if (Main.tile[x, y].HasTile)
                    {
                        if (!player.TileReplacementEnabled)
                        {
                            continue;
                        }
                        var tile = Main.tile[x, y];
                        Main.NewText($"{tile.GetType()} , {PlaceItemType}");
                        if (!player.HasEnoughPickPowerToHurtTile(x, y))
                        {
                            continue;
                        }
                        if (WorldGen.ReplaceTile(x, y, (ushort)item.createTile, item.placeStyle))
                        {
                            consumeCount++;
                        }
                        // else // 无法替换，强行破坏后放置
                        // {
                        //     player.PickTile(x, y, 10000);
                        //     if (!Main.tile[x, y].HasTile && WorldGen.PlaceTile(x, y, (ushort)item.createTile, true, true, player.whoAmI, item.placeStyle))
                        //     {
                        //         consumeCount++;
                        //     }
                        // }
                    }
                    else
                    {
                        if (WorldGen.PlaceTile(x, y, (ushort)item.createTile, true, true, player.whoAmI, item.placeStyle))
                        {
                            consumeCount++;
                        }
                    }
                }
            }
            if (consumeCount > 0)
            {
                for (int i = 0; i < player.inventory.Length; i++)
                {
                    if (player.inventory[i].type == PlaceItemType)
                    {
                        if (player.inventory[i].stack > consumeCount)
                        {
                            player.inventory[i].stack -= consumeCount;
                            break;
                        }
                        else
                        {
                            consumeCount -= player.inventory[i].stack;
                            player.inventory[i].SetDefaults();
                        }
                    }
                }
            }
        }

        private void DrawRectangle(Player player)
        {
            if (!Main.dedServ && Main.myPlayer == player.whoAmI)
            {
                // 绘制矩形
                var begin = _beginPoint.ToVector2() * 16;
                var end = _endPoint.ToVector2() * 16;
                var width = end.X - begin.X;
                var height = end.Y - begin.Y;
                var rect = new Rectangle((int)begin.X, (int)begin.Y, (int)width, (int)height);
                // DrawRectangle(rect, Color.White);
            }
        }
                
    }
}