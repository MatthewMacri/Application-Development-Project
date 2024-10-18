```mermaid
graph TD
    Start -->|Customer| BrowseCars
    Start -->|Admin| AdminLogin
    BrowseCars --> FilterCars
    FilterCars --> SelectCar
    SelectCar --> ChooseDates
    ChooseDates --> MakeReservation
    MakeReservation --> ViewReservations
    ViewReservations --> End
    AdminLogin --> ManageCars
    ManageCars --> AddUpdateRemoveCar
    AddUpdateRemoveCar --> ManageReservations
    ManageReservations --> ViewAllReservations
    ViewAllReservations --> ConfirmCancelModify
    ConfirmCancelModify --> End
    End -->|End of Process| Done