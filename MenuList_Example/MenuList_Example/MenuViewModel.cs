using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MenuList_Example
{
    public class MenuViewModel
    {
        private MenuItemModel _selectedItem;


        public List<MenuItemModel> MenuItems { get; private set; }

        public Command<MenuItemModel> MenuItemSelectedCommand
        { 
            get 
            {
                return new Command<MenuItemModel>((i) => 
                {
                    if (this._selectedItem != null)
                    {
                        this._selectedItem.IsSelected = false;
                    }
                    i.IsSelected = true;
                    this._selectedItem = i;
                }, i => !i.IsSelected);
            }
        }

        public MenuViewModel()
        {
            this._selectedItem = null;
            this.MenuItems = new List<MenuItemModel>();

            MenuItems.Add(new MenuItemModel
            {
                Text = "Home"
            });

            MenuItems.Add(new MenuItemModel
            {
                Text = "My Orders"
            });

            MenuItems.Add(new MenuItemModel
            {
                Text = "Parameters"
            });

            MenuItems.Add(new MenuItemModel
            {
                Text = "Help"
            });

            MenuItems.Add(new MenuItemModel
            {
                Text = "Contact us"
            });

        }
    }

    public class MenuItemModel : INotifyPropertyChanged
    {
        private string _text;
        private bool _isSelected;
        

        public event PropertyChangedEventHandler PropertyChanged;

        public string Text 
        {
            get
            {
                return this._text;
            }
            set
            {
                if (this._text != value)
                {
                    this._text = value;
                    this.OnPropertyChanged("Text");
                }
            }
        }
        public bool IsSelected
        {
            get
            {
                return this._isSelected;
            }
            set
            {
                if (this._isSelected != value)
                {
                    this._isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                    this.OnPropertyChanged("BackgroundColor");
                    this.OnPropertyChanged("TextColor");
                }
            }
        }
        public Color BackgroundColor
        {
            get
            {
                if (this._isSelected)
                {
                    return Color.Red;
                }
                return Color.Transparent;
            }
        }
        public Color TextColor
        {
            get
            {
                if (this._isSelected)
                {
                    return Color.White;
                }
                return Color.Aqua;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var ev = this.PropertyChanged;

            if (ev != null)
            {
                ev(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
