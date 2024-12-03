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

![home_page](https://github.com/user-attachments/assets/8f858cd1-881c-4855-9778-869de1840a03)

---

Create Transaction Page

![create_transaction](https://github.com/user-attachments/assets/572acdca-b4fb-4b1f-a67c-81334b9e78bf)

---

Transaction Detail Page

![transaction_details](https://github.com/user-attachments/assets/5a8018c4-b00d-46be-8a2a-7f7ee2a109b4)

---

Checkstatus Page

![checkstatus](https://github.com/user-attachments/assets/3400f034-ed67-421a-84ab-614cae439dce)

---

Checkstatus Connection Refused

![checkstatus_connectionrefused](https://github.com/user-attachments/assets/c8a88387-3b61-4d36-88ba-2c55e2dc91eb)

---

