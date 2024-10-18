```mermaid
classDiagram
    class User {
        -username : String
        -password : String
        -email : String
        +login() : void
        +logout() : void
        +viewProfile() : void
    }

    class Customer {
        -customerId : int
        -reservationHistory : List<Reservation>
        +makeReservation() : void
        +viewReservations() : List<Reservation>
    }

    class Admin {
        -adminId : int
        +addCar() : void
        +updateCar() : void
        +removeCar() : void
        +manageReservations() : void
    }

    class Car {
        -carId : int
        -model : String
        -brand : String
        -carType : String
        -availableFrom : DateTime
        -availableTo : DateTime
        +isAvailable() : bool
        +getCarDetails() : void
    }

    class Reservation {
        -reservationId : int
        -car : Car
        -customer : Customer
        -reservationStart : DateTime
        -reservationEnd : DateTime
        -status : String
        +confirmReservation() : void
        +cancelReservation() : void
        +viewDetails() : void
    }

    User <|-- Customer
    User <|-- Admin
    Customer "1" --> "*" Reservation : makes
    Admin "1" --> "*" Car : manages
    Car "1" --> "*" Reservation : reserved by
