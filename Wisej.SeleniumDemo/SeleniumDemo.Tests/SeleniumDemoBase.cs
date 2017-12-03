using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Wisej.Web.Ext.Selenium;
using Wisej.Web.Ext.Selenium.Tests;
using Wisej.Web.Ext.Selenium.UI;
using By = Qooxdoo.WebDriver.By;

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

            // get MainPage and check it's visibble
            Page mainPage = TestDriver.WidgetGet<Page>("MainPage", 10);

            // click sayGoodBye on MainPage
            mainPage.ButtonClick("sayGoodBye", 10);

            var title = "Polite Question";
            var message = "Do you want to say good-bye now?";
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
            // get MainPage and check it's visibble
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

            if (CurrentBrowser == Browser.Edge)
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
            // get CustomerEditor anc check it's visible
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
            // check DataGridView has two rows
            Assert.IsTrue(dataGridView.RowCount == 3,
                string.Format("dataGridView row count: expected 3 and actual is {0}.", dataGridView.RowCount));

            // check row 0 is selected
            int selectedRow = -1;
            for (int row = 0; row < dataGridView.RowCount; row++)
            {
                if (dataGridView.Children[row].Selected) // TODO This should return a row...
                    selectedRow = row;
            }
            Assert.AreEqual(selectedRow, 0);

            // select row 1
            dataGridView.SendKeys(Keys.ArrowDown);
            // check row 2 is selected
            selectedRow = -1;
            for (int row = 0; row < dataGridView.RowCount; row++)
            {
                if (dataGridView.Children[row].Selected) // TODO This should return a row...
                    selectedRow = row;
            }
            Assert.AreEqual(selectedRow, 1);

            // select row 2
            dataGridView.SelectRow(2);
            // check row 2 is selected
            selectedRow = -1;
            for (int row = 0; row < dataGridView.RowCount; row++)
            {
                if (dataGridView.Children[row].Selected) // TODO This should return a row...
                    selectedRow = row;
            }
            Assert.AreEqual(selectedRow, 2);
        }

        [TestMethod]
        public void W060_CustomerEditor_RemoveRows()
        {
            // get CustomerEditor and check it's visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor", 10);
            // get DataGridView
            DataGridView dataGridView = customerEditor.WidgetGet<DataGridView>("dataGridView");
            // check DataGridView has two rows
            Assert.IsTrue(dataGridView.RowCount == 3,
                string.Format("dataGridView row count: expected 3 and actual is {0}.", dataGridView.RowCount));


            // select row with id 2
            dataGridView.SelectRow(1);
            // check id
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
        public void W066_ProductEditor_tabControl()
        {
            // get tabControl and check it's visible
            TabControl tabControl = TestDriver.WidgetGet<TabControl>("ProductEditor.tabControl", 10);
        }

        [TestMethod]
        public void W068_ProductEditor_tabControl_brands()
        {
            // get tabControl and check it's visible
            TabControl tabControl = TestDriver.WidgetGet<TabControl>("ProductEditor.tabControl", 10);

            // select brands TabPage by label
            tabControl.SelectItem("Brands");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            var brands = tabControl.Current;

            // check brands exists and is visible
            Assert.IsNotNull(brands);
            brands.AssertIsDisplayed("brands");

            // get brandsListBox and check it's visible
            ListBox brandsListBox = brands.WidgetGet<ListBox>("brandsListBox", 10);
        }

        [TestMethod]
        public void W070_ProductEditor_tabControl_productTypes()
        {
            // get tabControl and check it's visible
            TabControl tabControl = TestDriver.WidgetGet<TabControl>("ProductEditor.tabControl", 10);

            // select models TabPage by label
            tabControl.SelectItem("Product Types");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            var models = tabControl.Current;

            // check models exists and is visible
            Assert.IsNotNull(models);
            models.AssertIsDisplayed("productTypes");

            // get productTypesTreeView and check it's visible
            TreeView productTypesTreeView = models.WidgetGet<TreeView>("productTypesTreeView", 10);
        }

        [TestMethod]
        public void W072_ProductEditor_tabControl_models()
        {
            // get tabControl and check it's visible
            TabControl tabControl = TestDriver.WidgetGet<TabControl>("ProductEditor.tabControl", 10);

            // select models TabPage by label
            tabControl.SelectItem("Models");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            var models = tabControl.Current;

            // check models exists and is visible
            Assert.IsNotNull(models);
            models.AssertIsDisplayed("models");

            // get modelsDataGridView and check it's visible
            DataGridView modelsDataGridView = models.WidgetGet<DataGridView>("modelsDataGridView", 10);
        }

        [TestMethod]
        public void W074_CloseProductEditor()
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
        public void W080_ButtonsWindow_supplierEditor_Click()
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
            // click sayGoodBye on MainPage (presume MainPage exists and is visible)
            TestDriver.ButtonClick("MainPage.sayGoodBye");

            // click Yes on MessageBox
            TestDriver.MessageBoxButtonClick(DialogResult.Yes);

            // give enough time so YOU can see the root Page before the browser shows an empty screen
            TestDriver.Sleep(Waiter.Duration * 2);
        }
    }
}