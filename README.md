# Online Store Website

This project is an online store website developed using ASP.NET. It provides a feature-rich e-commerce platform for customers to browse and purchase products. The website incorporates various tools and technologies such as Entity Framework, Identity, Razor Pages, and follows the Onion Architecture design pattern.

# Key Features

- Seamless Shopping Experience: The website offers a user-friendly interface that allows customers to easily browse and purchase products.
- Efficient Database Management: Entity Framework is used for efficient and reliable database management, ensuring smooth data operations.
- User Authentication and Authorization: ASP.NET Identity is implemented to manage user access levels and secure the website's functionalities.
- Modularity and Scalability: The project follows the Onion Architecture design pattern, promoting modularity, maintainability, and scalability of the application.
- Warehouse Management System Integration: The website integrates with a warehouse management system via REST API, enabling real-time inventory management and order fulfillment.
- Professional User Access Control: A robust user access control system is implemented, ensuring secure and professional management of user roles and permissions.

![Alt Text](../Screenshots/Screenshot 2023-11-22 132040.jpg){:width="500px"}
![Alt Text](../Screenshots/Screenshot 2023-11-22 132111.jpg){:width="500px"}
![Alt Text](../Screenshots/Screenshot 2023-11-22 133029.jpg){:width="500px"}

# Installation and Usage

1. Clone the repository : `git clone https://github.com/Alir1997/LampShade.git`
2. Open the project in your preferred development environment (e.g., Visual Studio).
3. Build the solution to restore NuGet packages and compile the project.
4. Update the database connection string in the `appsettings.json` file to point to your local or remote SQL Server instance.
5. Run the database migrations to create the necessary database schema: `dotnet ef database update`.
6. Start the application and access it through the specified URL.

# Contributing

Contributions are welcome! If you would like to contribute to this project, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature/fix: `git checkout -b your-branch-name`.
3. Make your changes and commit them: `git commit -m "Add your commit message"`.
4. Push to your branch: `git push origin your-branch-name`.
5. Open a pull request, describing your changes and their purpose.

# License

This project is licensed under the [MIT License](LICENSE).



