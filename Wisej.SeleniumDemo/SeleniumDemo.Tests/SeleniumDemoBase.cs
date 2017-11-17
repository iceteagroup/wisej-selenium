using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Qooxdoo.WebDriver.UI;
using Wisej.Web.Ext.Selenium.Tests;
using Wisej.Web.Ext.Selenium.UI;

namespace SeleniumDemo.Tests
{
    public abstract class SeleniumDemoBase
    {
        protected static SeleniumDemoWebDriver TestDriver;
        protected static Browser CurrentBrowser;

        [TestMethod]
        public void W010_AskQuitNo()
        {
            /*TestDriver.SleepDebugTest(2000);

            // get MainPage
            Page mainPage = TestDriver.WidgetGet<Page>("Desktop.MainPage", 10);

            // click sayGoodBye on MainPage
            mainPage.ButtonClick("sayGoodBye", 10);

            var a = TestDriver.AlertBoxes;
            var m = TestDriver.MessageBoxes;

            TestDriver.SleepDebugTest();

            TestDriver.MessageBox.GetButton("Yes").Click();

            TestDriver.MessageBoxClick(DialogResult.No);*/
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

        /*[TestMethod]
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
        }*/

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
            firstName.Value = string.Empty; // TODO Value setter clears the TextBox
            firstName.SendKeys("Harry"); // TODO changes reach the server

            //if (CurrentBrowser == Browser.Edge)
            TestDriver.Sleep(Waiter.BrowserUpdate);

            // Save it
            customerEditor.ButtonClick("saveButton"); // TODO this triggers validation

            TestDriver.Sleep(Waiter.Duration);

            // TODO: this should work - changes should reach the server, but they don't
            firstName.Value = "Murk";
            //firstName.SendKeys("y"); // TODO uncomment this line and changes reach the server

            //if (CurrentBrowser == Browser.Edge)
            TestDriver.Sleep(Waiter.BrowserUpdate);

            // Save it
            customerEditor.ButtonClick("saveButton"); // TODO this triggers validation, but fullName doesn't change

            Label fullName = customerEditor.WidgetGet<Label>("fullName");
            var lastName = fullName.Text.Split(' ')[1];

            // check fullName for changed firstName
            fullName.AssertText("Murky " + lastName);
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
            lastName.Value = string.Empty; // TODO Value setter clears the TextBox
            lastName.SendKeys("potter"); // TODO changes reach the server

            // Save it
            customerEditor.ButtonClick("saveButton"); // TODO this triggers validation

            TestDriver.Sleep(Waiter.Duration);

            // TODO: this should work - changes should reach the server, but they don't
            lastName.Value = "matter";
            //lastName.SendKeys("s"); // TODO uncomment this line and changes reach the server

            //if (CurrentBrowser == Browser.Edge)
            TestDriver.Sleep(Waiter.BrowserUpdate);

            // Save it
            customerEditor.ButtonClick("saveButton"); // TODO this triggers validation, but fullName doesn't change

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
            state.AssertText("Mississippi");

            // change state
            state.SelectItem(9);

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
            // get CustomerEditor and check it's visible
            Form customerEditor = TestDriver.WidgetGet<Form>("CustomerEditor", 10);
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

            // get brands TabPage by label
            TabPage brands = tabControl.GetTabPage("Brands");

            // check brands exists and is visible
            Assert.IsNotNull(brands);
            brands.AssertIsDisplayed("brands");

            // get brandsList and check it's visible
            ListBox brandsList = brands.WidgetGet<ListBox>("brandsList", 10);
        }

        [TestMethod]
        public void W070_ProductEditor_tabControl_models()
        {
            // get tabControl and check it's visible
            TabControl tabControl = TestDriver.WidgetGet<TabControl>("ProductEditor.tabControl", 10);

            // select models TabPage by label
            tabControl.SelectItem("Models");

            TestDriver.Sleep(Waiter.BrowserUpdate);

            // get models TabPage by label
            TabPage models = tabControl.GetTabPage("Models");

            // check models exists and is visible
            Assert.IsNotNull(models);
            models.AssertIsDisplayed("models");

            // get modelsTree and check it's visible
            TreeView modelsTree = models.WidgetGet<TreeView>("modelsTree", 10);
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
            /*// click supplierEditor on buttonsPanel (LayoutPanel) of ButtonsWindow
            TestDriver.ButtonClick("ButtonsWindow.buttonsPanel.supplierEditor");

            TestDriver.AlertBoxClose(MessageBoxIcon.Error, "Supplier Editor must be implemented");
            TestDriver.AlertBoxClose("Supplier Editor should be implemented");
            TestDriver.AlertBoxClose(MessageBoxIcon.Information);*/
        }

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