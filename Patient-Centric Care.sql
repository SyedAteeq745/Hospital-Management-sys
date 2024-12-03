CREATE DATABASE HospitalManagement;
USE HospitalManagement;
-- Patients Table
CREATE TABLE Patients (
    PatientID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100),
    Age INT,
    Gender VARCHAR(10),
    ContactInfo VARCHAR(100),
    Address TEXT
);

-- Doctors Table
CREATE TABLE Doctors (
    DoctorID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100),
    Specialty VARCHAR(50),
    ContactInfo VARCHAR(100)
);

-- Appointments Table
CREATE TABLE Appointments (
    AppointmentID INT PRIMARY KEY AUTO_INCREMENT,
    PatientID INT,
    DoctorID INT,
    AppointmentDate DATETIME,
    Reason TEXT,
    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID),
    FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID)
);

-- Feedback Table
CREATE TABLE Feedback (
    FeedbackID INT PRIMARY KEY AUTO_INCREMENT,
    PatientID INT,
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    Comments TEXT,
    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID)
);

-- Billing Table
CREATE TABLE Billing (
    BillingID INT PRIMARY KEY AUTO_INCREMENT,
    PatientID INT,
    Amount DECIMAL(10, 2),
    BillingDate DATETIME,
    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID)
);
-- Sample Data for Patients
INSERT INTO Patients (Name, Age, Gender, ContactInfo, Address)
VALUES ('John Doe', 30, 'Male', '1234567890', '123 Main St'),
       ('Jane Smith', 25, 'Female', '0987654321', '456 Elm St');

-- Sample Data for Doctors
INSERT INTO Doctors (Name, Specialty, ContactInfo)
VALUES ('Dr. Alice', 'Cardiology', 'alice@example.com'),
       ('Dr. Bob', 'Dermatology', 'bob@example.com');

-- Sample Data for Appointments
INSERT INTO Appointments (PatientID, DoctorID, AppointmentDate, Reason)
VALUES (1, 1, '2024-12-05 10:00:00', 'Routine Checkup'),
       (2, 2, '2024-12-06 14:30:00', 'Skin Rash');

-- Sample Data for Feedback
INSERT INTO Feedback (PatientID, Rating, Comments)
VALUES (1, 5, 'Excellent service!'),
       (2, 4, 'Very good but room for improvement.');

-- Sample Data for Billing
INSERT INTO Billing (PatientID, Amount, BillingDate)
VALUES (1, 150.00, '2024-12-05'),
       (2, 200.00, '2024-12-06');
-- Join Query: Retrieve Patient Feedback with Names
SELECT Patients.Name, Feedback.Rating, Feedback.Comments
FROM Patients
JOIN Feedback ON Patients.PatientID = Feedback.PatientID;

-- Aggregation: Calculate Average Feedback Rating
SELECT AVG(Rating) AS AverageRating FROM Feedback;

-- Filter: Get Appointments for a Specific Doctor
SELECT * FROM Appointments
WHERE DoctorID = 1;

-- Retrieve Billing Information for a Patient
SELECT Patients.Name, Billing.Amount, Billing.BillingDate
FROM Patients
JOIN Billing ON Patients.PatientID = Billing.PatientID;
