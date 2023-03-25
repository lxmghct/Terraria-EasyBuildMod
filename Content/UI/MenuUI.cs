using EasyBuildMod.Content.Items;

namespace EasyBuildMod.Content.UI
{
    /// <summary>
    /// 用于显示菜单的UI
    /// </summary>
    public abstract class MenuUI : UIState
    {
        // 调出菜单的物品
        internal AreaSelectItem AreaSelectItem;

        // 菜单的容器
        protected UIElement MainContainer;

        // 菜单是否可见
        public bool Visible;

        public override void OnInitialize()
        {
            base.OnInitialize();
            Append(MainContainer = new ());
            MainContainer.Width.Set(200, 0);
            MainContainer.Height.Set(200, 0);
        }

        public virtual void Init()
        {
            Visible = false;
        }

        public virtual void Open(AreaSelectItem item)
        {
            this.AreaSelectItem = item;
            Visible = true;
            // 注意要除以UIScale，否则如果缩放比例不是100%就会错位
            MainContainer.Left.Set(Main.mouseX / Main.UIScale - MainContainer.Width.Pixels / 2, 0);
            MainContainer.Top.Set(Main.mouseY / Main.UIScale - MainContainer.Height.Pixels / 2, 0);
        }

        public virtual void Close()
        {
            Visible = false;
        }

        public virtual void Hide()
        {
            Visible = false;
            AreaSelectItem?.StopUse();
        }

    }
    
}