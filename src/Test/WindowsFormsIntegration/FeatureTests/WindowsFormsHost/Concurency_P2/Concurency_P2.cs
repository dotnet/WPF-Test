using System;
using WFCTestLib.Util;
using WFCTestLib.Log;
using ReflectTools;
using WPFReflectTools;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Forms.Integration;

using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using SWF = System.Windows.Forms;

//
// Testcase:    Concurency_P2
// Description: Verify that Binding works across windows
// Author:      a-wboyde
//
namespace WindowsFormsHostTests
{

public class Concurency_P2 : WPFReflectBase
{
    #region Testcase setup
    public Concurency_P2(string[] args) : base(args) { }

    // class vars
    // handles to WF controls on our main window
    private SWF.ListBox wflbProducts = null;
    private SWF.TextBox wftbProductName = null;
    private SWF.TextBox wftbUnitPrice = null;
    private SWF.TextBox wftbUnitPrice2 = null;

    // second window
    private SecondWindow secondWindow = null;

    // data-object
    public Products m_products;

    protected override void InitTest(TParams p)
    {
        base.InitTest(p);

        // force our window to top
        this.Topmost = true;
        this.Topmost = false;

        // create & set up our controls
        InitializeControls();

        // create & fill our data-objects
        InitializeData();

        // we must create a single Binding Source for all controls to use
        SWF.BindingSource bs = new System.Windows.Forms.BindingSource();
        bs.DataSource = m_products;

        // bind controls to our Data Binding
        wflbProducts.DataSource = bs;
        wflbProducts.DisplayMember = "ProductName";
        wftbProductName.DataBindings.Add("Text", bs, "ProductName");
        wftbUnitPrice.DataBindings.Add("Text", bs, "UnitPrice");
        wftbUnitPrice2.DataBindings.Add("Text", bs, "UnitPrice");

        // show the second window
        secondWindow = new SecondWindow(this);
        secondWindow.Show();
    }

    protected override void EndTest(TParams p)
    {
        // close second window
        secondWindow.Close();

        base.EndTest(p);
    }

    protected override bool BeforeScenario(TParams p, System.Reflection.MethodInfo scenario)
    {
        bool b = base.BeforeScenario(p, scenario);

        // debug - run specific scenario !!!
        //if (scenario.Name != "Scenario1") { return false; }
 
        return b;
    }

    #endregion

    #region Helper Functions

    // helper method that creates & sets up all our controls
    private void InitializeControls()
    {
        // resize window, move to upper left
        this.Left = 10;
        this.Top = 10;
        this.Width = 300;
        this.Height = 300;

        // create DockPanel, add to window
        DockPanel dp = new DockPanel();
        this.Content = dp;

        // create first WFH that will hold ListBox and TextBox (Current Product)
        WindowsFormsHost wfh1 = new WindowsFormsHost();
        DockPanel.SetDock(wfh1, Dock.Top);
        dp.Children.Add(wfh1);

        // Create a TableLayoutPanel that will host the WinForms data-controls ( 3 rows; one for a WinForm ListBox and two for WinForms TextBoxes )
        SWF.TableLayoutPanel wfControlsPanel = new SWF.TableLayoutPanel();
        wfControlsPanel.ColumnCount = 1;
        wfControlsPanel.ColumnStyles.Add(new SWF.ColumnStyle(SWF.SizeType.Percent, 100F));
        wfControlsPanel.Dock = SWF.DockStyle.Fill;
        wfControlsPanel.RowCount = 3;
        wfControlsPanel.RowStyles.Add(new SWF.RowStyle(SWF.SizeType.Percent, 100F));
        wfControlsPanel.RowStyles.Add(new SWF.RowStyle(SWF.SizeType.Absolute, 30F));
        wfControlsPanel.RowStyles.Add(new SWF.RowStyle(SWF.SizeType.Absolute, 30F));
        wfh1.Child = wfControlsPanel;

        // create the WinForms ListBox that will display product-names 
        wflbProducts = new SWF.ListBox();
        wflbProducts.Dock = SWF.DockStyle.Fill;
        wflbProducts.FormattingEnabled = true;
        wfControlsPanel.Controls.Add(wflbProducts);

        // create a TextBox that will display the Name for the current product (the one selected in the wflbProductNames listBox )
        wftbProductName = new SWF.TextBox();
        wftbProductName.Dock = SWF.DockStyle.Top;
        wfControlsPanel.Controls.Add(wftbProductName);

        // create a TextBox that will display the UnitPrice for the current product (the one selected in the wflbProductNames listBox )
        wftbUnitPrice = new SWF.TextBox();
        wftbUnitPrice.Dock = SWF.DockStyle.Bottom;
        wfControlsPanel.Controls.Add(wftbUnitPrice);

        // create second WFH that will contain 2nd TextBox (Unit Price)
        WindowsFormsHost wfh2 = new WindowsFormsHost();
        DockPanel.SetDock(wfh2, Dock.Bottom);
        dp.Children.Add(wfh2);

        // create a 2nd TextBox that will display the UnitPrice using a 2nd WFH
        wftbUnitPrice2 = new SWF.TextBox();
        wftbUnitPrice2.Dock = SWF.DockStyle.Bottom;
        wfh2.Child = wftbUnitPrice2;
    }

    // helper method that creates & sets up our data-objects
    private void InitializeData()
    {
        DataSet dsNorthwind = new DataSet();

        // create the connection-object
        // NOTE: This connection string used to have credentials, removed due to it triggering the credential scanning tool.
        string connectionString = "Data Source=wfsrv2;Initial Catalog=Northwind;";
        SqlConnection sqlConn = new SqlConnection(connectionString);

        // create the DataAdapter that we will use to fill the DataSet
        SqlDataAdapter adapter = new SqlDataAdapter();

        // Get the products
        adapter.SelectCommand = new SqlCommand("SELECT ProductID, CategoryID, ProductName, UnitPrice FROM Products WHERE UnitPrice > 20", sqlConn);
        adapter.Fill(dsNorthwind, "Products");

        // fill the list of products
        m_products = new Products();
        foreach (DataRow row in dsNorthwind.Tables["Products"].Rows)
        {
            Product product = new Product(row["ProductName"].ToString(), Convert.ToInt32(row["UnitPrice"]));
            m_products.Add(product);
        }
    }

    #endregion

    #region Second Window

    public class SecondWindow : Window
    {
        private Concurency_P2 m_parent = null;

        // controls
        private DockPanel dp = null;
        public ListView avlvProducts = null;
        public ComboBox avcbProducts = null;
        public TextBox avtbUnitPrice = null;

        public SecondWindow(Concurency_P2 parent)
        {
            m_parent = parent;
            this.Loaded += new RoutedEventHandler(SecondWindow_Loaded);
        }

        void SecondWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // create & set up our controls
            InitializeControls();

            // bind the data to the controls
            dp.DataContext = m_parent.m_products;
            avlvProducts.ItemsSource = m_parent.m_products;
            ((GridView)avlvProducts.View).Columns[0].DisplayMemberBinding = new System.Windows.Data.Binding("ProductName");
            ((GridView)avlvProducts.View).Columns[1].DisplayMemberBinding = new System.Windows.Data.Binding("UnitPrice");

            System.Windows.Data.BindingOperations.SetBinding(avtbUnitPrice,
                                                              TextBox.TextProperty,
                                                              new System.Windows.Data.Binding("UnitPrice"));

            avcbProducts.ItemsSource = m_parent.m_products;
            avcbProducts.DisplayMemberPath = "ProductName";
        }

        // helper method that creates & sets up our controls
        private void InitializeControls()
        {
            // resize window, set location so it is next to first window
            this.Top = m_parent.Top;
            this.Left = m_parent.ActualWidth + 20;
            this.Width = 300;
            this.Height = 300;

            // craete DockPanel, add to window
            dp = new DockPanel();
            this.Content = dp;

            // create the WPF TextBox that will display the UnitPrice for the current product
            avtbUnitPrice = new TextBox();
            DockPanel.SetDock(avtbUnitPrice, Dock.Bottom);
            dp.Children.Add(avtbUnitPrice);

            // create the WPF ComboBox that will contain all the ProductNames 
            avcbProducts = new ComboBox();
            avcbProducts.IsSynchronizedWithCurrentItem = true;
            DockPanel.SetDock(avcbProducts, Dock.Bottom);
            dp.Children.Add(avcbProducts);

            //create the WPF ListView that will display the ProductName - UnitPrice info
            GridViewColumn col1 = new GridViewColumn();
            col1.Header = "Product Name";
            GridViewColumn col2 = new GridViewColumn();
            col2.Header = "Unit Price";
            GridView view = new GridView();
            view.Columns.Add(col1);
            view.Columns.Add(col2);
            avlvProducts = new ListView();
            avlvProducts.IsSynchronizedWithCurrentItem = true;
            avlvProducts.View = view;
            avlvProducts.Margin = new Thickness(5, 5, 5, 5);
            DockPanel.SetDock(avlvProducts, Dock.Top);
            dp.Children.Add(avlvProducts);
        }
    }
    #endregion

    #region Data Stuff
    public class Product : INotifyPropertyChanged
    {
        private string m_productName = "";
        private int m_unitPrice = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public Product(string productName, int unitPrice)
        {
            this.m_productName = productName;
            this.m_unitPrice = unitPrice;
        }

        public string ProductName
        {
            get
            {
                return m_productName;
            }
            set
            {
                m_productName = value;
                OnPropertyChanged("ProductName");
            }
        }
        public int UnitPrice
        {
            get
            {
                return m_unitPrice;
            }
            set
            {
                m_unitPrice = value;
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
    #endregion

    //==========================================
    // Scenarios
    //==========================================
    #region Scenarios
    [Scenario("Verify that changing a bound value in an WF control is represented in an AV control on another window.")]
    public ScenarioResult Scenario1(TParams p)
    {
        ScenarioResult sr = new ScenarioResult();

        // iterate through all items in WF Listbox
        wflbProducts.Focus();
        for (int i = wflbProducts.Items.Count - 1; i >= 0; i--)
        {
            // Select the same row in the WPF ListView and WF ListBox;
            secondWindow.avlvProducts.Items.MoveCurrentToPosition(i);
            wflbProducts.SelectedIndex = i;
            WPFReflectBase.DoEvents();

            // change the price of the current product to a new value - use the WF TextBox to do this change
            int newPrice = Convert.ToInt32(wftbUnitPrice.Text) + 10;
            wftbUnitPrice.Focus();
            wftbUnitPrice.Text = newPrice.ToString();
            wflbProducts.Focus();

            if (newPrice != Convert.ToInt32(secondWindow.avtbUnitPrice.Text))
            {
                p.log.WriteLine("item={0} newPrice={1} actual={2}", m_products[i].ProductName, newPrice, secondWindow.avtbUnitPrice.Text);
            }

            // verify that the new value appears in the WPF text-box 
            WPFMiscUtils.IncCounters(sr, p.log,
                newPrice == Convert.ToInt32(secondWindow.avtbUnitPrice.Text),
                "The Price-change in WF Text-Box wasn't reflected in the WPF TextBox");

            // verify that the new value appears in the other WF text-box
            WPFMiscUtils.IncCounters(sr, p.log,
                newPrice == Convert.ToInt32(wftbUnitPrice2.Text),
                "The Price-change in WF Text-Box wasn't reflected in the other WF TextBox");

            // verify that the new-value appears into the data-obejct
            WPFMiscUtils.IncCounters(sr, p.log,
                newPrice == m_products[i].UnitPrice,
                "The Price-change in WF Text-Box wasn't reflected in the data-object");
        }

        return sr;
    }

    [Scenario("Verify that deleting a bound value in an WF control is represented in an AV control on another window.")]
    public ScenarioResult Scenario2(TParams p)
    {
        ScenarioResult sr = new ScenarioResult();

        // remember the second Product 
        Product secondProduct = wflbProducts.Items[1] as Product;

        // delete the first row from the data
        m_products.Remove(wflbProducts.Items[0] as Product);

        //Select the first row in the WPF ListView and WF ListBox;
        secondWindow.avlvProducts.Items.MoveCurrentToPosition(0);
        wflbProducts.SelectedIndex = 0;
        WPFReflectBase.DoEvents();

        // verify that all controls are updated to reflect the recent delete

        // check the WF controls (this is for Scenario 5)
        WPFMiscUtils.IncCounters(sr, p.log,
            secondProduct.ProductName == (wflbProducts.SelectedItem as Product).ProductName,
            "WF ListBox wasn't updated after the delete-operation");

        WPFMiscUtils.IncCounters(sr, p.log,
            secondProduct.ProductName == wftbProductName.Text,
            "WF TextBox wasn't updated after the delete-operation");

        WPFMiscUtils.IncCounters(sr, p.log,
            secondProduct.UnitPrice == Convert.ToInt32(wftbUnitPrice.Text),
            "WF TextBox wasn't updated after the delete-operation");

        WPFMiscUtils.IncCounters(sr, p.log,
            secondProduct.UnitPrice == Convert.ToInt32(wftbUnitPrice2.Text),
            "Second WF TextBox wasn't updated after the delete-operation");

        // check the WPF controls (this is for Scenario 2)
        WPFMiscUtils.IncCounters(sr, p.log,
            secondProduct.ProductName == (secondWindow.avlvProducts.SelectedItem as Product).ProductName,
            "WPF ListView wasn't updated after the delete-operation");

        WPFMiscUtils.IncCounters(sr, p.log,
            secondProduct.UnitPrice == Convert.ToInt32(secondWindow.avtbUnitPrice.Text),
            "WPF TextBox wasn't updated after the delete-operation");

        WPFMiscUtils.IncCounters(sr, p.log,
            secondProduct.ProductName == (secondWindow.avcbProducts.SelectedItem as Product).ProductName,
            "WPF ComboBox wasn't updated after the delete-operation");

        return sr;
    }

    [Scenario("Verify that adding a bound value in an WF control is represented in an AV control on another window.")]
    public ScenarioResult Scenario3(TParams p)
    {
        ScenarioResult sr = new ScenarioResult();

        // create a new Product
        Product newProduct = new Product("My New Product", 100);

        // add it into the data collection
        m_products.Add(newProduct);

        // Select the last row in the WPF ListView and WF ListBox (this should be the new item)
        secondWindow.avlvProducts.Items.MoveCurrentToPosition(secondWindow.avlvProducts.Items.Count - 1);
        wflbProducts.SelectedIndex = wflbProducts.Items.Count - 1;
        WPFReflectBase.DoEvents();

        // verify that all controls are updated to reflect the recent add

        // check the WF controls (this is for Scenario 6)
        WPFMiscUtils.IncCounters(sr, p.log,
            newProduct.ProductName == (wflbProducts.SelectedItem as Product).ProductName,
            "WF ListBox wasn't updated after the add-operation");

        WPFMiscUtils.IncCounters(sr, p.log,
            newProduct.ProductName == wftbProductName.Text,
            "WF TextBox wasn't updated after the add-operation");

        WPFMiscUtils.IncCounters(sr, p.log,
            newProduct.UnitPrice == Convert.ToInt32(wftbUnitPrice.Text),
            "WF TextBox wasn't updated after the add-operation");

        WPFMiscUtils.IncCounters(sr, p.log,
            newProduct.UnitPrice == Convert.ToInt32(wftbUnitPrice2.Text),
            "Second WF TextBox wasn't updated after the add-operation");

        // check the WPF controls (this is for Scenario 3)
        WPFMiscUtils.IncCounters(sr, p.log,
            newProduct.ProductName == (secondWindow.avlvProducts.SelectedItem as Product).ProductName,
            "WPF ListView wasn't updated after the add-operation");

        WPFMiscUtils.IncCounters(sr, p.log,
            newProduct.UnitPrice == Convert.ToInt32(secondWindow.avtbUnitPrice.Text),
            "WPF TextBox wasn't updated after the add-operation");

        WPFMiscUtils.IncCounters(sr, p.log,
            newProduct.ProductName == (secondWindow.avcbProducts.SelectedItem as Product).ProductName,
            "WPF ComboBox wasn't updated after the add-operation");

        return sr;
    }

    [Scenario("Verify that changing a bound value in an AV control is represented in an WF control on another window.")]
    public ScenarioResult Scenario4(TParams p)
    {
        ScenarioResult sr = new ScenarioResult();

        // iterate through all items in WPF Listbox
        for (int i = 0; i < secondWindow.avlvProducts.Items.Count; i++)
        {
            // Select the same row in the WPF ListView and WF ListBox;
            secondWindow.avlvProducts.Items.MoveCurrentToPosition(i);
            wflbProducts.SelectedIndex = i;
            WPFReflectBase.DoEvents();

            // change the price of the current product to a new value - use the WPF TextBox to do this change
            int newPrice = Convert.ToInt32(secondWindow.avtbUnitPrice.Text) + 10;
            secondWindow.avtbUnitPrice.Focus();
            secondWindow.avtbUnitPrice.Text = newPrice.ToString();
            secondWindow.avlvProducts.Focus();

            // verify that the new value appears in the WF text-box
            WPFMiscUtils.IncCounters(sr, p.log,
                newPrice == Convert.ToInt32(wftbUnitPrice.Text),
                "The Price-change in WPF Text-Box wasn't reflected in the WF TextBox");

            // verify that the new value appears in the other WF text-box
            WPFMiscUtils.IncCounters(sr, p.log,
                newPrice == Convert.ToInt32(wftbUnitPrice2.Text),
                "The Price-change in WPF Text-Box wasn't reflected in the other WF TextBox");

            // verify that the new-value appears into the data-obejct
            WPFMiscUtils.IncCounters(sr, p.log,
                newPrice == m_products[i].UnitPrice,
                "The Price-change in WPF Text-Box wasn't reflected in the data-object");
        }

        return sr;
    }

    [Scenario("Verify that deleting a bound value in an AV control is represented in an WF control on another window.")]
    public ScenarioResult Scenario5(TParams p)
    {
        // this is performed as part of Scenario 2
        return new ScenarioResult(true);
    }

    [Scenario("Verify that adding a bound value in an AV control is represented in an WF control on another window.")]
    public ScenarioResult Scenario6(TParams p)
    {
        // this is performed as part of Scenario 3
        return new ScenarioResult(true);
    }

    #endregion
}
}

// Keep these in sync by running the testcase locally through the driver whenever
// you add, remove, or rename scenarios.
//
// [Scenarios]
//@ Verify that changing a bound value in an WF control is represented in an AV control on another window.

//@ Verify that deleting a bound value in an WF control is represented in an AV control on another window.

//@ Verify that adding a bound value in an WF control is represented in an AV control on another window.

//@ Verify that changing a bound value in an AV control is represented in an WF control on another window.

//@ Verify that deleting a bound value in an AV control is represented in an WF control on another window.

//@ Verify that adding a bound value in an AV control is represented in an WF control on another window.
