```mermaid
erDiagram
    USER {
        int userId PK
        string username
        string password
        string email
    }
    
    CUSTOMER {
        int customerId PK
        int userId FK
        string reservationHistory
    }
    
    ADMIN {
        int adminId PK
        int userId FK
    }
    
    CAR {
        int carId PK
        string model
        string brand
        string carType
        datetime availableFrom
        datetime availableTo
    }
    
    RESERVATION {
        int reservationId PK
        int carId FK
        int customerId FK
        datetime reservationStart
        datetime reservationEnd
        string status
    }
    
    USER ||--o{ CUSTOMER : has
    USER ||--o{ ADMIN : has
    CUSTOMER ||--o{ RESERVATION : makes
    CAR ||--o{ RESERVATION : reserved by
    ADMIN ||--o{ CAR : manages
