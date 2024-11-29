
# Final Project Analysis: Car Reservation System

## Project Overview
The **Car Reservation System** was developed as part of the Learning Integration Assessment (LIA) project for our C# course. The system provides a platform for managing car reservations, allowing two types of users—**Admins** and **Customers**—to interact with the system through specific functionalities.

The main objectives were to:
- Create a functional GUI-based application.
- Implement core functionalities for both user roles.
- Integrate a database for persistent data storage.
- Apply internationalization (I18N) and localization (L10N) concepts.
- Adhere to Test-Driven Development (TDD) principles.

---

## Achievements

### Functionalities Implemented

**Core Features:**
- Admins can:
  - Add, update, and remove cars.
  - Manage reservations (view, confirm, or cancel them).
- Customers can:
  - Browse available cars with filters.
  - Reserve a car for specific dates.
  - View their reservation history.

**Database Integration:**
- An SQLite database was implemented to store car details, reservations, and user information.
- Created tables for **Users**, **Cars**, and **Reservations**.

**Internationalization (I18N):**
- The system supports both English and French.
- Implemented dynamic UI text changes based on the selected language using resource files.

**GUI Design:**
- Created a functional and interactive graphical user interface for both Admins and Customers.

**Test-Driven Development (TDD):**
- Partial unit testing was completed for critical methods, such as:
  - `makeReservation()`
  - `addCar()`
  - Database connection validation.

---

## Challenges Faced

### Database Creation:
- Struggled significantly with setting up the SQLite database and ensuring data persistence.
- Encountered errors, such as the **"Object reference not set to an instance of an object"** and **"MissingManifestResourceException"**, when attempting to manage localized resources and integrate the database.

### Internationalization (I18N):
- Encountered issues with resource file naming and embedding, particularly with the `Strings` vs. `Resource` naming conflict.
- Resolved most issues by consolidating resource files but still faced unexpected runtime errors.

### Time Constraints:
- Due to debugging and database-related challenges, some advanced features (e.g., full TDD coverage and improved user validation) were deprioritized.

---

## Unfinished Components

1. **Error Resolution**:
   - The recurring **"MissingManifestResourceException"** remains unresolved. This error affects the ability to dynamically switch between languages in some parts of the application.
2. **Advanced Testing**:
   - While some unit tests were written, full test coverage across all functionalities was not achieved.
3. **Comprehensive Validation**:
   - User input validation and robust exception handling were partially implemented but require refinement.

---

## Teacher's Expectations vs. Final Outcome

| **Expectation**                          | **Status**                                 |
|------------------------------------------|-------------------------------------------|
| GUI-based desktop application            | ✅ Fully implemented for Admins & Customers. |
| Database integration                     | ✅ Completed, but struggled with setup and errors. |
| Internationalization (I18N and L10N)     | ✅ Implemented but with unresolved errors. |
| Use of design patterns                   | ✅ Partially applied in class hierarchy and database management. |
| Test-Driven Development (TDD)            | ⚠️ Partially implemented with limited test coverage. |
| Collaborative Git usage                  | ✅ Project repository maintained with commits and collaboration. |
| Full project report and user manual      | ✅ Documentation provided (README, project report). |

---

## Learning Outcomes

### Database Management:
- Gained hands-on experience with SQLite for data persistence.
- Learned the importance of error handling in database queries and connections.

### Internationalization:
- Understood how resource files enable multi-language support.
- Encountered and troubleshot resource file embedding errors.

### Software Development Lifecycle:
- Followed a structured approach from UML diagramming to GUI implementation and testing.
- Learned the importance of balancing project requirements with available time and resources.

### Team Collaboration:
- Practiced effective communication and task delegation using Git for version control.
