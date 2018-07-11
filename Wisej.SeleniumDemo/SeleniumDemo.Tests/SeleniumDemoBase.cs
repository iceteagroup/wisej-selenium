using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using Wisej.Web.Ext.Selenium;
using Wisej.Web.Ext.Selenium.Tests;
using Wisej.Web.Ext.Selenium.UI;
using Wisej.Web.Ext.Selenium.UI.List;
using QxLabel = Qooxdoo.WebDriver.UI.Basic.Label;

namespace SeleniumDemo.Tests
{
    [TestFixture]
    [NonParallelizable]
    public abstract partial class SeleniumDemoBase
    {
        protected static SeleniumDemoWebDriver TestDriver;
        protected static Browser CurrentBrowser;

        [Test, Order(010)]
        public void W010_AskQuitNo()
        {
            // get MainPage and check it's visible
            Page mainPage = TestDriver.WidgetGet<Page>("MainPage");

            // click exit on MainPage
            mainPage.ButtonClick("exit");

            var title = "Exit Application";
            var message = "Do you want to exit now?";
            var icon = MessageBoxIcon.Question;

            // get MessageBox using all parameters check it's enabled
            MessageBox messageBox = TestDriver.GetMessageBox(title, icon, message);

            // click "No"
            messageBox.ButtonClick(DialogResult.No);

            // check messageBox doesn't exist
            TestDriver.MessageBoxCheckNotExists(title, icon, message);
        }

        [Test, Order(020)]
        public void W020_HelperWindow_Click()
        {
            // get MainPage and check it's visible
            Page mainPage = TestDriver.WidgetGet<Page>("MainPage");

            // click helper on MainPage
            mainPage.ButtonClick("helper");

            // check HelperWindow exists and is visible
            Form helperWindow = TestDriver.WidgetGet<Form>("HelperWindow");
        }

        // no need to reset data for now
        /*[Test, Order(025)]
        public void W025_HelperWindow_HelperWindow_ResetData_Click()
        {
            // get HelperWindow exists and is visible
            Form helperWindow = TestDriver.WidgetGet<Form>("HelperWindow");

            // click resetData on HelperWindow
            helperWindow.ButtonClick("resetData");
        }*/

        [Test, Order(030)]
        public void W030_HelperWindow_Minimize()
        {
            // give enough time so YOU can follow the window minimizing
            TestDriver.Sleep(Waiter.Duration);

            // get HelperWindow exists and is visible
            Form helperWindow = TestDriver.WidgetGet<Form>("HelperWindow");

            helperWindow.Minimize();
            // check HelperWindow is not visible
            helperWindow.CheckIsNotDisplayed("HelperWindow");
        }

        [Test, Order(040)]
        public void W040_HelperWindow_Restore()
        {
            // give enough time so YOU can follow the minimized window restoring
            TestDriver.Sleep(Waiter.Duration);

            // get HelperWindow exists (doesn't check is displayed)
            Form helperWindow = TestDriver.WidgetGet<Form>("HelperWindow", 5, false);
            // check HelperWindow is not visible
            helperWindow.CheckIsNotDisplayed("HelperWindow");

            helperWindow.Restore();
            // check HelperWindow is visible
            helperWindow.CheckIsDisplayed("HelperWindow");
        }

        [Test, Order(050)]
        public void W050_MainPage_buttonsWindow_Click()
        {
            // get MainPage
            Page mainPage = TestDriver.WidgetGet<Page>("MainPage");
            // click buttonsWindow on MainPage
            mainPage.ButtonClick("buttonsWindow");

            // get ButtonsWindow and check it's visible
            Form buttonsWindow = TestDriver.WidgetGet<Form>("ButtonsWindow");
        }

        [Test, Order(060)]
        public void W060_ButtonsWindow_customerEditor_Click()
        {
            // get ButtonsWindow and check it's visible
            Form buttonsWindow = TestDriver.WidgetGet<Form>("ButtonsWindow");
            // get buttonsPanel
            Panel buttonsPanel = buttonsWindow.WidgetGet<Panel>("buttonsPanel");
            // click customerEditor on buttonsPanel
            buttonsPanel.ButtonClick("customerEditor");

            // get CustomerEditor exists and is visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor");
        }

        [Test, Order(080)]
        public void W080_CustomerEditor_EditRegisterOne_firstName()
        {
            TestDriver.Sleep(Waiter.Duration);

            // get CustomerEditor exists and is visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor");

            // get DataGridView
            DataGridView dataGridView = customerEditor.WidgetGet<DataGridView>("dataGridView");
            // check DataGridView has two rows
            Assert.IsTrue(dataGridView.RowCount == 2,
                string.Format("dataGridView row count: expected 2 and actual is {0}.", dataGridView.RowCount));

            // get & check firstName TextBox
            customerEditor.WaitCheckTextIs("firstName", "Enlodado", "TextBox");

            #region THIS DOES NOT WORK RELIABLY

            /*// set focus on firstName
            firstName.SendKeys("");
            // clear firstName - beware Edge and Firefox are picky about actions
            Actions action = new Actions(TestDriver.WebDriver);
            action.KeyDown(Keys.Shift).SendKeys(Keys.Home).KeyUp(Keys.Shift).SendKeys(Keys.Delete).Perform();

            // check firstName is empty
            firstName.CheckTextIs(string.Empty);

            // move back so firstName looses the focus
            firstName.SendKeys(Keys.Shift + Keys.Tab);

            // change firstName
            firstName.SendKeys("Muddy");*/

            #endregion

            // change firstName and wait until it's changed
            customerEditor.SetTextCheckResult("firstName", "Muddy", "TextBox");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // now Save it
            customerEditor.ButtonClick("saveButton");

            // get & check fullName for changed firstName
            var lastName = customerEditor.WidgetGet<TextBox>("lastName").Text;
            customerEditor.WaitCheckTextIs("fullName", "Muddy " + lastName, "Label");
        }

        [Test, Order(090)]
        public void W090_CustomerEditor_EditRegisterOne_lastName()
        {
            // get CustomerEditor and check it's visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor");

            // get DataGridView
            DataGridView dataGridView = customerEditor.WidgetGet<DataGridView>("dataGridView");
            // check DataGridView has two rows
            Assert.IsTrue(dataGridView.RowCount == 2,
                string.Format("dataGridView row count: expected 2 and actual is {0}.", dataGridView.RowCount));

            // get & check lastName TextBox
            customerEditor.WaitCheckTextIs("lastName", "AGUAS", "TextBox");

            #region THIS DOES NOT WORK RELIABLY

            /*// set focus on lastName
            lastName.SendKeys("");
            // clear lastName - beware Edge and Firefox are picky about actions
            Actions action = new Actions(TestDriver.WebDriver);
            action.KeyDown(Keys.Shift).SendKeys(Keys.Home).KeyUp(Keys.Shift).SendKeys(Keys.Delete).Perform();

            // check lastName is empty
            lastName.CheckTextIs(string.Empty);

            // move back so lastName looses the focus
            lastName.SendKeys(Keys.Shift + Keys.Tab);

            // change lastName
            lastName.SendKeys("waters");*/

            #endregion

            // change lastName and wait until it's changed
            customerEditor.SetTextCheckResult("lastName", "waters", "TextBox");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // now Save it
            customerEditor.ButtonClick("saveButton");

            // get & check fullName for changed lastName
            var firstName = customerEditor.WidgetGet<TextBox>("firstName").Text;
            customerEditor.WaitCheckTextIs("fullName", firstName + " WATERS", "Label");
        }

        [Test, Order(100)]
        public void W100_CustomerEditor_EditRegisterOne_state()
        {
            // get CustomerEditor and check it's visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor");

            // get DataGridView
            DataGridView dataGridView = customerEditor.WidgetGet<DataGridView>("dataGridView");
            // check DataGridView has two rows
            Assert.IsTrue(dataGridView.RowCount == 2,
                string.Format("dataGridView row count: expected 2 and actual is {0}.", dataGridView.RowCount));

            // get state ComboBox
            ComboBox state = customerEditor.WidgetGet<ComboBox>("state");
            // check state
            state.CheckTextIs("Florida");

            // change state
            state.SelectItem(25);
            // wait until it's changed
            customerEditor.WaitCheckTextIs("state", "Mississippi", "ComboBox");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // now Save it
            customerEditor.ButtonClick("saveButton");

            // get & check changed lastName
            customerEditor.WaitCheckTextIs("state", "Mississippi", "ComboBox");

            TestDriver.Sleep(Waiter.Duration);
        }

        [Test, Order(110)]
        public void W110_CustomerEditor_NewRegister()
        {
            // get CustomerEditor and check it's visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor");

            // click newButton on CustomerEditor
            customerEditor.ButtonClick("newButton");

            // get & check firstName TextBox is empty
            customerEditor.WaitCheckTextIs("firstName", string.Empty, "TextBox");

            // get firstName TextBox and insert firstName
            customerEditor.WidgetGet<TextBox>("firstName").SendKeys("B. B.");

            // wait until it's changed
            customerEditor.WaitCheckTextIs("firstName", "B. B.", "TextBox");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // now Save it
            customerEditor.ButtonClick("saveButton");

            // get & check changed firstName
            customerEditor.WaitCheckTextIs("firstName", "B. B.", "TextBox");

            // get & check lastName TextBox is empty
            customerEditor.WaitCheckTextIs("lastName", string.Empty, "TextBox");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get lastName TextBox and insert lastName
            customerEditor.WidgetGet<TextBox>("lastName").SendKeys("king");

            // wait until it's changed
            customerEditor.WaitCheckTextIs("lastName", "king", "TextBox");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            customerEditor.ButtonClick("saveButton");

            // get & check changed lastNam
            customerEditor.WaitCheckTextIs("lastName", "KING", "TextBox");

            // get a refreshed state ComboBox and change state
            const string state = "Maryland";
            customerEditor.WidgetGet<ComboBox>("state").SelectItem(state);
            // wait until it's changed
            customerEditor.WaitCheckTextIs("state", state, "ComboBox");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            customerEditor.ButtonClick("saveButton");

            // get & check changed lastName
            customerEditor.WaitCheckTextIs("state", state, "ComboBox");

            TestDriver.Sleep(Waiter.Duration);
        }

        [Test, Order(120)]
        public void W120_CustomerEditor_NavigateRows()
        {
            // get CustomerEditor and check it's visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor");
            // get DataGridView
            DataGridView dataGridView = customerEditor.WidgetGet<DataGridView>("dataGridView");
            // check DataGridView has three rows
            Assert.IsTrue(dataGridView.RowCount == 3,
                string.Format("dataGridView row count: expected 3 and actual is {0}.", dataGridView.RowCount));

            // select row 0
            dataGridView.SelectRow(0);

            // check row 0 is selected
            int[] selectedIndices = dataGridView.SelectedIndices;
            int selectedRow = selectedIndices[0];
            Assert.IsTrue(selectedIndices.Length == 1 && selectedRow == 0);

            // check the values of row 0
            dataGridView.CheckRowTextIs(
                new[] {"1", "Muddy", "WATERS", "Mississippi", "Muddy WATERS"}, selectedRow);

            // select row 1 with arrow key
            dataGridView.SendKeys(Keys.ArrowDown);

            // check row 1 is selected
            selectedIndices = dataGridView.SelectedIndices;
            selectedRow = selectedIndices[0];
            Assert.IsTrue(selectedIndices.Length == 1 && selectedRow == 1);

            // check the values of row 1
            dataGridView.CheckRowTextIs(
                new[] {"2", "Louis", "ARMSTRONG", "Louisiana", "Louis ARMSTRONG"},
                0,
                selectedRow);

            // select row 2
            dataGridView.SelectRow(2);

            // check row 2 is selected
            selectedIndices = dataGridView.SelectedIndices;
            selectedRow = selectedIndices[0];
            Assert.IsTrue(selectedIndices.Length == 1 && selectedRow == 2);

            // check the values of row 2
            dataGridView.CheckRowTextIs(
                new[] {"B. B.", "Maryland", "3", "KING", "B. B. KING"},
                new[] {1, 3, 0, 2, 4},
                selectedRow);
        }

        [Test, Order(130)]
        public void W130_CustomerEditor_RemoveRows()
        {
            // get CustomerEditor and check it's visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor");
            // get DataGridView
            DataGridView dataGridView = customerEditor.WidgetGet<DataGridView>("dataGridView");
            // check DataGridView has three rows
            Assert.IsTrue(dataGridView.RowCount == 3,
                string.Format("dataGridView row count: expected 3 and actual is {0}.", dataGridView.RowCount));

            // select row 1 (with id 2)
            dataGridView.SelectRow(1);

            // check row 1 is selected
            int[] selectedIndices = dataGridView.SelectedIndices;
            int selectedRow = selectedIndices[0];
            Assert.IsTrue(selectedIndices.Length == 1 && selectedRow == 1);

            // check the id column of row 1
            Assert.AreEqual("2", dataGridView.GetCellText(0, selectedRow));
            // check id label
            customerEditor.WaitCheckTextIs("id", "2", "Label");

            // Remove the row
            customerEditor.ButtonClick("removeButton");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            dataGridView = customerEditor.WidgetRefresh<DataGridView>("dataGridView");
            // check DataGridView has two rows
            Assert.IsTrue(dataGridView.RowCount == 2,
                string.Format("dataGridView row count: expected 2 and actual is {0}.", dataGridView.RowCount));
        }

        [Test, Order(140)]
        public void W140_CloseCustomerEditors()
        {
            // give enough time so YOU can see
            TestDriver.Sleep(Waiter.Duration);

            // get CustomerEditor and check it's visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor");
            // close customerEditor
            customerEditor.Close();
            // check customerEditor is closed
            customerEditor.CheckIsDisposed();
        }

        [Test, Order(150)]
        public void W150_ButtonsWindow_productEditor_Click()
        {
            // get ButtonsWindow and check it's visible
            Form buttonsWindow = TestDriver.WidgetGet<Form>("ButtonsWindow");
            // get buttonsPanel
            Panel buttonsPanel = buttonsWindow.WidgetGet<Panel>("buttonsPanel");
            // click productEditor on buttonsPanel
            buttonsPanel.ButtonClick("productEditor");

            // check ProductEditor exists and is visible
            Form productEditor = TestDriver.WidgetGet<Form>("ProductEditor");
        }

        [Test, Order(160)]
        public void W160_ProductEditor_tabControl()
        {
            // get tabControl and check it's visible
            TabControl tabControl = TestDriver.WidgetGet<TabControl>("ProductEditor.tabControl");
        }

        [Test, Order(170)]
        public void W170_ProductEditor_tabControl_brands()
        {
            // get tabControl and check it's visible
            TabControl tabControl = TestDriver.WidgetGet<TabControl>("ProductEditor.tabControl");

            // select brands TabPage by label
            tabControl.SelectItem("Brands");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get brands TabPage
            TabPage brands = tabControl.Current;

            // check brands exists and is visible
            Assert.IsNotNull(brands);
            brands.CheckIsDisplayed("brands");
        }

        [Test, Order(180)]
        public void W180_ProductEditor_brandsListBox_edit()
        {
            // get brandsListBox and check it's visible
            ListBox brandsListBox = TestDriver.WidgetGet<ListBox>("ProductEditor.tabControl.brands.brandsListBox");

            // check there are 10 items total
            Assert.AreEqual(10, brandsListBox.ListItems.Count);

            // select item 1
            brandsListBox.SelectItem(1);

            // check there is an item selected
            IList<ListItem> selectedItems = brandsListBox.SelectedItems;
            Assert.AreEqual(1, selectedItems.Count);

            // check item 0 is "Petroluz"
            ListItem listItem = selectedItems[0];
            Assert.AreEqual("Petroluz", listItem.Value);

            // open BrandEditor
            listItem.DoubleClick();

            // get BrandEditor and check it's visible
            Form brandEditor = TestDriver.WidgetGet<Form>("BrandEditor");

            // change brandNameTextBox and wait until it's changed
            brandEditor.SetTextCheckResult("brandNameTextBox", "Electrolux", "TextBox");

            // get saveButton, check it's visible and click it
            Button saveButton = brandEditor.WidgetGet<Button>("saveButton");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            saveButton.Click();

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // check changed ListItem 1 value
            // TODO: add "wait for"
            Assert.AreEqual("Electrolux", listItem.Text);

            // give enough time so YOU can see
            TestDriver.Sleep(Waiter.Duration);
        }

        [Test, Order(190)]
        public void W190_ProductEditor_brandsListBox_new()
        {
            // get newButton, check it's visible and click it
            Button newButton = TestDriver.WidgetGet<Button>("ProductEditor.newButton");
            newButton.Click();

            // change brandNameTextBox and wait until it's changed
            TestDriver.SetTextCheckResult("BrandEditor.brandNameTextBox", "Huawei", "TextBox");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get saveButton, check it's visible and click it
            Button saveButton = TestDriver.WidgetGet<Button>("BrandEditor.saveButton");
            saveButton.Click();

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // refresh and get brandsListBox and check it's visible
            ListBox brandsListBox =
                TestDriver.WidgetRefresh<ListBox>("ProductEditor.tabControl.brands.brandsListBox");

            // check there are 11 items total
            Assert.AreEqual(11, brandsListBox.ListItems.Count);

            // get ListItem 9 and check it's visible
            ListItem listItem = brandsListBox.ListItems[10];
            // check ListItem 10 value
            // TODO: add "wait for"
            Assert.AreEqual("Huawei", listItem.Value);

            brandsListBox.SelectItem(10);

            // give enough time so YOU can see
            TestDriver.Sleep(Waiter.Duration);
        }

        [Test, Order(200)]
        public void W200_ProductEditor_brandsListBox_remove()
        {
            // get brands TabPage and check it's visible
            TabPage brands = TestDriver.WidgetGet<TabPage>("ProductEditor.tabControl.brands");

            // get brandsListBox and check it's visible
            ListBox brandsListBox = brands.WidgetGet<ListBox>("brandsListBox");

            // get ListItem "LLG" and select it
            ListItem listItem = brandsListBox.GetSelectableItem("LLG") as ListItem;
            listItem?.Select();

            // check there is a ListItem selected
            ListItem[] selectedItems = brandsListBox.WaitForSelectedItems(1);
            Assert.AreEqual(1, selectedItems.Length);

            // check ListItem "LLG" value
            Assert.AreEqual("LLG", listItem?.Value);

            // get removeButton, check it's visible and click it
            Button removeButton = TestDriver.WidgetGet<Button>("ProductEditor.removeButton");
            removeButton.Click();

            //TestDriver.Sleep(Waiter.BrowserUpdate);

            // refresh and get brandsListBox and check it's visible
            brandsListBox = brands.WidgetRefresh<ListBox>("brandsListBox");

            // check ListItem "LLG" doesn't exist
            listItem = brandsListBox.GetSelectableItem("LLG") as ListItem;
            Assert.IsNull(listItem);

            // check there are 10 items total
            Assert.AreEqual(10, brandsListBox.ListItems.Count);
        }

        [Test, Order(210)]
        public void W210_ProductEditor_tabControl_productTypes()
        {
            // get tabControl and check it's visible
            TabControl tabControl = TestDriver.WidgetGet<TabControl>("ProductEditor.tabControl");

            // select models TabPage by item number
            tabControl.SelectItem(1);

            // get productTypes TabPage
            TabPage productTypes = tabControl.Current;

            // check productTypes exists and is visible
            Assert.IsNotNull(productTypes);
            productTypes.CheckIsDisplayed("productTypes");
        }

        [Test, Order(220)]
        public void W220_ProductEditor_productTypesTreeView_edit()
        {
            // get productTypesTreeView and check it's visible
            TreeView productTypesTreeView =
                TestDriver.WidgetGet<TreeView>("ProductEditor.tabControl.productTypes.productTypesTreeView");

            // check there are 10 nodes total
            Assert.AreEqual(10, productTypesTreeView.Nodes.Length);

            // select TreeNode 5
            productTypesTreeView.SelectItem(5);

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // check there is a TreeNode selected
            TreeNode[] selectedNodes = productTypesTreeView.WaitForSelectedNodes(1);
            Assert.AreEqual(1, selectedNodes.Length);

            // select TreeNode 5 and check it's label is "Washers/Dryer"
            TreeNode treeNode = selectedNodes[0];
            QxLabel label = treeNode.Label;
            Assert.AreEqual("Washers/Dryer", label.Text);

            // open ProductTypeEditor
            treeNode.Click();
            treeNode.Click();

            // get productTypeEditor and check it's visible
            Form productTypeEditor = TestDriver.WidgetGet<Form>("ProductTypeEditor");

            // change productTypeNameTextBox and wait until it's changed
            productTypeEditor.SetTextCheckResult("productTypeNameTextBox", "Washer and Dryer", "TextBox");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get saveButton and click it
            Button saveButton = productTypeEditor.WidgetGet<Button>("saveButton");
            saveButton.Click();

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // re-check TreeNode 5 value
            productTypesTreeView.SelectItem(5);

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // check there is a TreeNode selected
            selectedNodes = productTypesTreeView.WaitForSelectedNodes(1);
            Assert.AreEqual(1, selectedNodes.Length);

            // check TreeNode 5 label is "Washer and Dryer"
            treeNode = selectedNodes[0];
            label = treeNode.Label;
            Assert.AreEqual("Washer and Dryer", label.Text);

            // give enough time so YOU can see
            TestDriver.Sleep(Waiter.Duration);
        }

        [Test, Order(230)]
        public void W230_ProductEditor_productTypesTreeView_new()
        {
            // get newButton, check it's visible and click it
            Button newButton = TestDriver.WidgetGet<Button>("ProductEditor.newButton");
            newButton.Click();

            // get productTypeNameTextBox and check it's visible
            TextBox productTypeNameTextBox = TestDriver.WidgetGet<TextBox>("ProductTypeEditor.productTypeNameTextBox");

            // set product type name
            productTypeNameTextBox.Value = "Cell Phone";

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get saveButton, check it's visible and click it
            Button saveButton = TestDriver.WidgetGet<Button>("ProductTypeEditor.saveButton");
            saveButton.Click();

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get productTypesTreeView and check it's visible
            TreeView productTypesTreeView =
                TestDriver.WidgetRefresh<TreeView>("ProductEditor.tabControl.productTypes.productTypesTreeView");

            // check there are 11 items total
            Assert.AreEqual(11, productTypesTreeView.Nodes.Length);

            // get TreeNode 10 and select it
            TreeNode treeNode = productTypesTreeView.Nodes[10];
            treeNode.ScrollIntoView();
            treeNode.Select();

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // check TreeNode 10 value
            Assert.AreEqual("Cell Phone", treeNode.Label.Text);

            // give enough time so YOU can see
            TestDriver.Sleep(Waiter.Duration);
        }

        [Test, Order(240)]
        public void W240_ProductEditor_productTypesTreeView_remove()
        {
            // get productTypes TabPage and check it's visible
            TabPage productTypes = TestDriver.WidgetGet<TabPage>("ProductEditor.tabControl.productTypes");

            // get productTypesTreeView and check it's visible
            TreeView productTypesTreeView = productTypes.WidgetGet<TreeView>("productTypesTreeView");

            // get TreeNode "TV Top Box" and select it
            TreeNode treeNode = productTypesTreeView.GetSelectableItem("TV Top Box") as TreeNode;
            treeNode?.Select();

            // check there is a TreeNode selected
            TreeNode[] selectedNodes = productTypesTreeView.WaitForSelectedNodes(1);
            Assert.AreEqual(1, selectedNodes.Length);

            // check TreeNode "TV Top Box" value
            Assert.AreEqual("TV Top Box", treeNode?.Label.Text);

            // get removeButton, check it's visible and click it
            Button removeButton = TestDriver.WidgetGet<Button>("ProductEditor.removeButton");
            removeButton.Click();

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // refresh and get brandsListBox and check it's visible
            productTypesTreeView = productTypes.WidgetRefresh<TreeView>("productTypesTreeView");

            // check TreeNode "TV Top Box" doesn't exist
            treeNode = productTypesTreeView.GetSelectableItem("TV Top Box") as TreeNode;
            Assert.IsNull(treeNode);

            // check there are 10 items total
            Assert.AreEqual(10, productTypesTreeView.Nodes.Length);
        }

        [Test, Order(250)]
        public void W250_ProductEditor_tabControl_models()
        {
            // get tabControl and check it's visible
            TabControl tabControl = TestDriver.WidgetGet<TabControl>("ProductEditor.tabControl");

            // select models TabPage by label
            tabControl.SelectItem("Models");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get models TabPage
            var models = tabControl.Current;

            // check models exists and is visible
            Assert.IsNotNull(models);
            models.CheckIsDisplayed("models");

            // get modelsDataGridView and check it's visible
            DataGridView modelsDataGridView = models.WidgetGet<DataGridView>("modelsDataGridView");

            // select row 0
            modelsDataGridView.SelectRow(0);

            // check row 0 is selected
            int[] selectedIndices = modelsDataGridView.SelectedIndices;
            int selectedRow = selectedIndices[0];
            Assert.IsTrue(selectedIndices.Length == 1 && selectedRow == 0);
        }

        [Test, Order(260)]
        public void W260_ProductEditor_modelsDataGridView_row0_Name()
        {
            // get modelsDataGridView and check it's visible
            DataGridView modelsDataGridView =
                TestDriver.WidgetGet<DataGridView>("ProductEditor.tabControl.models.modelsDataGridView");

            // focus column 1 and check it's focused
            modelsDataGridView.FocusCell(1, 0);
            int focusedColumn = modelsDataGridView.GetFocusedColumn();
            int focusedRow = modelsDataGridView.GetFocusedRow();
            Assert.AreEqual(1, focusedColumn);
            Assert.AreEqual(0, focusedRow);

            // check the "Name" column for row 0
            Assert.AreEqual("SMSTV 2020H", modelsDataGridView.GetCellText(focusedColumn, focusedRow));

            // get the cell editor for focused cell
            TextBox cellEditor = modelsDataGridView.CellEditorGet<TextBox>();
            Assert.IsNotNull(cellEditor);

            // check cell editor text
            cellEditor.CheckTextIs("SMSTV 2020H");

            const string model = "ph fm208";

            // change the focused cell and check changes
            modelsDataGridView.CellSetTextCheckResult(model, model.ToUpper(), "TextBox");
        }

        [Test, Order(270)]
        public void W270_ProductEditor_modelsDataGridView_row0_Brand()
        {
            // get modelsDataGridView and check it's visible
            DataGridView modelsDataGridView =
                TestDriver.WidgetGet<DataGridView>("ProductEditor.tabControl.models.modelsDataGridView");

            // focus column 2 and check it's focused
            modelsDataGridView.FocusCell(2, 0);
            int focusedColumn = modelsDataGridView.GetFocusedColumn();
            Assert.AreEqual(2, focusedColumn);

            // check the brand for row 0
            Assert.AreEqual("Samsung", modelsDataGridView.GetCellText(2, 0));

            // get the cell editor for current focused cell
            ComboBox cellEditor = modelsDataGridView.CellEditorGet<ComboBox>();
            Assert.IsNotNull(cellEditor);

            // check cell editor text
            cellEditor.CheckTextIs("Samsung");

            // edit brand
            cellEditor.SelectItem(5);
            modelsDataGridView.StopEditing();

            // check the brand changes
            const string brand = "Philips";
            Assert.AreEqual(brand, modelsDataGridView.WaitForCellText(brand));
        }

        [Test, Order(280)]
        public void W280_ProductEditor_modelsDataGridView_row0_ProductType()
        {
            // get modelsDataGridView and check it's visible
            DataGridView modelsDataGridView =
                TestDriver.WidgetGet<DataGridView>("ProductEditor.tabControl.models.modelsDataGridView");

            // focus column 3 and check it's focused
            modelsDataGridView.FocusCell(3, 0);
            int focusedColumn = modelsDataGridView.GetFocusedColumn();
            Assert.AreEqual(3, focusedColumn);

            // check the product type for row 0
            Assert.AreEqual("TV", modelsDataGridView.GetCellText(3, 0));

            // get the cell editor for current focused cell
            ComboBox cellEditor = modelsDataGridView.CellEditorGet<ComboBox>();
            Assert.IsNotNull(cellEditor);

            // check cell editor text
            cellEditor.CheckTextIs("TV");

            // edit product type
            cellEditor.SelectItem(2);
            modelsDataGridView.StopEditing();

            // check the product type changes
            const string productType = "Radio";
            Assert.AreEqual(productType, modelsDataGridView.WaitForCellText(productType));

            // give enough time so YOU can see the changes
            TestDriver.Sleep(Waiter.Duration);
        }

        [Test, Order(290)]
        public void W290_ProductEditor_modelsDataGridView_last_row_Name()
        {
            // get modelsDataGridView and check it's visible
            DataGridView modelsDataGridView =
                TestDriver.WidgetGet<DataGridView>("ProductEditor.tabControl.models.modelsDataGridView");

            // check cell text at column 1, row 11
            var cellText = modelsDataGridView.GetCellText(1, 11);
            Assert.AreEqual("TV 97016", cellText);

            // TODO: this does not change the TextBox
            /*// get the cell editor for current focused cell
            TextBox cellEditor = modelsDataGridView.CellEditorGet<TextBox>("Abc", 1, 11);
            Assert.IsNotNull(cellEditor);*/

            var rowIndex = modelsDataGridView.GetFocusedRow();

            // TODO: this way it works all right
            // focus column 1 and check it's focused
            modelsDataGridView.FocusCell(1, rowIndex);
            Assert.AreEqual(1, modelsDataGridView.GetFocusedColumn());

            // focus row 11 and check it's focused
            modelsDataGridView.FocusCell(1, 11);
            Assert.AreEqual(11, modelsDataGridView.GetFocusedRow());

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get the cell editor for current focused cell
            TextBox cellEditor = modelsDataGridView.CellEditorGet<TextBox>();
            Assert.IsNotNull(cellEditor);

            // check cell editor text
            cellEditor.CheckTextIs("TV 97016");

            // edit model name
            cellEditor.Value = "smstv 97016";
            modelsDataGridView.StopEditing();

            // give enough time so YOU can see the changes
            TestDriver.Sleep(Waiter.Duration);

            // check the model name changes
            const string name = "SMSTV 97016";
            Assert.AreEqual(name, modelsDataGridView.WaitForCellText(name));
        }

        [Test, Order(300)]
        public void W300_ProductEditor_modelsDataGridView_add_row()
        {
            // get modelsDataGridView and check it's visible
            DataGridView modelsDataGridView =
                TestDriver.WidgetGet<DataGridView>("ProductEditor.tabControl.models.modelsDataGridView");

            // focus column 1, row 12 and check it's focused
            modelsDataGridView.FocusCell(1, 12);
            int focusedColumn = modelsDataGridView.GetFocusedColumn();
            int focusedRow = modelsDataGridView.GetFocusedRow();
            Assert.AreEqual(1, focusedColumn);
            Assert.AreEqual(12, focusedRow);

            // name

            // get the cell editor for current focused cell
            TextBox nameEditor = modelsDataGridView.CellEditorGet<TextBox>();
            Assert.IsNotNull(nameEditor);

            // edit model name
            nameEditor.Value = "nw 180308";
            modelsDataGridView.StopEditing();

            // give enough time so YOU can see the changes
            TestDriver.Sleep(Waiter.Duration);

            // check the model name changes
            const string name = "NW 180308";
            Assert.AreEqual(name, modelsDataGridView.WaitForCellText(name));

            // brand

            // focus column 2 and check it's focused
            modelsDataGridView.FocusCell(2, focusedRow);
            focusedColumn = modelsDataGridView.GetFocusedColumn();
            Assert.AreEqual(2, focusedColumn);

            // get the cell editor for current focused cell
            ComboBox brandEditor = modelsDataGridView.CellEditorGet<ComboBox>();
            Assert.IsNotNull(brandEditor);

            // edit brand
            brandEditor.SelectItem(3);
            modelsDataGridView.StopEditing();

            // check the brand changes
            const string brand = "Kunft";
            Assert.AreEqual(brand, modelsDataGridView.WaitForCellText(brand));

            // product type

            // focus column 3 and check it's focused
            modelsDataGridView.FocusCell(3, focusedRow);
            focusedColumn = modelsDataGridView.GetFocusedColumn();
            Assert.AreEqual(3, focusedColumn);

            // get the cell editor for current focused cell
            ComboBox productTypeEditor = modelsDataGridView.CellEditorGet<ComboBox>();
            Assert.IsNotNull(productTypeEditor);

            // edit product type
            productTypeEditor.SelectItem(3);
            modelsDataGridView.StopEditing();

            // check the product type changes
            const string productType = "Refrigerator";
            Assert.AreEqual(productType, modelsDataGridView.WaitForCellText(productType));

            // give enough time so YOU can see the changes
            TestDriver.Sleep(Waiter.Duration);
        }

        [Test, Order(310)]
        public void W310_ProductEditor_modelsDataGridView_delete_row()
        {
            // get modelsDataGridView and check it's visible
            DataGridView modelsDataGridView =
                TestDriver.WidgetGet<DataGridView>("ProductEditor.tabControl.models.modelsDataGridView");

            // focus column 0 and check it's focused
            modelsDataGridView.FocusCell(0, 5);
            int focusedColumn = modelsDataGridView.GetFocusedColumn();
            int focusedRow = modelsDataGridView.GetFocusedRow();
            Assert.AreEqual(0, focusedColumn);
            Assert.AreEqual(5, focusedRow);

            // check the "Id" column for row 5
            Assert.AreEqual("6", modelsDataGridView.GetCellText(focusedColumn, focusedRow));

            // now focus on row header
            modelsDataGridView.FocusCell(-1, 5);

            // give enough time so YOU can see the changes
            TestDriver.Sleep(Waiter.Duration);

            // delete the row
            modelsDataGridView.SendKeys(Keys.Delete);

            // give enough time so YOU can see the changes
            TestDriver.Sleep(Waiter.Duration);

            // focus column 0 and check it's focused
            modelsDataGridView.FocusCell(0, focusedRow);
            focusedColumn = modelsDataGridView.GetFocusedColumn();
            focusedRow = modelsDataGridView.GetFocusedRow();
            Assert.AreEqual(0, focusedColumn);
            Assert.AreEqual(5, focusedRow);

            // check the "Id" column for row 5
            Assert.AreEqual("7", modelsDataGridView.GetCellText(focusedColumn, focusedRow));

            // give enough time so YOU can see the changes
            TestDriver.Sleep(Waiter.Duration);

            // delete the row
            modelsDataGridView.DeleteRow(focusedRow);

            // give enough time so YOU can see the changes
            TestDriver.Sleep(Waiter.Duration);

            // focus column 0 and check it's focused
            modelsDataGridView.FocusCell(0, focusedRow);
            focusedColumn = modelsDataGridView.GetFocusedColumn();
            focusedRow = modelsDataGridView.GetFocusedRow();
            Assert.AreEqual(0, focusedColumn);
            Assert.AreEqual(5, focusedRow);

            // check the "Id" column for row 5
            Assert.AreEqual("8", modelsDataGridView.GetCellText(focusedColumn, focusedRow));
        }

        [Test, Order(320)]
        public void W320_CloseProductEditor()
        {
            // give enough time so YOU can see
            TestDriver.Sleep(Waiter.Duration);

            // get ProductEditor and check it's visible
            Form productEditor = TestDriver.WidgetGet<Form>("ProductEditor");
            // close ProductEditor
            productEditor.Close();
            // check ProductEditor is closed
            productEditor.CheckIsDisposed();
        }

        [Test, Order(330)]
        public void W330_ButtonsWindow_supplierEditor_Click()
        {
            // click supplierEditor on buttonsPanel (LayoutPanel) of ButtonsWindow
            TestDriver.ButtonClick("ButtonsWindow.buttonsPanel.supplierEditor");

            // give enough time so YOU can see
            TestDriver.Sleep(Waiter.Duration);

            // check SupplierTreeEditor exists and is visible
            Form supplierTreeEditor = TestDriver.WidgetGet<Form>("SupplierTreeEditor");

            /*// give enough time so YOU can see
            TestDriver.Sleep(Waiter.BrowserUpdate);
            TestDriver.SaveScreenshot("W330_ButtonsWindow_supplierEditor_Click.png");

            // if this the correct screenshot
            MakeScreenshotCollection("W330_ButtonsWindow_supplierEditor_Click");
            VerifyScreenshot("W330_ButtonsWindow_supplierEditor_Click");*/
        }

        /*[Test, Order(340)]
        public void W340_ButtonsWindow_supplierTreeView_navigate()
        {
            // check SupplierTreeEditor exists and is visible
            Form supplierTreeEditor = TestDriver.WidgetGet<Form>("SupplierTreeEditor");

            // get suppliersTreeView and check it's visible
            TreeView suppliersTreeView =
                supplierTreeEditor.WidgetGet<TreeView>("suppliersTreeView");

            // check there are 5 nodes total
            Assert.AreEqual(5, suppliersTreeView.Nodes.Length);

            // select TreeNode 0
            suppliersTreeView.SelectItem(0);

            // check there is a TreeNode selected
            TreeNode[] selectedNodes = suppliersTreeView.WaitForSelectedNodes(1);
            Assert.AreEqual(1, selectedNodes.Length);

            // select TreeNode 0 and check it's label is "Big John"
            TreeNode treeNode = selectedNodes[0];
            QxLabel label = treeNode.Label;
            Assert.AreEqual("Big John", label.Text);

            // give enough time so YOU can see
            TestDriver.Sleep(Waiter.Duration);

            // select "Big John" TreeNode 0 and check it's label is "Small John Silver"
            TreeNode childNode = treeNode.Nodes[0];
            childNode.Select();
            label = childNode.Label;
            Assert.AreEqual("Small John Silver", label.Text);

            // give enough time so YOU can see
            TestDriver.Sleep(Waiter.Duration);

            // select TreeNode 0 and check it's label is ""Small John John""
            childNode = treeNode.GetSelectableItem("Small John John") as TreeNode;
            childNode?.Select();

            // give enough time so YOU can see
            TestDriver.Sleep(Waiter.Duration);

            // select "Small John John" TreeNode "Baby John Jonathan" and check it's label
            TreeNode grandChildNode = childNode?.GetSelectableItem("Baby John Jonathan") as TreeNode;
            grandChildNode?.Select();
            label = grandChildNode?.Label;
            Assert.AreEqual("Baby John Jonathan", label?.Text);

            // give enough time so YOU can see
            TestDriver.Sleep(Waiter.Duration);

            // get TreeNode "Patricia" and select it
            treeNode = suppliersTreeView.GetSelectableItem("Patricia") as TreeNode;
            treeNode?.Select();
            label = treeNode?.Label;
            Assert.AreEqual("Patricia", label?.Text);

            // give enough time so YOU can see
            TestDriver.Sleep(Waiter.Duration);
        }

        [Test, Order(350)]
        public void W350_ButtonsWindow_supplierTreeView_editGrandChild()
        {
            // check SupplierTreeEditor exists and is visible
            Form supplierTreeEditor = TestDriver.WidgetGet<Form>("SupplierTreeEditor");

            // get suppliersTreeView and check it's visible
            TreeView suppliersTreeView =
                supplierTreeEditor.WidgetGet<TreeView>("suppliersTreeView");

            // get TreeNode "Big John" and select it
            TreeNode treeNode = suppliersTreeView.Nodes[0];
            treeNode.Select();
            QxLabel label = treeNode.Label;
            Assert.AreEqual("Big John", label.Text);

            // give enough time so YOU can see
            TestDriver.Sleep(Waiter.Duration);

            // select "Big John" child 1 and check it's label is "Small John John"
            TreeNode childNode = treeNode.Nodes[1];
            childNode.Select();
            label = childNode.Label;
            Assert.AreEqual("Small John John", label.Text);

            // give enough time so YOU can see
            TestDriver.Sleep(Waiter.Duration);

            // select "Small John John" child 0 and check it's label is "Baby John Johnny"
            TreeNode grandChildNode = childNode.Nodes[0];
            grandChildNode.Select();
            label = grandChildNode.Label;
            Assert.AreEqual("Baby John Johnny", label.Text);

            // edit "Baby John Johnny"
            grandChildNode.DoubleClick();

            // we are going to change the parent node of "Baby John Johnny"
            // now the parent is "Small John John"
            // after the change, the parent will be "Small John Silver"
            // we will also change the Id from 121 to 111
            // abd its name to "Baby John Silverado"

            // get SupplierEditor and check it's visible
            Form supplierEditor = TestDriver.WidgetGet<Form>("SupplierEditor");

            // get a refreshed parentComboBox ComboBox and change parent
            const string parent = "Small John Silver";
            supplierEditor.WidgetGet<ComboBox>("parentComboBox").SelectItem(parent);
            TestDriver.Sleep(Waiter.BrowserUpdate);
            // wait until it's changed
            supplierEditor.WaitCheckTextIs("parentComboBox", parent, "ComboBox");

            // change the Id to 111
            supplierEditor.WidgetGet<TextBox>("supplierIdTextBox").Click();
            TestDriver.Sleep(Waiter.BrowserUpdate);
            supplierEditor.SetTextCheckResult("supplierIdTextBox", "111", "TextBox");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // change the Name to "Baby John Silverado"
            supplierEditor.WidgetGet<TextBox>("supplierNameTextBox").Click();
            TestDriver.Sleep(Waiter.BrowserUpdate);
            supplierEditor.SetTextCheckResult("supplierNameTextBox", "Baby John Silverado", "TextBox");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get saveButton, check it's visible and click it
            supplierEditor.ButtonClick("saveButton");

            TestDriver.Sleep(Waiter.BrowserUpdate);
            TestDriver.SaveScreenshot("W350_ButtonsWindow_supplierTreeView_editGrandChild.png");

            // if this the correct screenshot
            MakeScreenshotCollection("W350_ButtonsWindow_supplierTreeView_editGrandChild");
            VerifyScreenshot("W350_ButtonsWindow_supplierTreeView_editGrandChild");

            // re-fetch TreeNode 0 ("Big John") and select it
            treeNode = suppliersTreeView.Nodes[0];

            // select "Big John" child 0 and check it's label is "Small John Silver"
            childNode = treeNode.Nodes[0];
            label = childNode.Label;
            Assert.AreEqual("Small John Silver", label.Text);

            // give enough time so YOU can see
            TestDriver.Sleep(Waiter.Duration);

            // select "Small John Silver" child "Baby John Silverado" and check it's label
            grandChildNode = childNode.Nodes[0];
            grandChildNode.Select();
            label = grandChildNode.Label;
            Assert.AreEqual("Baby John Silverado", label.Text);

            // give enough time so YOU can see
            TestDriver.Sleep(Waiter.Duration);
        }

        [Test, Order(360)]
        public void W360_ButtonsWindow_supplierTreeView_newChild()
        {
            // get suppliersTreeView and check it's visible
            TreeView suppliersTreeView =
                TestDriver.WidgetGet<TreeView>("SupplierTreeEditor.suppliersTreeView");

            // get TreeNode "Patricia" and select it
            TreeNode treeNode = suppliersTreeView.GetSelectableItem("Patricia") as TreeNode;
            treeNode?.Select();
            QxLabel label = treeNode?.Label;
            Assert.AreEqual("Patricia", label?.Text);

            // get newButton, check it's visible and click it
            Button newButton = TestDriver.WidgetGet<Button>("SupplierTreeEditor.newButton");
            newButton.Click();

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get SupplierEditor and check it's visible
            Form supplierEditor = TestDriver.WidgetGet<Form>("SupplierEditor");

            // set the Id to 51
            supplierEditor.SetTextCheckResult("supplierIdTextBox", "51", "TextBox");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // set the Name to "Small Patricia"
            supplierEditor.WidgetGet<TextBox>("supplierNameTextBox").Click();
            TestDriver.Sleep(Waiter.BrowserUpdate);
            supplierEditor.SetTextCheckResult("supplierNameTextBox", "Small Patricia", "TextBox");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get saveButton, check it's visible and click it
            supplierEditor.ButtonClick("saveButton");

            TestDriver.Sleep(Waiter.BrowserUpdate);
            TestDriver.SaveScreenshot("W360_ButtonsWindow_supplierTreeView_newChild.png");

            // if this the correct screenshot
            MakeScreenshotCollection("W360_ButtonsWindow_supplierTreeView_newChild");
            VerifyScreenshot("W360_ButtonsWindow_supplierTreeView_newChild");

            // re-fetch TreeNode 4 ("Patricia") and select it
            treeNode = suppliersTreeView.Nodes[4];

            // select "Patricia" child 0 and check it's label is "Small Patricia"
            TreeNode childNode = treeNode?.Nodes[0];
            childNode?.Select();
            label = childNode?.Label;
            Assert.AreEqual("Small Patricia", label?.Text);

            // give enough time so YOU can see
            TestDriver.Sleep(Waiter.Duration);
        }

        [Test, Order(370)]
        public void W370_ButtonsWindow_supplierTreeView_removeChild()
        {
            // check SupplierTreeEditor exists and is visible
            Form supplierTreeEditor = TestDriver.WidgetGet<Form>("SupplierTreeEditor");

            // get suppliersTreeView and check it's visible
            TreeView suppliersTreeView =
                supplierTreeEditor.WidgetGet<TreeView>("suppliersTreeView");

            // check there are 5 nodes total
            Assert.AreEqual(5, suppliersTreeView.Nodes.Length);

            // select TreeNode 0 ("Big John")
            suppliersTreeView.SelectItem(0);

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get removeButton, check it's visible and click it
            Button removeButton = TestDriver.WidgetGet<Button>("SupplierTreeEditor.removeButton");
            removeButton.Click();

            TestDriver.Sleep(Waiter.BrowserUpdate);
            TestDriver.SaveScreenshot("W370_ButtonsWindow_supplierTreeView_removeChild.png");

            // if this the correct screenshot
            MakeScreenshotCollection("W370_ButtonsWindow_supplierTreeView_removeChild");
            VerifyScreenshot("W370_ButtonsWindow_supplierTreeView_removeChild");

            // check there are 4 nodes total
            Assert.AreEqual(4, suppliersTreeView.Nodes.Length);

            TreeNode treeNode = suppliersTreeView.GetSelectableItem("Big Larry") as TreeNode;
            treeNode?.Select();
            QxLabel label = treeNode?.Label;
            Assert.AreEqual("Big Larry", label?.Text);
        }*/

        [Test, Order(390)]
        public void W390_CloseSuppliertEditor()
        {
            // give enough time so YOU can see
            TestDriver.Sleep(Waiter.Duration);

            // get SupplierTreeEditor and check it's visible
            Form supplierTreeEditor = TestDriver.WidgetGet<Form>("SupplierTreeEditor");
            // close SupplierTreeEditor
            supplierTreeEditor.Close();

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // check ProductEditor is closed
            supplierTreeEditor.CheckIsDisposed();
        }

        [Test, Order(400)]
        public void W400_ButtonsWindow_orderEditor_Click()
        {
            // click orderEditor on buttonsPanel (LayoutPanel) of ButtonsWindow
            TestDriver.ButtonClick("ButtonsWindow.buttonsPanel.orderEditor");

            // give enough time so YOU can see the alert boxes
            TestDriver.Sleep(Waiter.Duration);

            TestDriver.AlertBoxClose(MessageBoxIcon.Error, "Order Editor must be implemented");
            TestDriver.AlertBoxClose("Order Editor should be implemented");
            TestDriver.AlertBoxClose(MessageBoxIcon.Information);

            TestDriver.AlertBoxCheckNotExists(MessageBoxIcon.Error, "Order Editor must be implemented");
            TestDriver.AlertBoxCheckNotExists("Order Editor should be implemented");
            TestDriver.AlertBoxCheckNotExists(MessageBoxIcon.Information);
        }

        [Test, Order(420)]
        //[ExpectedException(typeof(InvalidElementStateException), "Widget is not enabled")]
        public void W420_ButtonsWindow_invoiceEditor_Click()
        {
            Button button = TestDriver.WidgetGet<Button>("ButtonsWindow.buttonsPanel.invoiceEditor");
            Assert.IsFalse(button.Enabled, "Button \"invoiceEditor\" isn\'t enabled.");
            //button.Click();
            Assert.Throws<InvalidElementStateException>(() => button.Click());
        }

        [Test, Order(430)]
        public void W430_ButtonsWindow_invoiceEditor_Click_No_MessageBox()
        {
            Button button = TestDriver.WidgetGet<Button>("ButtonsWindow.buttonsPanel.invoiceEditor");
            button.ForceClick();

            // give enough time so YOU can see the alert boxes
            TestDriver.Sleep(Waiter.Duration);

            TestDriver.MessageBoxCheckNotExists();
        }

        [Test, Order(440)]
        public void W440_CloseButtonsWindow()
        {
            // give enough time so YOU can follow the windows closing
            TestDriver.Sleep(Waiter.Duration);

            // close ButtonsWindow
            // TODO: WaitormClose
            //TestDriver.FormClose("ButtonsWindow");

            // get buttonsWindow and check it's visible
            Form buttonsWindow = TestDriver.WidgetGet<Form>("ButtonsWindow");
            // close buttonsWindow
            buttonsWindow.Close();

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // check ButtonsWindow is closed
            buttonsWindow.CheckIsDisposed();
        }

        [Test, Order(450)]
        public void W450_AskQuitYes()
        {
            // click exit on MainPage (presume MainPage exists and is visible)
            TestDriver.ButtonClick("MainPage.exit");

            // click Yes on MessageBox
            TestDriver.MessageBoxButtonClick(DialogResult.Yes);

            // give enough time so YOU can see the root Page before the browser shows an empty screen
            //TestDriver.Sleep(Waiter.Duration * 2);
        }
    }
}