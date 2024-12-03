# Transaction-Management-AspNetCore

This repository consists of two projects:

- **FinancePortal** (client_end): An ASP.NET Core MVC project where users initiate transactions by entering the amount and bank account details.
- **FinanceService** (bank_end): An ASP.NET Core WebAPI project that processes and logs transaction statuses.

- **Technologies Used**
- ASP.NET Core MVC
- ASP.NET Core WebAPI
- Entity Framework Core
- SQL Server


**Features**
- Transaction statuses include Success, Failed, and Pending.
- Handles scenarios like connection timeout and connection refused:
- Timeout: Status set to Pending (saved in Transaction table only).
- Connection Refused: Status set to Failed.
- TransactionLogs: Logs only Success or Failed transactions.
  
**CheckStatus Utility:**
- Monitors Pending transactions in the Transaction table caused by timeouts.
- Updates the status in the Transaction table based on the corresponding log in the TransactionLogs table.
- If the transaction exists in the TransactionLogs table as Success or Failed, the Transaction table is updated accordingly.
- Ensures consistency between Transaction and TransactionLogs

**Transaction Management**
- Users can initiate transactions with an amount and bank account details.
- Handles three transaction statuses:
- Success: The transaction is completed successfully.
- Failed: The transaction failed due to issues like connection refusal.
- Pending: The transaction is delayed due to a timeout.


- **Database Design**
- Transaction Table (FinancePortal Project): Tracks all transactions with statuses, including Pending.
- TransactionLogs Table (FinanceService Project): Logs only Success or Failed statuses.

---

Home Page
![home_page](https://github.com/user-attachments/assets/f9aa7ad6-cb26-4bb3-a052-151b66991403)

---

Create Transaction Page
![create_transaction](https://github.com/user-attachments/assets/f13d9aa5-f48a-4611-a14c-2828d869459d)

---

Transaction Detail Page
![transaction_details](https://github.com/user-attachments/assets/096ebca6-0001-485a-9320-26b937ed77eb)

---

Checkstatus Page
![checkstatus](https://github.com/user-attachments/assets/0d6747e1-b25d-46ca-be58-731e35425a1a)

---

Checkstatus Connection Refused
![checkstatus_connectionrefused](https://github.com/user-attachments/assets/d648ccac-629e-4cc0-bfc9-2deeee758057)
