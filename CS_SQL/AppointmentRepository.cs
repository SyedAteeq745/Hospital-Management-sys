namespace PatientCentricCare.Repositories
{
    public class AppointmentRepository
    {
        public string GetCreateTableQuery()
        {
            return @"
                CREATE TABLE Appointments (
                    AppointmentID INT PRIMARY KEY,
                    PatientID INT,
                    DoctorID INT,
                    AppointmentDate DATETIME,
                    Status NVARCHAR(50),
                    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID),
                    FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID)
                );
            ";
        }

        public string GetInsertAppointmentQuery()
        {
            return @"
                INSERT INTO Appointments (AppointmentID, PatientID, DoctorID, AppointmentDate, Status)
                VALUES (1, 1, 1, '2024-12-15 10:00:00', 'Scheduled');
            ";
        }

        public string GetSelectAppointmentsQuery()
        {
            return @"
                SELECT Appointments.AppointmentDate, Appointments.Status, Patients.Name AS PatientName, Doctors.Name AS DoctorName
                FROM Appointments
                JOIN Patients ON Appointments.PatientID = Patients.PatientID
                JOIN Doctors ON Appointments.DoctorID = Doctors.DoctorID;
            ";
        }
    }
}
