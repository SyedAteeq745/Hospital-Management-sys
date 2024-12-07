namespace PatientCentricCare.Repositories
{
    public class BillingRepository
    {
        public string GetCreateTableQuery()
        {
            return @"
                CREATE TABLE Billing (
                    BillID INT PRIMARY KEY,
                    PatientID INT,
                    Amount DECIMAL(10, 2),
                    BillingDate DATETIME,
                    Status NVARCHAR(50),
                    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID)
                );
            ";
        }

        public string GetInsertBillQuery()
        {
            return @"
                INSERT INTO Billing (BillID, PatientID, Amount, BillingDate, Status)
                VALUES (1, 1, 250.00, '2024-12-01 09:00:00', 'Paid');
            ";
        }

        public string GetSelectBillingQuery()
        {
            return @"
                SELECT Patients.Name AS PatientName, Billing.Amount, Billing.BillingDate, Billing.Status
                FROM Billing
                JOIN Patients ON Billing.PatientID = Patients.PatientID;
            ";
        }
    }
}
