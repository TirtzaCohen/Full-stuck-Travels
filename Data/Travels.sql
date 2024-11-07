CREATE DATABASE Travels;

USE Travels;
CREATE TABLE TravelType(
	typeCode INT IDENTITY(1,1) PRIMARY KEY,
	typeName VARCHAR(255)
);
CREATE TABLE Users (
    user_code INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(255),
    family VARCHAR(255),
    phone VARCHAR(20),
    email VARCHAR(255),
    login_password VARCHAR(255),
    first_aid_certificate BIT
);
CREATE TABLE Trips (
    trip_code INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    trip_destination VARCHAR(255),
    type_code INT,
    date DATE,
    departure_time TIME,
    trip_duration_hours INT,
    number_of_available_places INT,
    price DECIMAL(10, 2),
    photo TEXT,
    FOREIGN KEY (type_code) REFERENCES TravelType(typeCode)
);
CREATE TABLE Booking_Places (
    booking_code INT IDENTITY(1,1) PRIMARY KEY,
    user_code INT,
    booking_date DATE,
    booking_time TIME,
    trip_code INT,
    number_of_places INT,
    FOREIGN KEY (user_code) REFERENCES Users(user_code),
    FOREIGN KEY (trip_code) REFERENCES Trips(trip_code)
);
INSERT INTO TravelType (typeName) VALUES
    ('Type 1'),
    ('Type 2'),
    ('Type 3'),
    ('Type 4');
INSERT INTO Users (name, family, phone, email, login_password, first_aid_certificate) VALUES
    ('John', 'Doe', '1234567890', 'john.doe@example.com', 'password1', 1),
    ('Jane', 'Smith', '0987654321', 'jane.smith@example.com', 'password2', 0),
    ('Michael', 'Johnson', '9876543210', 'michael.johnson@example.com', 'password3', 0),
    ('Emily', 'Brown', '0123456789', 'emily.brown@example.com', 'password4', 1),
    ('David', 'Wilson', '4567890123', 'david.wilson@example.com', 'password5', 1);

INSERT INTO Trips (trip_destination, type_code, date, departure_time, trip_duration_hours, number_of_available_places, price, photo) VALUES
    ('Trip 1 Destination', 1, '2023-12-26', '09:00:00', 4, 10, 50.00, 'photo1.jpg'),
    ('Trip 2 Destination', 2, '2023-12-27', '11:30:00', 6, 8, 75.00, 'photo2.jpg'),
    ('Trip 3 Destination', 3, '2023-12-28', '14:00:00', 5, 12, 60.00, 'photo3.jpg'),
    ('Trip 4 Destination', 4, '2023-12-29', '10:15:00', 3, 6, 45.00, 'photo4.jpg'),
    ('Trip 5 Destination', 4, '2023-12-30', '13:45:00', 7, 15, 80.00, 'photo5.jpg');

INSERT INTO Booking_Places (user_code, booking_date, booking_time, trip_code, number_of_places) VALUES
    (1, '2023-12-26', '08:30:00', 1, 2),
    (2, '2023-12-27', '10:45:00', 2, 3),
    (3, '2023-12-28', '13:30:00', 3, 1),
    (4, '2023-12-29', '09:45:00', 4, 4),
    (5, '2023-12-30', '12:15:00', 5, 2);