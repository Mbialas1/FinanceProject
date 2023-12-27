# Finance Project

🚀 Welcome to the Finance Project repository! This project utilizes CQRS, Event Sourcing, Docker, .NET 6, and Angular to manage financial transactions and account balance.

## Features

- 💰 **Financial Transactions:**
  - ✨ Add new financial transactions
  - 🔄 Update existing transactions
  - ❌ Remove transactions

- 📊 **Account Balance:**
  - 📈 Track and display the current account balance
  - 🔄 Real-time updates using Event Sourcing

## Technologies Used

- **Backend:**
  - 🛠️ .NET 6
  - 🔄 CQRS (Command Query Responsibility Segregation)
  - 🔄 Event Sourcing

- **Frontend:**
  - 🅰 Angular

- **Containerization:**
  - 🐳 Docker

## Getting Started

To get started with the Finance Project, follow these steps:


 - Connect to MSSQL Database:

Connect to the MSSQL database using SQL Server Management Studio with 'SQL Server Auth.'
Import the db.bacpac file (from the main folder) into the database.
Name the database FinanceDB.
Configure the database for Docker ([link](https://stackoverflow.com/questions/50166869/connect-to-sql-server-in-local-machine-host-from-docker-using-host-docker-inte)).
 - Update Connection Strings:

Modify the connection string in both appsettings.json files with the appropriate login and password.
 - Run Docker:

Start Docker.
 - Build Docker Images:

Open PowerShell in Visual Studio and run the following commands (You must be in main folder of project):
Build the backend image (docker build -t finance-api -f Dockerfile.FinanceAPI .).
Navigate to the Finance.UI folder (cd Finance.UI) (docker build -t finance-ui -f Dockerfile.FinanceUI .) and build the frontend image.
Return to the main folder using "cd ..".
Run Docker Compose (docker-compose up -d).

Access the Application:

Open your web browser and go to http://localhost:8081/.
