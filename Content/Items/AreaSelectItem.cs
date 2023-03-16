using EasyBuildMod.Common.Systems;
using Terraria.GameContent.Creative;
using System;
using EasyBuildMod.Content.UI;


namespace EasyBuildMod.Content.Items
{
    /// <summary>
    /// 左键可选择区域、右键可打开菜单的物品
    /// </summary>
    public abstract class AreaSelectItem : ModItem
    {
        // 自身所携带的item的类型
        public int ContentItemType;

        // 选择区域的起点和终点
        protected Point _beginPoint;
        protected Point _endPoint;

        // 是否开始选择区域
        protected bool _startSelecting;

        // 菜单UI的静态实例
        protected MenuUI _menuUI;

        public override void SetStaticDefaults()
        {
            // 研究需要的物品数量为1
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
            ContentItemType = 0;
            _startSelecting = false;
        }

        public override bool AltFunctionUse(Player player) => true;

        protected virtual bool useItemCondition(Player player) => true;

        public override bool CanUseItem(Player player)
        {
            UISystem.CurrentMenuUI = _menuUI;
            if (player.noBuilding)
            {
                return false;
            }
            if (player.altFunctionUse == 2)
            {
                if (_menuUI.Visible)
                {
                    _menuUI.Close();
                }
                else
                {
                    _menuUI.Open(this);
                }
                return false;
            }
            if (!useItemCondition(player))
            {
                return false;
            }
            if (!_startSelecting)
            {
                _beginPoint = Main.MouseWorld.ToTileCoordinates();
                _startSelecting = true;
            }
            return true;
        }
        
        public override bool? UseItem(Player player)
        {
            _endPoint = Main.MouseWorld.ToTileCoordinates();
            if (!Main.mouseLeft)
            {
                // 鼠标左键松开
                HandleMouseUp();
                return true;
            }
            if (Main.mouseRight && _startSelecting)
            {
                // 鼠标右键按下
                StopUse();
            }
            else
            {
                DrawingSystem.StartDraw(GetRectangle(_beginPoint, _endPoint));
            }
            return base.UseItem(player);
        }

        public virtual void StopUse()
        {
            DrawingSystem.StopDraw();
            _startSelecting = false;
        }

        public void HandleMouseUp()
        {
            if (_startSelecting)
            {
                StartAction(Main.LocalPlayer);
                StopUse();
            }
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

        public Rectangle GetRectangle(Point begin, Point end)
        {
            var beginVector = begin.ToVector2();
            var endVector = end.ToVector2();
            int startX = Math.Min((int)beginVector.X, (int)endVector.X);
            int startY = Math.Min((int)beginVector.Y, (int)endVector.Y);
            int endX = Math.Max((int)beginVector.X, (int)endVector.X);
            int endY = Math.Max((int)beginVector.Y, (int)endVector.Y);
            return new Rectangle(startX, startY, endX - startX, endY - startY);
        }

        protected virtual void StartAction(Player player)
        {
        }
                
    }
}