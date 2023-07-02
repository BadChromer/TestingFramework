using Framework.BaseClasses;
using Framework.Models;
using Framework.Utilities;
using Framework.WebElements;
using OpenQA.Selenium;

namespace Framework.PageObjects
{
    public class WebTablesPage : BaseForm
    {
        private Button addRecordButton = new(
            By.Id("addNewRecordButton"), nameof(addRecordButton));
        private Button submitRecordButton = new(
            By.Id("submit"), nameof(submitRecordButton));
        private Button closeRegistrationFormButton = new(
            By.XPath("//span[@class='sr-only' and contains(text(), 'Close')]"),
            nameof(closeRegistrationFormButton));
        private Button deleteFirstUserRecordButton = new(
            By.Id("delete-record-4"), nameof(deleteFirstUserRecordButton));
        private Button deleteSecondUserRecordButton = new(
            By.Id("delete-record-5"), nameof(deleteSecondUserRecordButton));
        private TextField registrationForm = new(
            By.Id("registration-form-modal"), nameof(registrationForm));
        private TextField? tableEmailField;
        private Input firstNameInput = new(
            By.Id("firstName"), nameof(firstNameInput));
        private Input lastNameInput = new(
            By.Id("lastName"), nameof(lastNameInput));
        private Input userEmailInput = new(
            By.Id("userEmail"), nameof(userEmailInput));
        private Input ageInput = new(
            By.Id("age"), nameof(ageInput));
        private Input salaryInput = new(
            By.Id("salary"), nameof(salaryInput));
        private Input departmentInput = new(
            By.Id("department"), nameof(departmentInput));
        private Table tableContent = new(
            By.ClassName("rt-tr-group"), nameof(tableContent));
        private const int MIN_EMAIL_LENGTH = 6;
        public List<DataModel.UserData>? userTable;

        public WebTablesPage() : base(
            By.XPath("//div[@class='main-header' and contains(text(), 'Web Tables')]"),
            "Web Tables Page")
        {

        }

        public void GetTable()
        {
            userTable = new();
            foreach (var row in tableContent.GetElements())
            {
                var firstNameRow = row.FindElements(
                    By.ClassName("rt-td"))[0].GetAttribute("textContent");
                var lastNameRow = row.FindElements(
                    By.ClassName("rt-td"))[1].GetAttribute("textContent");
                var ageRow = row.FindElements(
                    By.ClassName("rt-td"))[2].GetAttribute("textContent");
                var emailRow = row.FindElements(
                    By.ClassName("rt-td"))[3].GetAttribute("textContent");
                var salaryRow = row.FindElements(
                    By.ClassName("rt-td"))[4].GetAttribute("textContent");
                var departmentRow = row.FindElements(
                    By.ClassName("rt-td"))[5].GetAttribute("textContent");
                if (emailRow.Length > MIN_EMAIL_LENGTH) // Check if row is not empty, couldn't find a better idea :D
                {
                    userTable.Add(new DataModel.UserData
                    {
                        firstName = firstNameRow,
                        lastName = lastNameRow,
                        age = int.Parse(ageRow),
                        email = emailRow,
                        salary = int.Parse(salaryRow),
                        department = departmentRow
                    });
                }
            }
        }

        public void ClickAddRecordButton()
        {
            addRecordButton.Click();
        }

        public void ClickSubmitRecordButton()
        {
            submitRecordButton.Click();
        }

        public void ClickCloseButton()
        {
            closeRegistrationFormButton.Click();
        }

        public void SendUserDataToForm()
        {
            foreach (var user in UserDataManager.userData)
            {
                ClickAddRecordButton();
                firstNameInput.SendText(user.firstName);
                lastNameInput.SendText(user.lastName);
                userEmailInput.SendText(user.email);
                ageInput.SendText($"{user.age}");
                salaryInput.SendText($"{user.salary}");
                departmentInput.SendText(user.department);
                ClickSubmitRecordButton();
            }
        }

        public bool CheckIfTableContainsUser()
        {
            try
            {
                foreach (var user in UserDataManager.userData)
                {
                    tableEmailField = new(
                        By.XPath($"//div[@class='rt-td' and contains(text(), '{user.email}')]"),
                        "tableEmailField");
                    if (user.email == tableEmailField.GetAttribute("textContent"))
                        return true;
                }
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ClickDeleteFirstUserRecord()
        {
            deleteFirstUserRecordButton.Click();
        }

        public void ClickDeleteSecondUserRecord()
        {
            deleteSecondUserRecordButton.Click();
        }

        public string GetFormName()
        {
            return registrationForm.GetAttribute("textContent");
        }
    }
}