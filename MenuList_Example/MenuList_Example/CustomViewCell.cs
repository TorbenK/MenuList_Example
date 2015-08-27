using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MenuList_Example
{
    public class CustomViewCell : ViewCell
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create<CustomViewCell, Command>(i => i.Command, default(Command), BindingMode.OneWay);
        public Command Command
        {
            get
            {
                return (Command)this.GetValue(CommandProperty);
            }
            set
            {
                this.SetValue(CommandProperty, value);
            }
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create<CustomViewCell, object>(i => i.CommandParameter, default(object), BindingMode.OneWay);
        public object CommandParameter
        {
            get
            {
                return this.GetValue(CommandParameterProperty);
            }
            set
            {
                this.SetValue(CommandParameterProperty, value);
            }
        }

        protected override void OnTapped()
        {
            base.OnTapped();

            if (this.Command != null)
            {
                if (this.Command.CanExecute(this.CommandParameter))
                {
                    this.Command.Execute(this.CommandParameter ?? this);
                }
            }
        }
    }
}
