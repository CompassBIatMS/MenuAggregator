using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MenuAggregator.Classes
{
    public class NewGroupBox : GroupBox
    {
        private int _isChanged;
        private ComboBox _menuCb;
        private ComboBox _priceCb;
        private TextBox _textBox;

        public int IsChanged
        {
            get
            {
                return _isChanged;
            }
            set
            {
                _isChanged = value;
            }
        }
       
        public NewGroupBox()
        {
            IsChanged = _isChanged;
        }

        public int GetIsChanged()
        {
            return IsChanged;
        }
    }
}
