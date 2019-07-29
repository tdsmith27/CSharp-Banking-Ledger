# CSharp-Banking-Ledger
This is my banking ledger console application. This program was written in C# and was developed using the .NET Core SDK and will require .NET to run. To install the .NET Core SDK, go [here](https://dotnet.microsoft.com/download).
#### This Application allows a user to
* Create a new account
* Login
* Record a deposit
* Record a withdrawal
* Check account balance
* View account transaction history
* Log out


## Instructions for use   
1. Navigate to [repo](https://github.com/tdsmith27/CSharp-Banking-Ledger)
2. Clone locally using `git clone https://github.com/tdsmith27/CSharp-Banking-Ledger.git`

   ###### From the root directory
3. Run tests using `dotnet test`
4. Run the program using `dotnet run --project bankingLedger`
5. Follow console prompts to use the full capabilites of the program


## Tech Choices

##### User Interface
The focus of this project was to display my proficiency and competence with C# and the .NET development framework, and for this reason the UI was implemented solely through a console application. The program was however designed with the creation of a partner web application in mind. For this reason, all user interaction with the console is confined to the `Program`, `Session`, and `Format` classes, and the application logic is handled in the `Account`, `Transaction`, `Validate`, `Hash`, and `Salt` classes, allowing these classes to be reusable by a web server implementation.

##### Testing
Testing is a crucial part of the development process, both to ensure code quality and reliability as well as to streamline development by automating the testing process and preventing costly bugs. All testing for this project was implemented using the xUnit.net testing framework. xUnit was chosen for its robust error assertion functionality, and for the ability to design parameterized tests using the `[Theory]` attribute.

##### Security
As per the requirements of the prompt, this program does not use any form of persistent storage. All account and application data is stored within local storage containers which are reset and lost on completion of the program. Despite the trivial and ephemeral nature of the application, measures were taken to follow security best practices in regards to storage and authentication of sensitive data such as passwords. Passwords are never stored as plain text, and are instead hashed using the SHA-256 Hashing Algorithm with a randomly generated salt for each password. The resulting hash and salt are stored as private fields on the relevant account and are only accessible through methods created to save and authenticate the hash strings.

##### Transaction logging
This program takes an object-oriented approach to transactions, with account balances represented as the collection of their transactions. This allows for additional relevant data to be stored and logged such as the DateTime or a unique transaction id for each transaction. Although this program only allows for deposits and withdrawals to be made for each account, this approach also would provide the benefit of allowing future implementation of systems for voiding past transactions while maintaining the data integrity of each account.

---

*Thank you for taking the time to read and view my project, I can be reached for any questions, comments, or further discussion at my [linkedIn](https://www.linkedin.com/in/trevorsmithdev/) or via email at smittrevor@gmail.com*
