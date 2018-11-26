using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MenuAggregator.Classes
{
    public class GroupBoxRow 
    {
        private int _isChanged;
        private ComboBox _pricecb;
        private TextBox _textbox;

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

        public ComboBox MenuCb { get; set; }
        public ComboBox PriceCb { get; set; }
        public TextBox Text { get; set; }
       
        public GroupBoxRow(NewGroupBox box, int gridRowCount, int j, int gridRow, int c)
        {
            IsChanged = _isChanged;
            Grid grid = new Grid();
            ColumnDefinition column1 = new ColumnDefinition();
            column1.Width = new GridLength(235);
            ColumnDefinition column2 = new ColumnDefinition();
            column2.Width = new GridLength(95);
            ColumnDefinition column3 = new ColumnDefinition();

            grid.ColumnDefinitions.Add(column1);
            grid.ColumnDefinitions.Add(column2);
            grid.ColumnDefinitions.Add(column3);

            //int gridRow = 0;
            

                if (gridRowCount == 3)
                {
                    box.Height = 160;
                    RowDefinition row1 = new RowDefinition();
                    row1.Height = new GridLength(40);
                    //RowDefinition row2 = new RowDefinition();
                    //row2.Height = new GridLength(40);


                    grid.RowDefinitions.Add(row1);
                    //grid.RowDefinitions.Add(row2);

                }
                else if (gridRowCount == 2)
                {
                    box.Height = 130;
                    RowDefinition row1 = new RowDefinition();
                    row1.Height = new GridLength(40);

                    grid.RowDefinitions.Add(row1);
                }
                else
                {
                    box.Height = 80;
                }

            //ComboBox menucb = new ComboBox();
            MenuCb.Width = 230;
            MenuCb.FontSize = 16;
            MenuCb.Height = 30;
            MenuCb.Tag = "MenuCb" + j + gridRow + 0;

            //ComboBox pricecb = new ComboBox();
            PriceCb.Width = 90;
            PriceCb.FontSize = 16;
            PriceCb.Height = 30;
            PriceCb.Tag = "PriceCb" + j + gridRow + 1;

            //TextBox text = new TextBox();
            Text.FontSize = 16;
            Text.Height = 30;
            Text.Text = null;
            Text.Tag = "TextBox" + j + gridRow + 2; //tag is set to iterator for accessing later

            Grid.SetColumn(MenuCb, 0);
            Grid.SetRow(MenuCb, c);
            grid.Children.Add(MenuCb);

            Grid.SetColumn(PriceCb, 1);
            Grid.SetRow(PriceCb, c);
            grid.Children.Add(PriceCb);

            Grid.SetColumn(Text, 2);
            Grid.SetRow(Text, c);
            grid.Children.Add(Text);

        }
    }
}
