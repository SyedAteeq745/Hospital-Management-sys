namespace PatientCentricCare.Repositories
{
    public class FeedbackRepository
    {
        public string GetCreateTableQuery()
        {
            return @"
                CREATE TABLE Feedback (
                    FeedbackID INT PRIMARY KEY,
                    PatientID INT,
                    Rating INT CHECK (Rating BETWEEN 1 AND 5),
                    Comments NVARCHAR(255),
                    FeedbackDate DATETIME,
                    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID)
                );
            ";
        }

        public string GetInsertFeedbackQuery()
        {
            return @"
                INSERT INTO Feedback (FeedbackID, PatientID, Rating, Comments, FeedbackDate)
                VALUES (1, 1, 5, 'Excellent service!', '2024-12-05 14:00:00');
            ";
        }

        public string GetSelectFeedbackQuery()
        {
            return @"
                SELECT Patients.Name AS PatientName, Feedback.Rating, Feedback.Comments, Feedback.FeedbackDate
                FROM Feedback
                JOIN Patients ON Feedback.PatientID = Patients.PatientID;
            ";
        }
    }
}
