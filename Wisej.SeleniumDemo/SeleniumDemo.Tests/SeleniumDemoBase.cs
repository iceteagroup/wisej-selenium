using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Wisej.Web.Ext.Selenium;
using Wisej.Web.Ext.Selenium.Tests;
using Wisej.Web.Ext.Selenium.UI;
using Wisej.Web.Ext.Selenium.UI.List;

namespace SeleniumDemo.Tests
{
    public abstract class SeleniumDemoBase
    {
        protected static SeleniumDemoWebDriver TestDriver;
        protected static Browser CurrentBrowser;

        [TestMethod]
        public void W010_AskQuitNo()
        {
            TestDriver.SleepDebugTest(2000);

            // get MainPage and check it's visible
            Page mainPage = TestDriver.WidgetGet<Page>("MainPage");

            // click exit on MainPage
            mainPage.ButtonClick("exit");

            var title = "Exit Application";
            var message = "Do you want to exit now?";
            var icon = MessageBoxIcon.Question;

            // get MessageBox using all parameters check it's enabled
            MessageBox messageBox = TestDriver.GetMessageBox(title, false, icon, message);

            // click "No"
            messageBox.ButtonClick(DialogResult.No);

            // check messageBox doesn't exist
            TestDriver.MessageBoxAssertNotExists(title, false, icon, message);
        }

        [TestMethod]
        public void W020_ButtonsWindow_helper_Click()
        {
            // get MainPage and check it's visible
            Page mainPage = TestDriver.WidgetGet<Page>("MainPage");

            // click helper on ButtonsWindow
            mainPage.ButtonClick("helper");

            // check HelperWindow exists and is visible
            Form helperWindow = TestDriver.WidgetGet<Form>("HelperWindow");
        }

        [TestMethod]
        public void W021_ButtonsWindow_HelperWindow_ResetData_Click()
        {
            // get HelperWindow exists and is visible
            Form helperWindow = TestDriver.WidgetGet<Form>("HelperWindow");

            // click resetData on HelperWindow
            helperWindow.ButtonClick("resetData");
        }

        [TestMethod]
        public void W022_HelperWindow_Minimize()
        {
            // give enough time so YOU can follow the window minimizing
            TestDriver.Sleep(Waiter.Duration);

            // get HelperWindow exists and is visible
            Form helperWindow = TestDriver.WidgetGet<Form>("HelperWindow");

            helperWindow.Minimize();
            // check HelperWindow is not visible
            helperWindow.AssertIsNotDisplayed("HelperWindow");
        }

        [TestMethod]
        public void W024_HelperWindow_Restore()
        {
            // give enough time so YOU can follow the minimized window restoring
            TestDriver.Sleep(Waiter.Duration);

            // get HelperWindow exists (doesn't check is displayed)
            Form helperWindow = TestDriver.WidgetGet<Form>("HelperWindow", 5, false);
            // check HelperWindow is not visible
            helperWindow.AssertIsNotDisplayed("HelperWindow");

            helperWindow.Restore();
            // check HelperWindow is visible
            helperWindow.AssertIsDisplayed("HelperWindow");
        }

        [TestMethod]
        public void W030_MainPage_buttonsWindow_Click()
        {
            // get MainPage
            Page mainPage = TestDriver.WidgetGet<Page>("MainPage");
            // click buttonsWindow on MainPage
            mainPage.ButtonClick("buttonsWindow");

            // get ButtonsWindow and check it's visible
            Form buttonsWindow = TestDriver.WidgetGet<Form>("ButtonsWindow");
        }

        [TestMethod]
        public void W040_ButtonsWindow_customerEditor_Click()
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

        [TestMethod]
        public void W050_CustomerEditor_EditRegisterOne_firstName()
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
            customerEditor.WidgetWaitAssertTextIs("firstName", "Mudy", "TextBox");

            #region THIS DOES NOT WORK RELIABLY

            /*// set focus on firstName
            firstName.SendKeys("");
            // clear firstName - beware Edge and Firefox are picky about actions
            Actions action = new Actions(TestDriver.WebDriver);
            action.KeyDown(Keys.Shift).SendKeys(Keys.Home).KeyUp(Keys.Shift).SendKeys(Keys.Delete).Perform();

            // check firstName is empty
            firstName.AssertTextIs(string.Empty);

            // move back so firstName looses the focus
            firstName.SendKeys(Keys.Shift + Keys.Tab);

            // change firstName
            firstName.SendKeys("Muddy");*/

            #endregion

            // change firstName and wait until it's changed
            customerEditor.WidgetSetTextAssertSync("firstName", "Muddy", "TextBox");

            if (CurrentBrowser == Browser.Edge)
                TestDriver.Sleep(Waiter.BrowserUpdate);

            // now Save it
            customerEditor.ButtonClick("saveButton");

            // get & check fullName for changed firstName
            var lastName = customerEditor.WidgetGet<TextBox>("lastName").Text;
            customerEditor.WidgetWaitAssertTextIs("fullName", "Muddy " + lastName, "Label");
        }

        [TestMethod]
        public void W052_CustomerEditor_EditRegisterOne_lastName()
        {
            // get CustomerEditor and check it's visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor");

            // get DataGridView
            DataGridView dataGridView = customerEditor.WidgetGet<DataGridView>("dataGridView");
            // check DataGridView has two rows
            Assert.IsTrue(dataGridView.RowCount == 2,
                string.Format("dataGridView row count: expected 2 and actual is {0}.", dataGridView.RowCount));

            // get & check lastName TextBox
            customerEditor.WidgetWaitAssertTextIs("lastName", "WATTERS", "TextBox");

            #region THIS DOES NOT WORK RELIABLY

            /*// set focus on lastName
            lastName.SendKeys("");
            // clear lastName - beware Edge and Firefox are picky about actions
            Actions action = new Actions(TestDriver.WebDriver);
            action.KeyDown(Keys.Shift).SendKeys(Keys.Home).KeyUp(Keys.Shift).SendKeys(Keys.Delete).Perform();

            // check lastName is empty
            lastName.AssertTextIs(string.Empty);

            // move back so lastName looses the focus
            lastName.SendKeys(Keys.Shift + Keys.Tab);

            // change lastName
            lastName.SendKeys("waters");*/

            #endregion

            // change lastName and wait until it's changed
            customerEditor.WidgetSetTextAssertSync("lastName", "waters", "TextBox");

            if (CurrentBrowser == Browser.Edge)
                TestDriver.Sleep(Waiter.BrowserUpdate);

            // now Save it
            customerEditor.ButtonClick("saveButton");

            // get & check fullName for changed lastName
            var firstName = customerEditor.WidgetGet<TextBox>("firstName").Text;
            customerEditor.WidgetWaitAssertTextIs("fullName", firstName + " WATERS", "Label");
        }

        [TestMethod]
        public void W054_CustomerEditor_EditRegisterOne_state()
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
            state.AssertTextIs("Florida");

            // change state
            if (CurrentBrowser == Browser.Firefox)
                state.SelectItem("Mississippi");
            else
                state.SelectItem(25);
            // wait until it's changed
            customerEditor.WidgetWaitAssertTextIs("state", "Mississippi", "ComboBox");

            if (CurrentBrowser == Browser.Edge)
                TestDriver.Sleep(Waiter.BrowserUpdate);

            // now Save it
            customerEditor.ButtonClick("saveButton");

            // get & check changed lastName
            customerEditor.WidgetWaitAssertTextIs("state", "Mississippi", "ComboBox");

            TestDriver.Sleep(Waiter.Duration);
        }

        [TestMethod]
        public void W056_CustomerEditor_NewRegister()
        {
            // get CustomerEditor and check it's visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor");
            // click newButton on CustomerEditor
            customerEditor.ButtonClick("newButton");

            // get & check firstName TextBox is empty
            customerEditor.WidgetWaitAssertTextIs("firstName", string.Empty, "TextBox");

            // get firstName TextBox and insert firstName
            customerEditor.WidgetRefresh<TextBox>("firstName").SendKeys("B. B.");
            // wait until it's changed
            customerEditor.WidgetWaitAssertTextIs("firstName", "B. B.", "TextBox");

            if (CurrentBrowser == Browser.Edge)
                TestDriver.Sleep(Waiter.BrowserUpdate);

            // now Save it
            customerEditor.ButtonClick("saveButton");

            // get & check changed firstName
            customerEditor.WidgetWaitAssertTextIs("firstName", "B. B.", "TextBox");

            // get & check lastName TextBox is empty
            customerEditor.WidgetWaitAssertTextIs("lastName", string.Empty, "TextBox");

            // get lastName TextBox and insert lastName
            customerEditor.WidgetRefresh<TextBox>("lastName").SendKeys("king");
            // wait until it's changed
            customerEditor.WidgetWaitAssertTextIs("lastName", "king", "TextBox");

            if (CurrentBrowser == Browser.Edge)
            {
                // get saveButton, check it's visible and click it
                Button saveButton = customerEditor.WidgetGet<Button>("saveButton");

                TestDriver.Sleep(Waiter.BrowserUpdate);

                saveButton.Click();
            }
            else
            {
                // now Save it
                customerEditor.ButtonClick("saveButton");
            }

            // get & check changed lastNam
            customerEditor.WidgetWaitAssertTextIs("lastName", "KING", "TextBox");

            // get a refreshed state ComboBox and change state
            if (CurrentBrowser == Browser.Firefox)
                customerEditor.WidgetRefresh<ComboBox>("state").SelectItem("Maryland");
            else
                customerEditor.WidgetRefresh<ComboBox>("state").SelectItem(20);
            // wait until it's changed
            customerEditor.WidgetWaitAssertTextIs("state", "Maryland", "ComboBox");

            if (CurrentBrowser == Browser.Edge)
                TestDriver.Sleep(Waiter.BrowserUpdate);

            customerEditor.ButtonClick("saveButton");

            // get & check changed lastName
            customerEditor.WidgetWaitAssertTextIs("state", "Maryland", "ComboBox");

            TestDriver.Sleep(Waiter.Duration);
        }

        [TestMethod]
        public void W05_CustomerEditor_NavigateRows()
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
            dataGridView.AssertRowTextIs(
                new[] {"1", "Muddy", "WATERS", "Mississippi", "Muddy WATERS"}, selectedRow);

            // select row 1 with arrow key
            dataGridView.SendKeys(Keys.ArrowDown);

            // check row 1 is selected
            selectedIndices = dataGridView.SelectedIndices;
            selectedRow = selectedIndices[0];
            Assert.IsTrue(selectedIndices.Length == 1 && selectedRow == 1);

            // check the values of row 1
            dataGridView.AssertRowTextIs(
                new List<string> {"2", "Louis", "ARMSTRONG", "Louisiana", "Louis ARMSTRONG"}, 0, selectedRow);

            // select row 2
            dataGridView.SelectRow(2);

            // check row 2 is selected
            selectedIndices = dataGridView.SelectedIndices;
            selectedRow = selectedIndices[0];
            Assert.IsTrue(selectedIndices.Length == 1 && selectedRow == 2);

            // check the values of row 2
            dataGridView.AssertRowTextIs(
                new[] {"B. B.", "Maryland", "3", "KING", "B. B. KING"}, new List<int> {1, 3, 0, 2, 4}, selectedRow);
        }

        [TestMethod]
        public void W060_CustomerEditor_RemoveRows()
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
            customerEditor.WidgetWaitAssertTextIs("id", "2", "Label");

            // Remove the row
            customerEditor.ButtonClick("removeButton");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            dataGridView = customerEditor.WidgetRefresh<DataGridView>("dataGridView");
            // check DataGridView has two rows
            Assert.IsTrue(dataGridView.RowCount == 2,
                string.Format("dataGridView row count: expected 2 and actual is {0}.", dataGridView.RowCount));
        }

        [TestMethod]
        public void W062_CloseCustomerEditors()
        {
            // give enough time so YOU can see the open window
            TestDriver.Sleep(Waiter.Duration);

            // get CustomerEditor and check it's visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor");
            // close customerEditor
            customerEditor.Close();
            // check customerEditor is closed
            customerEditor.AssertIsDisposed("CustomerEditor");
        }

        [TestMethod]
        public void W064_ButtonsWindow_productEditor_Click()
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

        [TestMethod]
        public void W065_ProductEditor_tabControl()
        {
            // get tabControl and check it's visible
            TabControl tabControl = TestDriver.WidgetGet<TabControl>("ProductEditor.tabControl");
        }

        [TestMethod]
        public void W066_ProductEditor_tabControl_brands()
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
            brands.AssertIsDisplayed("brands");
        }

        [TestMethod]
        public void W067_ProductEditor_brandsListBox_edit()
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

            // check item 0 is "Electroluz"
            ListItem listItem = selectedItems[0];
            Assert.AreEqual("Electroluz", listItem.Value);

            // open BrandEditor
            listItem.DoubleClick();

            // get BrandEditor and check it's visible
            Form brandEditor = TestDriver.WidgetGet<Form>("BrandEditor");

            // change brandNameTextBox and wait until it's changed
            brandEditor.WidgetSetTextAssertSync("brandNameTextBox", "Electrolux", "TextBox");

            // get saveButton, check it's visible and click it
            Button saveButton = brandEditor.WidgetGet<Button>("saveButton");

            if (CurrentBrowser == Browser.Edge)
                TestDriver.Sleep(Waiter.BrowserUpdate);

            saveButton.Click();

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // check changed ListItem 1 value
            // TODO: wait for test
            Assert.AreEqual("Electrolux", listItem.Text);

            // give enough time so YOU can see the all the changes
            TestDriver.Sleep(Waiter.Duration);
        }

        [TestMethod]
        public void W068_ProductEditor_brandsListBox_new()
        {
            // get newButton, check it's visible and click it
            Button newButton = TestDriver.WidgetGet<Button>("ProductEditor.newButton");
            newButton.Click();

            // change brandNameTextBox and wait until it's changed
            TestDriver.WidgetSetTextAssertSync("BrandEditor.brandNameTextBox", "Huawei", "TextBox");

            if (CurrentBrowser == Browser.Edge)
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
            // TODO: wait for test
            Assert.AreEqual("Huawei", listItem.Value);

            // give enough time so YOU can see the all the changes
            TestDriver.Sleep(Waiter.Duration);
        }

        [TestMethod]
        public void W069_ProductEditor_brandsListBox_remove()
        {
            // get brands TabPage and check it's visible
            TabPage brands = TestDriver.WidgetGet<TabPage>("ProductEditor.tabControl.brands");

            // get brandsListBox and check it's visible
            ListBox brandsListBox = brands.WidgetGet<ListBox>("brandsListBox");

            brandsListBox.SelectItem(4);
            // get ListItem 4 and check it's visible
            ListItem listItem = brandsListBox.ListItems[4];
            // check ListItem 4 value
            Assert.AreEqual("LLG", listItem.Value);

            // get removeButton, check it's visible and click it
            Button removeButton = TestDriver.WidgetGet<Button>("ProductEditor.removeButton");
            removeButton.Click();

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // refresh and get brandsListBox and check it's visible
            brandsListBox = brands.WidgetRefresh<ListBox>("brandsListBox");

            // check there are 10 items total
            Assert.AreEqual(10, brandsListBox.ListItems.Count);

            // give enough time so YOU can see the all the changes
            TestDriver.Sleep(Waiter.Duration);
        }

        [TestMethod]
        public void W070_ProductEditor_tabControl_productTypes()
        {
            // get tabControl and check it's visible
            TabControl tabControl = TestDriver.WidgetGet<TabControl>("ProductEditor.tabControl");

            // select models TabPage by label
            tabControl.SelectItem("Product Types");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get productTypes TabPage
            TabPage productTypes = tabControl.Current;

            // check productTypes exists and is visible
            Assert.IsNotNull(productTypes);
            productTypes.AssertIsDisplayed("productTypes");
        }

        [TestMethod]
        public void W072_ProductEditor_productTypesTreeView_edit()
        {
            // get productTypesTreeView and check it's visible
            TreeView productTypesTreeView =
                TestDriver.WidgetGet<TreeView>("ProductEditor.tabControl.productTypes.productTypesTreeView");

            // check there are 9 nodes total
            Assert.AreEqual(9, productTypesTreeView.Nodes.Length); // TODO: Firefox raises JavaScript error too much recursion

            // select TreeNode 5
            productTypesTreeView.SelectItem(5);
            TestDriver.Sleep(Waiter.BrowserUpdate);

            // check there is a TreeNode selected
            TreeNode[] selectedNodes = productTypesTreeView.WaitForSelectedNodes(1);
            Assert.AreEqual(1, selectedNodes.Length);

            // select TreeNode 5 and check it's label is "Washers/Dryer"
            TreeNode treeNode = selectedNodes[0];
            // select TreeNode 5 and check it's label is "Washers/Dryer"
            Qooxdoo.WebDriver.UI.Basic.Label label = treeNode.Label;
            Assert.AreEqual("Washers/Dryer", label.Text);

            // open ProductTypeEditor
            treeNode.Click();
            treeNode.Click();

            // get productTypeEditor and check it's visible
            Form productTypeEditor = TestDriver.WidgetGet<Form>("ProductTypeEditor");

            // change productTypeNameTextBox and wait until it's changed
            productTypeEditor.WidgetSetTextAssertSync("productTypeNameTextBox", "Washers+Dryers", "TextBox");

            if (CurrentBrowser == Browser.Edge)
                TestDriver.Sleep(Waiter.BrowserUpdate);

            // get saveButton, check it's visible and click it
            Button saveButton = productTypeEditor.WidgetGet<Button>("saveButton");
            saveButton.Click();

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // re-check TreeNode 5 value
            productTypesTreeView.SelectItem(5);
            TestDriver.Sleep(Waiter.BrowserUpdate);

            // check there is a TreeNode selected
            selectedNodes = productTypesTreeView.WaitForSelectedNodes(1);
            Assert.AreEqual(1, selectedNodes.Length);

            // select TreeNode 5 and check it's label is "Washers+Dryer"
            treeNode = selectedNodes[0];
            label = treeNode.Label;
            Assert.AreEqual("Washers+Dryers", label.Text);

            // give enough time so YOU can see the all the changes
            TestDriver.Sleep(Waiter.Duration);
        }

        [TestMethod]
        public void W074_ProductEditor_productTypesTreeView_new()
        {
            /*// get newButton, check it's visible and click it
            Button newButton = TestDriver.WidgetGet<Button>("ProductEditor.newButton");
            newButton.Click();

            // get brandNameTextBox and check it's visible
            TextBox brandNameTextBox = TestDriver.WidgetGet<TextBox>("BrandEditor.brandNameTextBox");
            brandNameTextBox.Value = "Huawei";
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
            Assert.AreEqual("Huawei", listItem.Value);

            // give enough time so YOU can see the all the changes
            TestDriver.Sleep(Waiter.Duration);*/
        }

        [TestMethod]
        public void W076_ProductEditor_productTypesTreeView_remove()
        {
            /*// get brands TabPage and check it's visible
            TabPage brands = TestDriver.WidgetGet<TabPage>("ProductEditor.tabControl.brands");

            // get brandsListBox and check it's visible
            ListBox brandsListBox = brands.WidgetGet<ListBox>("brandsListBox");

            brandsListBox.SelectItem(4);
            // get ListItem 4 and check it's visible
            ListItem listItem = brandsListBox.ListItems[4];
            // check ListItem 4 value
            Assert.AreEqual("LLG", listItem.Value);

            // get removeButton, check it's visible and click it
            Button removeButton = TestDriver.WidgetGet<Button>("ProductEditor.removeButton");
            removeButton.Click();

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // refresh and get brandsListBox and check it's visible
            brandsListBox = brands.WidgetRefresh<ListBox>("brandsListBox");

            // check there are 10 items total
            Assert.AreEqual(10, brandsListBox.ListItems.Count);

            // give enough time so YOU can see the all the changes
            TestDriver.Sleep(Waiter.Duration);*/
        }

        [TestMethod]
        public void W078_ProductEditor_tabControl_models()
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
            models.AssertIsDisplayed("models");

            // get modelsDataGridView and check it's visible
            DataGridView modelsDataGridView = models.WidgetGet<DataGridView>("modelsDataGridView");

            // select row 0
            modelsDataGridView.SelectRow(0);

            // check row 0 is selected
            int[] selectedIndices = modelsDataGridView.SelectedIndices;
            int selectedRow = selectedIndices[0];
            Assert.IsTrue(selectedIndices.Length == 1 && selectedRow == 0);
        }

        [TestMethod]
        public void W080_ProductEditor_tabControl_models_row0_Name()
        {
            // get modelsDataGridView and check it's visible
            DataGridView modelsDataGridView =
                TestDriver.WidgetGet<DataGridView>("ProductEditor.tabControl.models.modelsDataGridView");

            // check the "Name" column for row 0
            int selectedRow = modelsDataGridView.SelectedIndices[0];
            Assert.AreEqual("SMSTV 2020H", modelsDataGridView.GetCellText(1, selectedRow));

            // focus column 1 and check it's focused
            modelsDataGridView.FocusCellInColumn(1);
            Assert.AreEqual(1, modelsDataGridView.GetFocusedColumn());
            Assert.AreEqual(selectedRow, modelsDataGridView.GetFocusedRow());

            // get the cell editor for focused cell
            TextBox cellEditor = modelsDataGridView.CellEditorGet<TextBox>();
            Assert.IsNotNull(cellEditor);

            // check cell editor text
            cellEditor.AssertTextIs("SMSTV 2020H");

            // change the focused cell
            modelsDataGridView.CellSetTextAssertSync("ph fm208", "PH FM208", "TextBox");
        }

        [TestMethod]
        public void W082_ProductEditor_tabControl_models_row0_Brand()
        {
            // get modelsDataGridView and check it's visible
            DataGridView modelsDataGridView =
                TestDriver.WidgetGet<DataGridView>("ProductEditor.tabControl.models.modelsDataGridView");

            // check the brand for row 0
            int selectedRow = modelsDataGridView.SelectedIndices[0];
            Assert.AreEqual("Samsung", modelsDataGridView.GetCellText(2, selectedRow));

            modelsDataGridView.FocusCellInColumn(2);

            Assert.AreEqual(2, modelsDataGridView.GetFocusedColumn());
            Assert.AreEqual(selectedRow, modelsDataGridView.GetFocusedRow());

            // get the cell editor for current focused cell
            ComboBox cellEditor = modelsDataGridView.CellEditorGet<ComboBox>();
            Assert.IsNotNull(cellEditor);

            // check cell editor text
            cellEditor.AssertTextIs("Samsung");

            // edit brand
            cellEditor.SelectItem(5);
            modelsDataGridView.StopEditing();

            // check the brand changes
            const string brand = "Philips";
            Assert.AreEqual(brand, modelsDataGridView.WaitForCellText(brand));
        }

        [TestMethod]
        public void W084_ProductEditor_tabControl_models_row0_ProductType()
        {
            // get modelsDataGridView and check it's visible
            DataGridView modelsDataGridView =
                TestDriver.WidgetGet<DataGridView>("ProductEditor.tabControl.models.modelsDataGridView");

            // check the product type for row 0
            int selectedRow = modelsDataGridView.SelectedIndices[0];
            Assert.AreEqual("TV", modelsDataGridView.GetCellText(3, selectedRow));

            modelsDataGridView.FocusCellInColumn(3);

            Assert.AreEqual(3, modelsDataGridView.GetFocusedColumn());
            Assert.AreEqual(selectedRow, modelsDataGridView.GetFocusedRow());

            // get the cell editor for current focused cell
            ComboBox cellEditor = modelsDataGridView.CellEditorGet<ComboBox>();
            Assert.IsNotNull(cellEditor);

            // check cell editor text
            cellEditor.AssertTextIs("TV");

            // edit product type
            cellEditor.SelectItem(2);
            modelsDataGridView.StopEditing();

            // check the product type changes
            const string productType = "Radio";
            Assert.AreEqual(productType, modelsDataGridView.WaitForCellText(productType));
        }

        [TestMethod]
        public void W086_ProductEditor_tabControl_models_last_row_Name()
        {
            // get modelsDataGridView and check it's visible
            DataGridView modelsDataGridView =
                TestDriver.WidgetGet<DataGridView>("ProductEditor.tabControl.models.modelsDataGridView");

            // check cell text at column 1, row 11
            var cellText = modelsDataGridView.GetCellText(1, 11);
            Assert.AreEqual("TV 97016", cellText);

            // TODO: this does not change the TextBox
            /*// get the cell editor for current focused cell
            TextBox cellEditor = modelsDataGridView.CellEditorGet<TextBox>(cellText, 1, 11);
            Assert.IsNotNull(cellEditor);

            // edit model name
            cellEditor.Value = "SMSTV 97016";
            modelsDataGridView.StopEditing();*/

            // TODO: this way it works all right
            // focus column 1 and check it's focused
            modelsDataGridView.FocusCellInColumn(1);
            Assert.AreEqual(1, modelsDataGridView.GetFocusedColumn());

            // focus row 11 and check it's focused
            modelsDataGridView.FocusCellInRow(11);
            Assert.AreEqual(11, modelsDataGridView.GetFocusedRow());

            // get the cell editor for current focused cell
            TextBox cellEditor = modelsDataGridView.CellEditorGet<TextBox>();
            Assert.IsNotNull(cellEditor);

            // check cell editor text
            cellEditor.AssertTextIs("TV 97016");

            // edit name
            cellEditor.Value = "SMSTV 97016";
            modelsDataGridView.StopEditing();

            // check the model name changes
            const string name = "SMSTV 97016";
            Assert.AreEqual(name, modelsDataGridView.WaitForCellText(name));
        }

        [TestMethod]
        public void W094_CloseProductEditor()
        {
            // give enough time so YOU can see the open window
            TestDriver.Sleep(Waiter.Duration);

            // get ProductEditor and check it's visible
            Form productEditor = TestDriver.WidgetGet<Form>("ProductEditor");
            // close ProductEditor
            productEditor.Close();
            // check ProductEditor is closed
            productEditor.AssertIsDisposed("ProductEditor");
        }

        [TestMethod]
        public void W096_ButtonsWindow_supplierEditor_Click()
        {
            // click supplierEditor on buttonsPanel (LayoutPanel) of ButtonsWindow
            TestDriver.ButtonClick("ButtonsWindow.buttonsPanel.supplierEditor");

            // give enough time so YOU can see the alert boxes
            TestDriver.Sleep(Waiter.Duration);

            TestDriver.AlertBoxClose(MessageBoxIcon.Error, "Supplier Editor must be implemented");
            TestDriver.AlertBoxClose("Supplier Editor should be implemented");
            TestDriver.AlertBoxClose(MessageBoxIcon.Information);

            TestDriver.AlertBoxAssertNotExists(MessageBoxIcon.Error, "Supplier Editor must be implemented");
            TestDriver.AlertBoxAssertNotExists("Supplier Editor should be implemented");
            TestDriver.AlertBoxAssertNotExists(MessageBoxIcon.Information);
        }

        [TestMethod]
        public void W098_CloseButtonsWindow()
        {
            // give enough time so YOU can follow the windows closing
            //TestDriver.Sleep(Waiter.Duration);

            // close ButtonsWindow
            TestDriver.FormClose("ButtonsWindow");
        }

        [TestMethod]
        public void W100_AskQuitYes()
        {
            // click exit on MainPage (presume MainPage exists and is visible)
            TestDriver.ButtonClick("MainPage.exit");

            // click Yes on MessageBox
            TestDriver.MessageBoxButtonClick(DialogResult.Yes);

            // give enough time so YOU can see the root Page before the browser shows an empty screen
            TestDriver.Sleep(Waiter.Duration * 2);
        }
    }
}