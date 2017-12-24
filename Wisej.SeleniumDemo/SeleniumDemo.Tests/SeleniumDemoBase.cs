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
            Page mainPage = TestDriver.WidgetGet<Page>("MainPage", 10);

            // click exit on MainPage
            mainPage.ButtonClick("exit", 10);

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
            Page mainPage = TestDriver.WidgetGet<Page>("MainPage", 10);

            // click helper on ButtonsWindow
            mainPage.ButtonClick("helper");

            TestDriver.SleepDebugTest();

            // check HelperWindow exists and is visible
            Form helperWindow = TestDriver.WidgetGet<Form>("HelperWindow", 10);
        }

        [TestMethod]
        public void W021_ButtonsWindow_HelperWindow_ResetData_Click()
        {
            // get HelperWindow exists and is visible
            Form helperWindow = TestDriver.WidgetGet<Form>("HelperWindow", 10);

            // click resetData on HelperWindow
            helperWindow.ButtonClick("resetData");
        }

        [TestMethod]
        public void W022_HelperWindow_Minimize()
        {
            // give enough time so YOU can follow the window minimizing
            TestDriver.Sleep(Waiter.Duration);

            // get HelperWindow exists and is visible
            Form helperWindow = TestDriver.WidgetGet<Form>("HelperWindow", 10);

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
            Form helperWindow = TestDriver.WidgetGet<Form>("HelperWindow", 10, false);
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
            Page mainPage = TestDriver.WidgetGet<Page>("MainPage", 10);
            // click buttonsWindow on MainPage
            mainPage.ButtonClick("buttonsWindow");

            TestDriver.SleepDebugTest();

            // get ButtonsWindow and check it's visible
            Form buttonsWindow = TestDriver.WidgetGet<Form>("ButtonsWindow", 10);
        }

        [TestMethod]
        public void W040_ButtonsWindow_customerEditor_Click()
        {
            // give enough time so YOU can follow the windows closing
            TestDriver.Sleep(Waiter.Duration);

            // get ButtonsWindow and check it's visible
            Form buttonsWindow = TestDriver.WidgetGet<Form>("ButtonsWindow", 10);
            // get buttonsPanel
            Panel buttonsPanel = buttonsWindow.WidgetGet<Panel>("buttonsPanel");
            // click customerEditor on buttonsPanel
            buttonsPanel.ButtonClick("customerEditor");

            TestDriver.SleepDebugTest();

            // get CustomerEditor exists and is visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor", 10);
        }

        [TestMethod]
        public void W050_CustomerEditor_EditRegisterOne_firstName()
        {
            TestDriver.Sleep(Waiter.Duration);

            // get CustomerEditor exists and is visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor", 10);

            // get DataGridView
            DataGridView dataGridView = customerEditor.WidgetGet<DataGridView>("dataGridView");
            // check DataGridView has two rows
            Assert.IsTrue(dataGridView.RowCount == 2,
                string.Format("dataGridView row count: expected 2 and actual is {0}.", dataGridView.RowCount));

            TestDriver.SleepDebugTest();

            // get firstName TextBox
            TextBox firstName = customerEditor.WidgetGet<TextBox>("firstName");
            // check firstName
            firstName.AssertTextIs("Mudy");

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

            // change firstName
            firstName.Value = "Muddy";

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // Save it
            customerEditor.ButtonClick("saveButton");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            Label fullName = customerEditor.WidgetGet<Label>("fullName");
            var lastName = fullName.Text.Split(' ')[1];

            // check fullName for changed firstName
            fullName.AssertTextIs("Muddy " + lastName);
        }

        [TestMethod]
        public void W052_CustomerEditor_EditRegisterOne_lastName()
        {
            // get CustomerEditor and check it's visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor", 10);

            // get DataGridView
            DataGridView dataGridView = customerEditor.WidgetGet<DataGridView>("dataGridView");
            // check DataGridView has two rows
            Assert.IsTrue(dataGridView.RowCount == 2,
                string.Format("dataGridView row count: expected 2 and actual is {0}.", dataGridView.RowCount));

            // get lastName TextBox
            TextBox lastName = customerEditor.WidgetGet<TextBox>("lastName");
            // check lastName
            lastName.AssertTextIs("WATTERS");

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

            // change lastName
            lastName.Value = "waters";

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // Save it
            customerEditor.ButtonClick("saveButton");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            Label fullName = customerEditor.WidgetGet<Label>("fullName");
            var firstName = fullName.Text.Split(' ')[0];

            // check fullName for changed lastName
            fullName.AssertTextIs(firstName + " WATERS");
        }

        [TestMethod]
        public void W054_CustomerEditor_EditRegisterOne_state()
        {
            TestDriver.Sleep(Waiter.Duration);

            // get CustomerEditor and check it's visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor", 10);

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
            state.SelectItem(25);

            if (CurrentBrowser == Browser.Edge)
                TestDriver.Sleep(Waiter.BrowserUpdate);

            // Save it
            customerEditor.ButtonClick("saveButton");

            // check changed lastName
            state.AssertTextIs("Mississippi");

            TestDriver.Sleep(Waiter.Duration);
        }

        [TestMethod]
        public void W056_CustomerEditor_NewRegister()
        {
            // get CustomerEditor and check it's visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor", 10);
            // click newButton on CustomerEditor
            customerEditor.ButtonClick("newButton");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get a refreshed firstName TextBox
            TextBox firstName = customerEditor.WidgetRefresh<TextBox>("firstName");
            // check firstName is empty
            firstName.AssertTextIs(string.Empty);

            // insert firstName
            firstName.SendKeys("B. B.");

            if (CurrentBrowser == Browser.Edge)
                TestDriver.Sleep(Waiter.BrowserUpdate);

            // Save it
            customerEditor.ButtonClick("saveButton");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // check saved firstName
            firstName.AssertTextIs("B. B.");

            // get a refreshed lastName TextBox
            TextBox lastName = customerEditor.WidgetRefresh<TextBox>("lastName");
            // check lastName is empty
            lastName.AssertTextIs(string.Empty);

            // insert lastName
            lastName.SendKeys("king");

            if (CurrentBrowser == Browser.Edge)
                TestDriver.Sleep(Waiter.BrowserUpdate);

            // Save it
            customerEditor.ButtonClick("saveButton");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // check saved lastName
            lastName.AssertTextIs("KING");

            // get a refreshed state ComboBox
            ComboBox state = customerEditor.WidgetRefresh<ComboBox>("state");

            // change state
            state.SelectItem(20);

            if (CurrentBrowser == Browser.Edge)
                TestDriver.Sleep(Waiter.BrowserUpdate);

            customerEditor.ButtonClick("saveButton");
        }

        [TestMethod]
        public void W05_CustomerEditor_NavigateRows()
        {
            // get CustomerEditor and check it's visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor", 10);
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
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor", 10);
            // get DataGridView
            DataGridView dataGridView = customerEditor.WidgetGet<DataGridView>("dataGridView");
            // check DataGridView has three rows
            Assert.IsTrue(dataGridView.RowCount == 3,
                string.Format("dataGridView row count: expected 3 and actual is {0}.", dataGridView.RowCount));

            // select row 1 (with id 2)
            dataGridView.SelectRow(1);

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // check row 1 is selected
            int[] selectedIndices = dataGridView.SelectedIndices;
            int selectedRow = selectedIndices[0];
            Assert.IsTrue(selectedIndices.Length == 1 && selectedRow == 1);

            // check the id column of row 1
            Assert.AreEqual("2", dataGridView.GetCellText(0, selectedRow));
            // check id label
            Label id = customerEditor.WidgetGet<Label>("id");
            id.AssertTextIs("2");

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
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor", 10);
            // close customerEditor
            customerEditor.Close();
            // check customerEditor is closed
            customerEditor.AssertIsDisposed("CustomerEditor");
        }

        [TestMethod]
        public void W064_ButtonsWindow_productEditor_Click()
        {
            // get ButtonsWindow and check it's visible
            Form buttonsWindow = TestDriver.WidgetGet<Form>("ButtonsWindow", 10);
            // get buttonsPanel
            Panel buttonsPanel = buttonsWindow.WidgetGet<Panel>("buttonsPanel");
            // click productEditor on buttonsPanel
            buttonsPanel.ButtonClick("productEditor");

            TestDriver.SleepDebugTest();

            // check ProductEditor exists and is visible
            Form productEditor = TestDriver.WidgetGet<Form>("ProductEditor", 10);
        }

        [TestMethod]
        public void W065_ProductEditor_tabControl()
        {
            // get tabControl and check it's visible
            TabControl tabControl = TestDriver.WidgetGet<TabControl>("ProductEditor.tabControl", 10);
        }

        [TestMethod]
        public void W066_ProductEditor_tabControl_brands()
        {
            // get tabControl and check it's visible
            TabControl tabControl = TestDriver.WidgetGet<TabControl>("ProductEditor.tabControl", 10);

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
            ListBox brandsListBox = TestDriver.WidgetGet<ListBox>("ProductEditor.tabControl.brands.brandsListBox", 10);

            // check there are 9 items total
            Assert.AreEqual(9, brandsListBox.ListItems.Count);

            // check there is an item selected
            IList<ListItem> selectedItems = brandsListBox.SelectedItems;
            Assert.AreEqual(1, selectedItems.Count);
            // check item selected is "Candy"
            ListItem listItem = selectedItems[0];
            // TODO: pending fix in this property
            //Assert.IsTrue(listItem.Selected);
            Assert.AreEqual("Candy", listItem.Value);

            brandsListBox.SelectItem(1);
            // check there is an item selected
            selectedItems = brandsListBox.SelectedItems;
            Assert.AreEqual(1, selectedItems.Count);
            // check item selected is "Electroluz"
            listItem = selectedItems[0]; // TODO: always item 0 (zero)
            listItem = brandsListBox.ListItems[1]; // workaround for above issue
            // TODO: pending fix in this property
            //Assert.IsTrue(listItem.Selected);
            Assert.AreEqual("Electroluz", listItem.Value);
            // open BrandEditor
            listItem.DoubleClick();

            TestDriver.SleepDebugTest();
            TestDriver.SleepDebugTest();

            // get BrandEditor and check it's visible
            Form brandEditor = TestDriver.WidgetGet<Form>("BrandEditor", 20);
            // get brandNameTextBox and check it's visible
            TextBox brandNameTextBox = brandEditor.WidgetGet<TextBox>("brandNameTextBox");
            brandNameTextBox.Value = "Electrolux";
            // get saveButton, check it's visible and click it
            Button saveButton = brandEditor.WidgetGet<Button>("saveButton");
            saveButton.Click();

            // re-check ListItem 1 value
            Assert.AreEqual("Electrolux", listItem.Value);

            // give enough time so YOU can see the all the changes
            TestDriver.Sleep(Waiter.Duration);
        }

        [TestMethod]
        public void W068_ProductEditor_brandsListBox_new()
        {
            // get newButton, check it's visible and click it
            Button newButton = TestDriver.WidgetGet<Button>("ProductEditor.newButton");
            newButton.Click();

            TestDriver.SleepDebugTest();
            TestDriver.SleepDebugTest();

            // get brandNameTextBox and check it's visible
            TextBox brandNameTextBox = TestDriver.WidgetGet<TextBox>("BrandEditor.brandNameTextBox");
            brandNameTextBox.Value = "Huawei";
            // get saveButton, check it's visible and click it
            Button saveButton = TestDriver.WidgetGet<Button>("BrandEditor.saveButton");
            saveButton.Click();

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // refresh and get brandsListBox and check it's visible
            ListBox brandsListBox =
                TestDriver.WidgetRefresh<ListBox>("ProductEditor.tabControl.brands.brandsListBox", 10);

            // check there are 10 items total
            Assert.AreEqual(10, brandsListBox.ListItems.Count);

            // get ListItem 9 and check it's visible
            ListItem listItem = brandsListBox.ListItems[9];
            // check ListItem 9 value
            Assert.AreEqual("Huawei", listItem.Value);

            // give enough time so YOU can see the all the changes
            TestDriver.Sleep(Waiter.Duration);
        }

        [TestMethod]
        public void W069_ProductEditor_brandsListBox_remove()
        {
            // get brands TabPage and check it's visible
            TabPage brands = TestDriver.WidgetGet<TabPage>("ProductEditor.tabControl.brands", 20);

            // get brandsListBox and check it's visible
            ListBox brandsListBox = brands.WidgetGet<ListBox>("brandsListBox", 10);

            brandsListBox.SelectItem(4);
            // get ListItem 4 and check it's visible
            ListItem listItem = brandsListBox.ListItems[4];
            // check ListItem 4 value
            Assert.AreEqual("LG", listItem.Value);

            // get removeButton, check it's visible and click it
            Button removeButton = TestDriver.WidgetGet<Button>("ProductEditor.removeButton");
            removeButton.Click();

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // refresh and get brandsListBox and check it's visible
            brandsListBox = brands.WidgetRefresh<ListBox>("brandsListBox", 10);

            // check there are 9 items total
            Assert.AreEqual(9, brandsListBox.ListItems.Count);

            // give enough time so YOU can see the all the changes
            TestDriver.Sleep(Waiter.Duration);
        }

        [TestMethod]
        public void W070_ProductEditor_tabControl_productTypes()
        {
            // get tabControl and check it's visible
            TabControl tabControl = TestDriver.WidgetGet<TabControl>("ProductEditor.tabControl", 10);

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
                TestDriver.WidgetGet<TreeView>("ProductEditor.tabControl.productTypes.productTypesTreeView", 10);

            /*// check there is an item selected
            IList<TreeNode> selectedItems = productTypesTreeView.SelectedItems;
            Assert.AreEqual(1, selectedItems.Count);
            // check item selected is "Candy"
            TreeNode treeNode = selectedItems[0];
            // TODO: pending fix in this property
            //Assert.IsTrue(treeNode.Selected);
            Assert.AreEqual("Candy", treeNode.Value);

            productTypesTreeView.SelectItem(1);
            // check there is an item selected
            selectedItems = productTypesTreeView.SelectedItems;
            Assert.AreEqual(1, selectedItems.Count);
            // check item selected is "Electroluz"
            treeNode = selectedItems[0]; // TODO: always item 0 (zero)
            treeNode = productTypesTreeView.TreeNodes[1]; // workaround for above issue
            // TODO: pending fix in this property
            //Assert.IsTrue(treeNode.Selected);
            Assert.AreEqual("Electroluz", treeNode.Value);
            // open ProductTypeEditor
            treeNode.DoubleClick();

            TestDriver.SleepDebugTest();

            // get ProductTypeEditor and check it's visible
            Form productTypeEditor = TestDriver.WidgetGet<Form>("ProductTypeEditor", 20);
            // get productTypeNameTextBox and check it's visible
            TextBox productTypeNameTextBox = productTypeEditor.WidgetGet<TextBox>("productTypeNameTextBox");
            productTypeNameTextBox.Value = "Electrolux";
            // get saveButton, check it's visible and click it
            Button saveButton = productTypeEditor.WidgetGet<Button>("saveButton");
            saveButton.Click();

            // re-check TreeNode 1 value
            Assert.AreEqual("Electrolux", treeNode.Value);*/

            // give enough time so YOU can see the all the changes
            TestDriver.Sleep(Waiter.Duration);
        }

        [TestMethod]
        public void W074_ProductEditor_productTypesTreeView_new()
        {
        }

        [TestMethod]
        public void W076_ProductEditor_productTypesTreeView_remove()
        {
        }

        [TestMethod]
        public void W078_ProductEditor_tabControl_models()
        {
            // get tabControl and check it's visible
            TabControl tabControl = TestDriver.WidgetGet<TabControl>("ProductEditor.tabControl", 10);

            // select models TabPage by label
            tabControl.SelectItem("Models");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get models TabPage
            var models = tabControl.Current;

            // check models exists and is visible
            Assert.IsNotNull(models);
            models.AssertIsDisplayed("models");

            // get modelsDataGridView and check it's visible
            DataGridView modelsDataGridView = models.WidgetGet<DataGridView>("modelsDataGridView", 10);

            // select row 0
            modelsDataGridView.SelectRow(0);

            // check row 0 is selected
            int[] selectedIndices = modelsDataGridView.SelectedIndices;
            int selectedRow = selectedIndices[0];
            Assert.IsTrue(selectedIndices.Length == 1 && selectedRow == 0);

            // check the model name for row 0
            Assert.AreEqual("TV 97016", modelsDataGridView.GetCellText(1, selectedRow));

            // get a cell editor for column 1 of the selected row
            var isEditing = modelsDataGridView.StartEditing("TV 97016", 1, selectedRow);
            Assert.IsTrue(isEditing);
            var cellEditor = modelsDataGridView.CellEditor;
            Assert.IsNotNull(cellEditor);
        }

        [TestMethod]
        public void W080_CloseProductEditor()
        {
            // give enough time so YOU can see the open window
            TestDriver.Sleep(Waiter.Duration);

            // get ProductEditor and check it's visible
            Form productEditor = TestDriver.WidgetGet<Form>("ProductEditor", 10);
            // close ProductEditor
            productEditor.Close();
            // check ProductEditor is closed
            productEditor.AssertIsDisposed("ProductEditor");
        }

        [TestMethod]
        public void W088_ButtonsWindow_supplierEditor_Click()
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
        public void W090_CloseButtonsWindow()
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