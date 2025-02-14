// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Windows.Forms;

using WFCTestLib.Util;
using WFCTestLib.Log;
using ReflectTools;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms.Integration;
using System.Windows.Data;
using System.ComponentModel;

//
// Testcase:    Concurency_P2
// Description: Verify that Binding works across windows.
//
public class Concurency_P2 : ReflectBase
{
    //controls
    private ListBox _wflbProducts = null;
    private TextBox _wftbProductName = null;
    private TextBox _wftbUnitPrice = null;
    private SecondForm _secondForm = null;

    //data-object
    public Products m_products;
    
    #region Testcase setup
    
    public Concurency_P2(string[] args) : base(args) 
    { 
    }

    protected override void InitTest(TParams p)
    {
        //create & set the needed controls
        InitializeControls();

        //create & fill the needed data-objects
        InitializeData();

        //bind the controls 
        _wflbProducts.DataSource = m_products;
        _wflbProducts.DisplayMember = "ProductName";

        _wftbProductName.DataBindings.Add("Text", m_products, "ProductName");
        _wftbUnitPrice.DataBindings.Add("Text", m_products, "UnitPrice");

        //show the secondForm 
        _secondForm = new SecondForm(this);
        _secondForm.Show();

        base.InitTest(p);
    }

    protected override void EndTest(TParams p)
    {
        _secondForm.Close();
        base.EndTest(p);
    }

    #endregion

    //==========================================
    // Scenarios
    //==========================================
    #region Scenarios
    [Scenario("Verify that changing a bound value in a simple Avalon control is represented in an WF control on another window")]
    public ScenarioResult Scenario1(TParams p)
    {
        ScenarioResult sr = new ScenarioResult(true);

        for (int i = 0; i < _secondForm.avlvProducts.Items.Count; i++)
        {
            //Select the same row in the WPF ListView and WF ListBox;
            _secondForm.avlvProducts.Items.MoveCurrentToPosition(i);
            _wflbProducts.SelectedIndex = i;
            Application.DoEvents();

            //change the price of the current product to a new value - use the WPF TextBox to do this change
            int newPrice = Convert.ToInt32(_secondForm.avtbUnitPrice.Text) + 10;
            _secondForm.avtbUnitPrice.Focus();
            _secondForm.avtbUnitPrice.Text = newPrice.ToString();
            _secondForm.avlvProducts.Focus();

            //verify that the new value appears in the WF text-box 
            sr.IncCounters( newPrice == Convert.ToInt32(_wftbUnitPrice.Text),
                            "The Price-change in WPF Text-Box wasn't reflected in the WF TextBox",
                            p.log);

            //verify that the new-value appears into the data-obejct
            sr.IncCounters(newPrice == m_products[i].UnitPrice,
                            "The Price-change in WPF Text-Box wasn't reflected in the data-object",
                            p.log);
        }
        return sr;
    }

    [Scenario("Verify that changing a bound value in an WF control is represented in an Avalon control on another window")]
    public ScenarioResult Scenario2(TParams p)
    {
        ScenarioResult sr = new ScenarioResult(true);

        for (int i = _wflbProducts.Items.Count - 1; i >= 0; i--)
        {
            //Select the same row in the WPF ListView and WF ListBox;
            _secondForm.avlvProducts.Items.MoveCurrentToPosition(i);
            _wflbProducts.SelectedIndex = i;
            Application.DoEvents();

            //change the price of the current product to a new value - use the WF TextBox to do this change
            int newPrice = Convert.ToInt32(_wftbUnitPrice.Text) + 10;
            _wftbUnitPrice.Focus();
            _wftbUnitPrice.Text = newPrice.ToString();
            _wflbProducts.Focus();

            //verify that the new value appears in the WF text-box 
            sr.IncCounters(newPrice == Convert.ToInt32(_secondForm.avtbUnitPrice.Text),
                            "The Price-change in WPF Text-Box wasn't reflected in the WF TextBox",
                            p.log);

            //verify that the new-value appears into the data-obejct
            sr.IncCounters(newPrice == m_products[i].UnitPrice,
                            "The Price-change in WPF Text-Box wasn't reflected in the data-object",
                            p.log);
        }

        return sr;
    }

    [Scenario("Vefify that deleting a bound value from a list is represented in an Avalon control and in a WF control in different forms.")]
    public ScenarioResult Scenario3(TParams p)
    {
        ScenarioResult sr = new ScenarioResult(true);

        //remember the second Product 
        Product secondProduct = _wflbProducts.Items[1] as Product;

        //delete the first row
        m_products.Remove( _wflbProducts.Items[0] as Product );

        //Select the first row in the WPF ListView and WF ListBox;
        _secondForm.avlvProducts.Items.MoveCurrentToPosition(0);
        _wflbProducts.SelectedIndex = 0;
        Application.DoEvents(); 
        
        //verify that the all controls are updated to reflect the recent delete.
        sr.IncCounters( secondProduct.ProductName == (_wflbProducts.SelectedItem as Product).ProductName,
                        "WF ListBox wasn't updated after the delete-operation",
                        p.log);

        sr.IncCounters( secondProduct.ProductName == _wftbProductName.Text,
                        "WF TextBox wasn't updated after the delete-operation",
                        p.log);

        sr.IncCounters( secondProduct.UnitPrice == Convert.ToInt32(_wftbUnitPrice.Text),
                        "WF TextBox wasn't updated after the delete-operation",
                        p.log);

        sr.IncCounters( secondProduct.ProductName == (_secondForm.avlvProducts.SelectedItem as Product).ProductName,
                        "WPF ListView wasn't updated after the delete-operation",
                        p.log);

        sr.IncCounters( secondProduct.UnitPrice == Convert.ToInt32(_secondForm.avtbUnitPrice.Text),
                        "WPF TextBox wasn't updated after the delete-operation",
                        p.log);

        sr.IncCounters( secondProduct.ProductName == (_secondForm.avcbProducts.SelectedItem as Product).ProductName,
                        "WPF ComboBox wasn't updated after the delete-operation",
                        p.log);
   
        return sr;
    }

    [Scenario("Verify that adding a bound value in an Avalon control is represented in an WF control on another window")]
    public ScenarioResult Scenario4(TParams p)
    {
        ScenarioResult sr = new ScenarioResult(true);

        //create a new Product.
        Product newProduct = new Product("NewProduct", 1);

        //add-it into the collection
        m_products.Add( newProduct );

        //Select the last row in the WPF ListView and WF ListBox;
        _secondForm.avlvProducts.Items.MoveCurrentToPosition(_secondForm.avlvProducts.Items.Count - 1);
        _wflbProducts.SelectedIndex = _wflbProducts.Items.Count - 1;
        Application.DoEvents(); 

        //verify that all controls are updated to reflect the recent add.
        sr.IncCounters( newProduct.ProductName == (_wflbProducts.SelectedItem as Product).ProductName,
                        "WF ListBox wasn't updated after the add-operation",
                        p.log);

        sr.IncCounters( newProduct.ProductName == _wftbProductName.Text,
                        "WF TextBox wasn't updated after the add-operation",
                        p.log);

        sr.IncCounters( newProduct.UnitPrice == Convert.ToInt32(_wftbUnitPrice.Text),
                        "WF TextBox wasn't updated after the add-operation",
                        p.log);

        sr.IncCounters( newProduct.ProductName == (_secondForm.avlvProducts.SelectedItem as Product).ProductName,
                        "WPF ListView wasn't updated after the add-operation",
                        p.log);

        sr.IncCounters( newProduct.UnitPrice == Convert.ToInt32(_secondForm.avtbUnitPrice.Text),
                        "WPF TextBox wasn't updated after the add-operation",
                        p.log);

        sr.IncCounters( newProduct.ProductName == (_secondForm.avcbProducts.SelectedItem as Product).ProductName,
                        "WPF ComboBox wasn't updated after the add-operation",
                        p.log);

        return sr;
    }

    #endregion

    #region Helper Functions

    //helper method that creates & sets all the needed controls
    private void InitializeControls()
    {
        this.Location = new System.Drawing.Point(0, 0);

        //Create the TableLayoutPanel that will host the WinForms data-controls ( 3 rows; one for a WinForm ListBox and two for WinForms TextBoxes )
        TableLayoutPanel wfControlsPanel = new TableLayoutPanel();
        wfControlsPanel.ColumnCount = 1;
        wfControlsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        wfControlsPanel.Dock = DockStyle.Fill;
        wfControlsPanel.RowCount = 3;
        wfControlsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        wfControlsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        wfControlsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        this.Controls.Add(wfControlsPanel);

        //create the WinForms ListBox that will display product-names 
        _wflbProducts = new ListBox();
        _wflbProducts.Dock = DockStyle.Fill;
        _wflbProducts.FormattingEnabled = true;
        wfControlsPanel.Controls.Add(_wflbProducts, 0, 0);

        //create a TextBox that will display the Name for the current product (the one selected in the wflbProductNames listBox )
        _wftbProductName = new TextBox();
        _wftbProductName.Dock = DockStyle.Top;
        wfControlsPanel.Controls.Add(_wftbProductName, 0, 1);

        //create a TextBox that will display the UnitPrice for the current product (the one selected in the wflbProductNames listBox )
        _wftbUnitPrice = new TextBox();
        _wftbUnitPrice.Dock = DockStyle.Bottom;
        wfControlsPanel.Controls.Add(_wftbUnitPrice, 0, 2);
    }

    //helper method that creates & sets all the needed data-objects;
    private void InitializeData()
    {
        DataSet dsNorthwind = new DataSet();

        //create the connection-object
        // NOTE: This connection string used to have credentials, removed due to it triggering the credential scanning tool.
        string connectionString = "Data Source=wfsrv2;Initial Catalog=Northwind;";
        SqlConnection sqlConn = new SqlConnection(connectionString);

        //create the dataAdapter that will use to fill the dataSet
        SqlDataAdapter adapter = new SqlDataAdapter();

        //Get the products
        adapter.SelectCommand = new SqlCommand("SELECT ProductID, CategoryID, ProductName, UnitPrice FROM Products WHERE UnitPrice > 20", sqlConn);
        adapter.Fill(dsNorthwind, "Products");
        
        //fill the list of products
        m_products = new Products();
        foreach (DataRow row in dsNorthwind.Tables["Products"].Rows)
        {
            Product product = new Product( row["ProductName"].ToString(), Convert.ToInt32(row["UnitPrice"]) );
            m_products.Add( product );
        }
    }

    #endregion



public class Product : INotifyPropertyChanged
{
    private string _productName = "";
    private int _unitPrice = 0;

    public event PropertyChangedEventHandler PropertyChanged;

    public Product(string productName, int unitPrice)
    {
        this._productName = productName;
        this._unitPrice = unitPrice;
    }

    public string ProductName
    {
        get
        {
            return _productName;
        }
        set
        {
            _productName = value;
            OnPropertyChanged("ProductName");
        }
    }
    public int UnitPrice
    {
        get
        {
            return _unitPrice;
        }
        set
        {
            _unitPrice = value;
            OnPropertyChanged("UnitPrice");
        }
    }

    protected void OnPropertyChanged(string propName)
    {
        if (this.PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
public class Products : BindingList<Product>
{
}

}

public class SecondForm : Form
{
    private Concurency_P2 _parent = null;

    //controls
    private System.Windows.Controls.Grid _avGrid = null;
    public System.Windows.Controls.ComboBox avcbProducts = null;
    public System.Windows.Controls.ListView avlvProducts = null;
    public System.Windows.Controls.TextBox avtbUnitPrice = null;

    public SecondForm(Concurency_P2 parent)
    {
        _parent = parent;
        this.Load += new EventHandler(SecondForm_Load);
    }

    void SecondForm_Load(object sender, EventArgs e)
    {
        //create & set the needed controls
        InitializeControls();

        //bind the controls
        _avGrid.DataContext = _parent.m_products;
        avlvProducts.ItemsSource = _parent.m_products;
        ((System.Windows.Controls.GridView)avlvProducts.View).Columns[0].DisplayMemberBinding = new System.Windows.Data.Binding("ProductName");
        ((System.Windows.Controls.GridView)avlvProducts.View).Columns[1].DisplayMemberBinding = new System.Windows.Data.Binding("UnitPrice");

        System.Windows.Data.BindingOperations.SetBinding(avtbUnitPrice,
                                                          System.Windows.Controls.TextBox.TextProperty,
                                                          new System.Windows.Data.Binding("UnitPrice"));

        avcbProducts.ItemsSource = _parent.m_products;
        avcbProducts.DisplayMemberPath = "ProductName";
    }

    //helper method that creates & sets all the needed controls
    private void InitializeControls()
    {
        this.Location = new System.Drawing.Point(_parent.Location.X + _parent.Width + 5, 0);

        //Create the TableLayoutPanel for element-hosts ( with 2 rows; will put 2 element-hosts in these rows )
        TableLayoutPanel elementHostPanel = new TableLayoutPanel();
        elementHostPanel.ColumnCount = 1;
        elementHostPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        elementHostPanel.Dock = DockStyle.Fill;
        elementHostPanel.RowCount = 2;
        elementHostPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        elementHostPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        this.Controls.Add(elementHostPanel);

        //create the first elementHost - it will host an WPF grid with 2 controls; a list box and a textbox
        ElementHost ehFirst = new ElementHost();
        ehFirst.Dock = DockStyle.Fill;
        elementHostPanel.Controls.Add(ehFirst, 0, 0);

        //create the second elementHost - it will host an WPF combobox
        ElementHost ehSecond = new ElementHost();
        ehSecond.Dock = DockStyle.Fill;
        elementHostPanel.Controls.Add(ehSecond, 0, 1);

        //create the WPF Grid that will be hosted by the ehFirst and that will contain a ListBox and a TextBox
        _avGrid = new System.Windows.Controls.Grid();
        _avGrid.RowDefinitions.Add(new System.Windows.Controls.RowDefinition());
        _avGrid.RowDefinitions.Add(new System.Windows.Controls.RowDefinition());
        _avGrid.RowDefinitions[1].Height = new System.Windows.GridLength(20, System.Windows.GridUnitType.Pixel);
        ehFirst.Child = _avGrid;

        //create the WPF ComboBox that will be hosted by the ehSecond - this combo will contain all the ProductNames 
        avcbProducts = new System.Windows.Controls.ComboBox();
        avcbProducts.IsSynchronizedWithCurrentItem = true;
        ehSecond.Child = avcbProducts;

        //create the WPF ListView that will display the ProductName - UnitPrice info
        System.Windows.Controls.GridViewColumn col1 = new System.Windows.Controls.GridViewColumn();
        col1.Header = "Product Name";
        System.Windows.Controls.GridViewColumn col2 = new System.Windows.Controls.GridViewColumn();
        col2.Header = "Unit Price";
        System.Windows.Controls.GridView view = new System.Windows.Controls.GridView();
        view.Columns.Add(col1);
        view.Columns.Add(col2);
        avlvProducts = new System.Windows.Controls.ListView();
        avlvProducts.IsSynchronizedWithCurrentItem = true;
        avlvProducts.View = view;
        avlvProducts.Margin = new System.Windows.Thickness(5, 5, 5, 5);
        System.Windows.Controls.Grid.SetColumn(avlvProducts, 0);
        System.Windows.Controls.Grid.SetRow(avlvProducts, 0);
        _avGrid.Children.Add(avlvProducts);

        //create the WPF TextBox that will display the UnitPrice for the current product
        avtbUnitPrice = new System.Windows.Controls.TextBox();
        System.Windows.Controls.Grid.SetRow(avtbUnitPrice, 1);
        System.Windows.Controls.Grid.SetColumn(avtbUnitPrice, 0);
        _avGrid.Children.Add(avtbUnitPrice);
    }
}


// Keep these in sync by running the testcase locally through the driver whenever
// you add, remove, or rename scenarios.
//
// [Scenarios]
//@ Verify that changing a bound value in a simple Avalon control is represented in an WF control on another window
//@ Verify that changing a bound value in an WF control is represented in an Avalon control on another window
//@ Vefify that deleting a bound value from a list is represented in an Avalon control and in a WF control in different forms.
//@ Verify that adding a bound value in an Avalon control is represented in an WF control on another window
