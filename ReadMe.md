# Sereno

## Overview
The Sereno is designed to manage all aspects of running a relaxation garden business. It facilitates:

- **Booking Management**: Schedule and track events and parties.
- **Inventory Management**: Monitor and manage stock levels for drinks.
- **External Providers**: Track food orders and payments to partner restaurants.
- **Accounting**: Manage revenue, expenses, and generate financial reports.
- **Receipt and Invoice Management**: Automate generation and tracking of receipts and invoices.
- **Mobile Money Integration**: Allow seamless mobile money payments for bookings, orders, and other transactions.

---

## Domain-Driven Design (DDD) Structure
The system follows a clean architecture approach, organizing components into core domains and layers to ensure maintainability, scalability, and adherence to business logic.

### **Domains**

1. **Booking Domain**
    - **Entities**:
        - `Booking`: Represents a reservation, including customer details, event details, and schedule.
        - `Customer`: Stores information about the individual or group making the booking.
    - **Value Objects**:
        - `TimeSlot`: Specifies the start and end time of a booking.
        - `BookingStatus`: Enum to define states (e.g., Pending, Confirmed, Cancelled).

2. **Inventory Domain**
    - **Entities**:
        - `InventoryItem`: Represents a stock item, such as a drink or supply.
        - `Supplier`: Represents suppliers providing stock items.
    - **Value Objects**:
        - `StockLevel`: Encapsulates current stock levels and reorder thresholds.
        - `ItemCategory`: Enum for categorizing inventory (e.g., Beverages, Miscellaneous).

3. **External Providers Domain**
    - **Entities**:
        - `Provider`: Represents external food providers or restaurants.
        - `FoodOrder`: Tracks orders placed with providers, linked to bookings.
    - **Value Objects**:
        - `MenuItem`: Represents an item offered by an external provider, including pricing.
        - `OrderStatus`: Enum to define the state of an order (e.g., Pending, Delivered).

4. **Accounting Domain**
    - **Entities**:
        - `Transaction`: Represents financial transactions (income or expense).
        - `Expense`: Tracks operational costs, such as salaries or maintenance.
    - **Value Objects**:
        - `TransactionType`: Enum to classify transactions (e.g., Revenue, Expense).
        - `PaymentMethod`: Enum for payment modes (e.g., Cash, Mobile Money).

5. **Payment Domain**
    - **Entities**:
        - `Payment`: Represents a payment transaction linked to bookings or orders.
    - **Value Objects**:
        - `PaymentStatus`: Enum for states (e.g., Paid, Pending, Failed).

---

### **Key Layers**

1. **Core**
    - Contains the domain models, entities, value objects, and interfaces.
    - This layer encapsulates the business logic and rules.

2. **Application Layer**
    - Contains use cases (application services) that orchestrate operations involving domain objects.
    - Example Use Cases:
        - `MakeBooking`
        - `TrackInventory`
        - `GenerateInvoice`

3. **Infrastructure Layer**
    - Implements external integrations like database access, payment gateways, and API calls.
    - Example Components:
        - Repository patterns for entities (e.g., `BookingRepository`).
        - Mobile money API adapters.

4. **Presentation Layer**
    - The user interface for interacting with the system.
    - Provides options for web or mobile implementations (e.g., React, Angular, or Flutter).

---

## Technology Stack

### Backend
- **Language/Framework**: C# (ASP.NET Core)
- **Database**: PostgreSQL

### Frontend
- (Pending Decision: Options include React, Angular, or Flutter for mobile applications.)

### Additional Tools
- RESTful APIs for seamless data exchange between frontend and backend.
- Payment gateway integration for mobile money transactions.

---

## System Architecture

### 1. Frontend
- User-friendly interface for staff and customers.
- Features include booking forms, inventory updates, and payment tracking.

### 2. Backend
- RESTful APIs to handle booking, inventory, external provider management, and accounting.

### 3. Database Schema (Sample Tables)
- `Bookings`
- `Customers`
- `Inventory`
- `Sales`
- `ExternalProviders`
- `Expenses`
- `Receipts`
- `Invoices`
- `Payments`

---

## Future Enhancements
- **Advanced Reporting**: Add analytics dashboards for deeper insights.
- **Multi-Location Support**: Expand the system for businesses with multiple branches.
- **Customer Loyalty Programs**: Integrate rewards for frequent customers.
- **E-commerce Support**: Allow customers to book and pay directly from a web or mobile app.

---

## Setup and Installation

### Prerequisites
- Install .NET 9.0 or later.
- Install PostgreSQL.
- Mobile Money API credentials (e.g., MTN MoMo, M-Pesa).

### Steps
1. Clone the repository.
2. Configure the database connection in the backend settings.
3. Install required dependencies for ASP.NET Core.
4. Run database migrations to set up schema.
5. Launch the backend server.
6. Set up and integrate the chosen frontend technology.

---

## License
This project is licensed under the MIT License.

---

## Contact
For inquiries or support, reach out to [Your Contact Information].
