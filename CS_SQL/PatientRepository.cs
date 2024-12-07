namespace PatientCentricCare.Repositories
{
    public class PatientRepository
    {
        public string GetCreateTableQuery()
        {
            return @"
                CREATE TABLE Patients (
                    PatientID INT PRIMARY KEY,
                    Name NVARCHAR(100),
                    Email NVARCHAR(100),
                    Phone NVARCHAR(20),
                    DateOfBirth DATE,
                    Address NVARCHAR(255)
                );
            ";
        }

        public string GetInsertPatientQuery()
        {
            return @"
                INSERT INTO Patients (PatientID, Name, Email, Phone, DateOfBirth, Address)
                VALUES (1, 'John Doe', 'john.doe@example.com', '1234567890', '1980-01-01', '123 Main Street');
            ";
        }

        public string GetSelectPatientsQuery()
        {
            return "SELECT * FROM Patients;";
        }
    }
}
