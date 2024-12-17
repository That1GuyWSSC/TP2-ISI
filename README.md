# User Management WCF Service with PostgreSQL (CockroachDB)

This project implements a **WCF (Windows Communication Foundation)** service that provides CRUD (Create, Read, Update, Delete) operations for managing users in a PostgreSQL database hosted on CockroachDB. The project is written in **C#** and uses the **Npgsql** library to interact with the database.

---

## Features

- **Test Database Connection**: Ensures the service can connect to the database successfully.
- **Get Users**: Retrieves all users from the database.
- **Insert User**: Adds a new user to the database.
- **Update User**: Updates the details of an existing user.
- **Delete User**: Deletes a user by their ID.

---

## Technologies Used

- **C#**
- **WCF** (Windows Communication Foundation)
- **PostgreSQL** (CockroachDB)
- **Npgsql** (PostgreSQL .NET driver)
- **.NET Framework**

---

## Project Structure

- **Service.cs**: Contains the WCF service implementation with CRUD operations.
- **DatabaseConfig.cs**: Centralized class for managing the database connection string.

---


