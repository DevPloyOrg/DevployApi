# devploy.org
This Api system serv DevPloy.com a space dedicated to helping junior developers grow and succeed. Whether you're looking to showcase your skills, contribute to meaningful projects, or gain valuable experience, our platform is here to support you every step of the way.

# AppNav API

AppNav API is a comprehensive API designed to streamline the development process for various applications. This repository contains the core controllers and configurations necessary for setting up and running the API. The API uses a class library available in this repository to provide reusable components and utilities.

## Requirements

This API use a class lybrary located in : https://github.com/DevPloyOrg/AppNav.git

## Installation

To get started with AppNav API, follow these steps:

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/AppNav.git
    ```
2. Navigate to the project directory:
    ```sh
    cd AppNav
    ```
3. Install the required dependencies:
    ```sh
    dotnet restore
    ```

## Documentation

The XML Static file will be located in the bin/Debug/net8.0/ once the project ii be buided

The static API documentation  includes detailed descriptions of each endpoint, request and response formats, and usage examples.

# Interactive Documentation
Local Interactive Documentation
After running the API locally, you can access the interactive API documentation using Swagger UI:

Start the API by running dotnet run.
Open your web browser and navigate to:
http://localhost:5000/swagger (HTTP)
https://localhost:5001/swagger (HTTPS)
Public Interactive Documentation
If the API is deployed on a public server, you can access the interactive API documentation at:

https://your-deployed-api-url/swagger
Using Swagger UI
Swagger UI allows you to:

Explore Endpoints: View all the available endpoints in the API.
View Request and Response Models: See detailed information about the request parameters and response models for each endpoint.
Test Endpoints: Execute API calls directly from the Swagger UI to test the endpoints and see live responses.
To test an endpoint:

Select the endpoint you want to test from the list.
Enter any required parameters in the provided fields.
Click the "Try it out" button.
View the response directly in the UI.