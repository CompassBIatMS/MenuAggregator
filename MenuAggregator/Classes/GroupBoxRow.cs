using System;
using System.Collections.Generic;
using System.Data;
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
        private ComboBox _menucb = new ComboBox();
        private ComboBox _pricecb = new ComboBox();
        private TextBox _textbox = new TextBox();
        MenuBuilderDataSet ds = new MenuBuilderDataSet();
        MenuBuilderDataSetTableAdapters.MenuBuilder_PriceTableAdapter priceAdapter = new MenuBuilderDataSetTableAdapters.MenuBuilder_PriceTableAdapter();
        MenuBuilderDataSetTableAdapters.MenuBuilder_SubMenusTableAdapter subMenuAdapter = new MenuBuilderDataSetTableAdapters.MenuBuilder_SubMenusTableAdapter();


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

        public ComboBox MenuCb
        { get
            {
                return _menucb;
            }
              set
            {
                _menucb = value;
            }
        }

        public ComboBox PriceCb
        {
            get
            {
                return _pricecb;
            }
            set
            {
                _pricecb = value;
            }
        }

        public TextBox Text
        {
            get
            {
                return _textbox;
            }
            set
            {
                _textbox = value;
            }
        }

        //public ComboBox PriceCb { get; set; }
        //public TextBox Text { get; set; }

        public GroupBoxRow(NewGroupBox box, int gridRowCount, int j, int gridRow, int c, int? bid)
        {

            priceAdapter.Fill(ds._MenuBuilder_Price);
            DataTable priceTable = ds._MenuBuilder_Price as DataTable;

            //create a table that only fills with menu items associated with the button pressed
            DataTable subMenuTable = ds._MenuBuilder_SubMenus as DataTable;
            subMenuAdapter.FillByConceptId(ds._MenuBuilder_SubMenus, bid);
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
                //RowDefinition row1 = new RowDefinition();
                //row1.Height = new GridLength(40);
                //RowDefinition row2 = new RowDefinition();
                //row2.Height = new GridLength(40);


                //grid.RowDefinitions.Add(row1);
                //grid.RowDefinitions.Add(row2);

            }
            else if (gridRowCount == 2)
            {
                box.Height = 130;
                //RowDefinition row1 = new RowDefinition();
                //row1.Height = new GridLength(40);

                //grid.RowDefinitions.Add(row1);
            }
            else
            {
                box.Height = 80;
            }

            for (int i = 0; i <= gridRowCount-1; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(40);
                grid.RowDefinitions.Add(row);
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

            foreach (DataRow row in subMenuTable.Rows)
            {
               MenuCb.Items.Add(row[1]);
                //menucb.Items.Add(row[1]);
            }
            MenuCb.Items.Add("PROMO");
           MenuCb.Items.Add("Station Closed");

            //add price text from price table to combobox
            foreach (DataRow row in priceTable.Rows)
            {
                PriceCb.Items.Add(row[1]);
            }

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
