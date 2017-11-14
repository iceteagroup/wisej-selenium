using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Wisej.Web.Ext.Selenium.Tests;
using Wisej.Web.Ext.Selenium.UI;

namespace SeleniumDemo.Tests
{
    public abstract class SeleniumDemoBase
    {
        protected static SeleniumDemoWebDriver TestDriver;
        protected static Browser CurrentBrowser;

        /*[TestMethod]
        public void W010_AskQuitNo()
        {
            TestDriver.SleepDebugTest(2000);

            // get MainPage
            Page mainPage = TestDriver.WidgetGet<Page>("MainPage", 10);

            // click sayGoodBye on MainPage
            mainPage.ButtonClick("sayGoodBye", 10);

            TestDriver.SleepDebugTest();

            TestDriver.MessageBoxClick(DialogResult.No);
        }*/

        [TestMethod]
        public void W020_ButtonsWindow_helper_Click()
        {
            // get MainPage
            Page mainPage = TestDriver.WidgetGet<Page>("MainPage", 10);

            // click helper on ButtonsWindow
            mainPage.ButtonClick("helper");

            TestDriver.SleepDebugTest();

            // get HelperWindow exists
            Form helperWindow = TestDriver.WidgetGet<Form>("HelperWindow", 10);
            Assert.IsNotNull(helperWindow);
            // check HelperWindow is visible
            helperWindow.AssertIsDisplayed("HelperWindow");
        }

        [TestMethod]
        public void W021_ButtonsWindow_HelperWindow_ResetData_Click()
        {
            // get HelperWindow exists
            Form helperWindow = TestDriver.WidgetGet<Form>("HelperWindow", 10);
            // check HelperWindow is visible
            helperWindow.AssertIsDisplayed("HelperWindow");

            // click resetData on HelperWindow
            helperWindow.ButtonClick("resetData");
        }

        /*[TestMethod]
        public void W022_HelperWindow_Minimize()
        {
            // give enough time so YOU can follow the window minimizing
            TestDriver.Sleep(Waiter.Duration);

            // get HelperWindow exists
            Form helperWindow = TestDriver.WidgetGet<Form>("HelperWindow", 10);
            // check HelperWindow is visible
            helperWindow.AssertIsDisplayed("HelperWindow");

            helperWindow.Minimize();
            // check HelperWindow is not visible
            helperWindow.AssertIsNotDisplayed("HelperWindow");
        }

        [TestMethod]
        public void W024_HelperWindow_Restore()
        {
            // give enough time so YOU can follow the minimized window restoring
            TestDriver.Sleep(Waiter.Duration);

            // get HelperWindow exists
            Form helperWindow = TestDriver.WidgetGet<Form>("HelperWindow", 10);
            // check HelperWindow is not visible
            helperWindow.AssertIsNotDisplayed("HelperWindow");

            helperWindow.Restore();
            // check HelperWindow is visible
            helperWindow.AssertIsDisplayed("HelperWindow");
        }*/

        [TestMethod]
        public void W030_MainPage_buttonsWindow_Click()
        {
            // get MainPage
            Page mainPage = TestDriver.WidgetGet<Page>("MainPage", 10);
            // click buttonsWindow on MainPage
            mainPage.ButtonClick("buttonsWindow");

            TestDriver.SleepDebugTest();

            // get ButtonsWindow
            Form buttonsWindow = TestDriver.WidgetGet<Form>("ButtonsWindow", 10);
            Assert.IsNotNull(buttonsWindow);
            // check ButtonsWindow is visible
            buttonsWindow.AssertIsDisplayed("ButtonsWindow");
        }

        [TestMethod]
        public void W040_ButtonsWindow_customerEditor_Click()
        {
            // give enough time so YOU can follow the windows closing
            TestDriver.Sleep(Waiter.Duration);

            // get ButtonsWindow
            Form buttonsWindow = TestDriver.WidgetGet<Form>("ButtonsWindow", 10);
            // check ButtonsWindow is visible
            buttonsWindow.AssertIsDisplayed("ButtonsWindow");
            // get buttonsPanel
            Panel buttonsPanel = buttonsWindow.WidgetGet<Panel>("buttonsPanel");
            // click customerEditor on buttonsPanel
            buttonsPanel.ButtonClick("customerEditor");

            TestDriver.SleepDebugTest();

            // get CustomerEditor exists
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor", 10);
            Assert.IsNotNull(customerEditor);
            // check CustomerEditor is visible
            customerEditor.AssertIsDisplayed("CustomerEditor");
        }

        [TestMethod]
        public void W050_CustomerEditor_EditRegisterOne_firstName()
        {
            TestDriver.Sleep(Waiter.Duration);

            // get CustomerEditor exists
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor", 10);
            // check CustomerEditor is visible
            customerEditor.AssertIsDisplayed("CustomerEditor");

            // get DataGridView
            DataGridView dataGridView = customerEditor.WidgetGet<DataGridView>("dataGridView");
            // check DataGridView has two rows
            Assert.IsTrue(dataGridView.RowCount == 2,
                string.Format("dataGridView row count: expected 2 and actual is {0}.", dataGridView.RowCount));

            TestDriver.SleepDebugTest();

            // get firstName TextBox
            TextBox firstName = customerEditor.WidgetGet<TextBox>("firstName");
            // check firstName
            firstName.AssertText("Muddy");

            /*// THIS DOES NOT WORK RELIABLY
            // set focus on firstName
            firstName.SendKeys("");
            // clear firstName - beware Edge and Firefox are picky about actions
            Actions action = new Actions(TestDriver.WebDriver);
            action.KeyDown(Keys.Shift).SendKeys(Keys.Home).KeyUp(Keys.Shift).SendKeys(Keys.Delete).Perform();

            // check firstName is empty
            firstName.AssertText(string.Empty);

            // move back so firstName looses the focus
            firstName.SendKeys(Keys.Shift + Keys.Tab);

            // change firstName
            firstName.SendKeys("Murky");*/

            // change firstName
            //firstName.TextBoxClear();
            // TODO: this should work
            firstName.Value = "Murky";

            //if (CurrentBrowser == Browser.Edge)
            TestDriver.Sleep(Waiter.BrowserUpdate);

            // Save it
            customerEditor.ButtonClick("saveButton");

            Label fullName = customerEditor.WidgetGet<Label>("fullName");
            var lastName = fullName.Text.Split(' ')[1];

            // check fullName for changed firstName
            fullName.AssertText("Murky " + lastName);
        }

        [TestMethod]
        public void W052_CustomerEditor_EditRegisterOne_lastName()
        {
            // get CustomerEditor exists
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor", 10);
            // check CustomerEditor is visible
            customerEditor.AssertIsDisplayed("CustomerEditor");

            // get DataGridView
            DataGridView dataGridView = customerEditor.WidgetGet<DataGridView>("dataGridView");
            // check DataGridView has two rows
            Assert.IsTrue(dataGridView.RowCount == 2,
                string.Format("dataGridView row count: expected 2 and actual is {0}.", dataGridView.RowCount));

            // get lastName TextBox
            TextBox lastName = customerEditor.WidgetGet<TextBox>("lastName");
            // check lastName
            lastName.AssertText("WATERS");

            /*// THIS DOES NOT WORK RELIABLY
            // set focus on lastName
            lastName.SendKeys("");
            // clear lastName - beware Edge and Firefox are picky about actions
            Actions action = new Actions(TestDriver.WebDriver);
            action.KeyDown(Keys.Shift).SendKeys(Keys.Home).KeyUp(Keys.Shift).SendKeys(Keys.Delete).Perform();

            // check lastName is empty
            lastName.AssertText(string.Empty);

            // move back so lastName looses the focus
            lastName.SendKeys(Keys.Shift + Keys.Tab);

            // change lastName
            lastName.SendKeys("matters");*/

            // change lastName
            //lastName.TextBoxClear();
            // TODO: this should work
            lastName.Value = "matters";

            //if (CurrentBrowser == Browser.Edge)
            TestDriver.Sleep(Waiter.BrowserUpdate);

            // Save it
            customerEditor.ButtonClick("saveButton");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            Label fullName = customerEditor.WidgetGet<Label>("fullName");
            var firstName = fullName.Text.Split(' ')[0];

            // check fullName for changed lastName
            fullName.AssertText(firstName + " MATTERS");
        }

        [TestMethod]
        public void W054_CustomerEditor_EditRegisterOne_state()
        {
            TestDriver.Sleep(Waiter.Duration);

            // get CustomerEditor exists
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor", 10);
            // check CustomerEditor is visible
            customerEditor.AssertIsDisplayed("CustomerEditor");

            // get DataGridView
            DataGridView dataGridView = customerEditor.WidgetGet<DataGridView>("dataGridView");
            // check DataGridView has two rows
            Assert.IsTrue(dataGridView.RowCount == 2,
                string.Format("dataGridView row count: expected 2 and actual is {0}.", dataGridView.RowCount));

            // get state ComboBox
            ComboBox state = customerEditor.WidgetGet<ComboBox>("state");
            // check state
            state.AssertText("Mississippi");

            // change state
            // TODO: this should work
            var a = state.GetSelectableItem(10);
            state.SelectItem(10);

            if (CurrentBrowser == Browser.Edge)
                TestDriver.Sleep(Waiter.BrowserUpdate);

            // Save it
            customerEditor.ButtonClick("saveButton");

            // check changed lastName
            state.AssertText("Florida");

            TestDriver.Sleep(Waiter.Duration);
        }

        [TestMethod]
        public void W056_CustomerEditor_NewRegister()
        {
            // get CustomerEditor exists
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor", 10);
            // check CustomerEditor is visible
            customerEditor.AssertIsDisplayed("CustomerEditor");
            // click newButton on CustomerEditor
            customerEditor.ButtonClick("newButton");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get a refreshed firstName TextBox
            TextBox firstName = customerEditor.WidgetRefresh<TextBox>("firstName");
            // check firstName is empty
            firstName.AssertText(string.Empty);

            // insert firstName
            firstName.SendKeys("B. B.");

            if (CurrentBrowser == Browser.Edge)
                TestDriver.Sleep(Waiter.BrowserUpdate);

            // Save it
            customerEditor.ButtonClick("saveButton");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // check saved firstName
            firstName.AssertText("B. B.");

            // get a refreshed lastName TextBox
            TextBox lastName = customerEditor.WidgetRefresh<TextBox>("lastName");
            // check lastName is empty
            lastName.AssertText(string.Empty);

            // insert lastName
            lastName.SendKeys("king");

            if (CurrentBrowser == Browser.Edge)
                TestDriver.Sleep(Waiter.BrowserUpdate);

            // Save it
            customerEditor.ButtonClick("saveButton");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // check saved lastName
            lastName.AssertText("KING");

            // get a refreshed state ComboBox
            ComboBox state = customerEditor.WidgetRefresh<ComboBox>("state");

            if (CurrentBrowser == Browser.Edge)
                TestDriver.Sleep(Waiter.BrowserUpdate);

            customerEditor.ButtonClick("saveButton");
        }

        [TestMethod]
        public void W05_CustomerEditor_NavigateRows()
        {
            // get CustomerEditor exists
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor", 10);
            // check CustomerEditor is visible
            customerEditor.AssertIsDisplayed("CustomerEditor");
            // get DataGridView
            DataGridView dataGridView = customerEditor.WidgetGet<DataGridView>("dataGridView");
            // check DataGridView has two rows
            Assert.IsTrue(dataGridView.RowCount == 3,
                string.Format("dataGridView row count: expected 3 and actual is {0}.", dataGridView.RowCount));
        }

        /*[TestMethod]
        public void W060_CustomerEditor_RemoveRows()
        {
            // get CustomerEditor exists
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor", 10);
            // check CustomerEditor is visible
            customerEditor.AssertIsDisplayed("CustomerEditor");
            // get DataGridView
            DataGridView dataGridView = customerEditor.WidgetGet<DataGridView>("dataGridView");
            // check DataGridView has two rows
            Assert.IsTrue(dataGridView.RowCount == 3,
                string.Format("dataGridView row count: expected 3 and actual is {0}.", dataGridView.RowCount));
        }*/

        [TestMethod]
        public void W062_CloseCustomerEditors()
        {
            // give enough time so YOU can see the open window
            TestDriver.Sleep(Waiter.Duration);

            // get CustomerEditor
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor", 10);
            // check CustomerEditor is visible
            customerEditor.AssertIsDisplayed("CustomerEditor");
            // close customerEditor
            customerEditor.Close();
            // check customerEditor is closed
            customerEditor.AssertIsDisposed("CustomerEditor");
        }

        [TestMethod]
        public void W064_ButtonsWindow_productEditor_Click()
        {
            // get ButtonsWindow
            Form buttonsWindow = TestDriver.WidgetGet<Form>("ButtonsWindow", 10);
            // check ButtonsWindow is visible
            buttonsWindow.AssertIsDisplayed("ButtonsWindow");
            // get buttonsPanel
            Panel buttonsPanel = buttonsWindow.WidgetGet<Panel>("buttonsPanel");
            // click productEditor on buttonsPanel
            buttonsPanel.ButtonClick("productEditor");

            TestDriver.SleepDebugTest();

            // get ProductEditor exists
            Form productEditor = TestDriver.WidgetGet<Form>("ProductEditor", 10);
            Assert.IsNotNull(productEditor);
            // check ProductEditor is visible
            productEditor.AssertIsDisplayed("ProductEditor");
        }

        [TestMethod]
        public void W066_ProductEditor_tabControl()
        {
            // get tabControl
            TabControl tabControl = TestDriver.WidgetGet<TabControl>("ProductEditor.tabControl", 10);
            Assert.IsNotNull(tabControl);
            // check tabControl is visible
            tabControl.AssertIsDisplayed("tabControl");
        }

        [TestMethod]
        public void W068_ProductEditor_tabControl_brands()
        {
            // get tabControl
            TabControl tabControl = TestDriver.WidgetGet<TabControl>("ProductEditor.tabControl", 10);
            // check tabControl is visible
            tabControl.AssertIsDisplayed("tabControl");

            // select brands
            tabControl.SelectItem("brands");

            TestDriver.Sleep(Waiter.BrowserUpdate);
            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get brands
            //TabPage brands = (TabPage) tabControl.Children[0];
            // TODO: this should work
            TabPage brands = tabControl.WidgetGet<TabPage>("brands", 10);
            // check brands is visible
            tabControl.AssertIsDisplayed("brands");

            // get brandsList
            //ListBox brandsList = (ListBox) brands.Children[0];
            // TODO: this should work
            ListBox brandsList = brands.WidgetGet<ListBox>("brandsList", 10);
            Assert.IsNotNull(brandsList);
            // check brandsList is visible
            tabControl.AssertIsDisplayed("brandsList");
        }

        [TestMethod]
        public void W070_ProductEditor_tabControl_models()
        {
            // get tabControl
            TabControl tabControl = TestDriver.WidgetGet<TabControl>("ProductEditor.tabControl", 10);
            // check tabControl is visible
            tabControl.AssertIsDisplayed("tabControl");

            // select models
            tabControl.SelectItem("models");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get models
            TabPage models = tabControl.WidgetGet<TabPage>("models", 10);
            // check models is visible
            tabControl.AssertIsDisplayed("models");

            // get modelsTree
            TreeView modelsTree = models.WidgetGet<TreeView>("modelsTree", 10);
            Assert.IsNotNull(modelsTree);
            // check modelsTree is visible
            tabControl.AssertIsDisplayed("modelsTree");
        }

        [TestMethod]
        public void W074_CloseProductEditor()
        {
            // give enough time so YOU can see the open window
            TestDriver.Sleep(Waiter.Duration);

            // get ProductEditor
            Form productEditor = TestDriver.WidgetGet<Form>("ProductEditor", 10);
            // check ProductEditor is visible
            productEditor.AssertIsDisplayed("ProductEditor");
            // close ProductEditor
            productEditor.Close();
            // check ProductEditor is closed
            productEditor.AssertIsDisposed("ProductEditor");
        }

        /*[TestMethod]
        public void W080_ButtonsWindow_supplierEditor_Click()
        {
            // click supplierEditor on buttonsPanel (LayoutPanel) of ButtonsWindow
            TestDriver.ButtonClick("ButtonsWindow.buttonsPanel.supplierEditor");

            TestDriver.AlertBoxClose(MessageBoxIcon.Error, "Supplier Editor must be implemented");
            TestDriver.AlertBoxClose("Supplier Editor should be implemented");
            TestDriver.AlertBoxClose(MessageBoxIcon.Information);
        }*/

        [TestMethod]
        public void W090_CloseButtonsWindow()
        {
            // give enough time so YOU can follow the windows closing
            TestDriver.Sleep(Waiter.Duration);

            // close ButtonsWindow
            TestDriver.FormClose("ButtonsWindow");

            // give enough time so YOU can see all windows are closed
            TestDriver.Sleep(Waiter.Duration);
        }

        [TestMethod]
        public void W100_AskQuitYes()
        {
            // click sayGoodBye on MainPage
            TestDriver.ButtonClick("MainPage.sayGoodBye");

            TestDriver.SleepDebugTest();

            TestDriver.MessageBoxClick(DialogResult.Yes);

            // give enough time so YOU can see the root Page before the browser shows an empty screen
            TestDriver.Sleep(Waiter.Duration * 2);
        }
    }
}