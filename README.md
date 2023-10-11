# SaleSeeker



## Sale Seeker Architect documentation
  - https://brianmkhabela.atlassian.net/l/cp/Xt6M0iqj
  - https://github.com/users/TlangelaniBrian/projects/2/views/2?layout=board

## Setting up and Running a .NET Core 6 Project with SaleSeeker-API, SaleSeeker-Web, and SaleSeekerDAL

This documentation page provides some detailed instructions on how to set up and run a Dot Net Core 6 project with the following components: SaleSeeker-API, SaleSeeker-Web, and SaleSeekerDAL. The project also includes a database migration that is run through a Docker Compose file. Additionally, users will need to use their Facebook login credentials to access the site. 

## Prerequisites

Before getting started, ensure that you have the following prerequisites installed:

- .NET Core 6 SDK
- Docker
- Docker Compose

## Step 1: Cloning the repository

1. Open your command-line interface and navigate to the directory where you want to clone the project.
2. Execute the following command to clone the repository:

```bash
git clone <repository-url>
```

## Step 2: Setting up the SaleSeekerDAL database migration

1. Open the command-line interface and navigate to the `SaleSeekerDAL` directory in the cloned repository.
2. Run the following command to generate the migrations:

```bash
dotnet ef migrations add InitialCreate
```

3. After successfully generating the migrations, execute the following command to apply the migrations:

```bash
dotnet ef database update
```

4. Ensure that the database connection string is correctly configured in the `appsettings.json` file of the `SaleSeekerDAL` project.

## Step 3: Configuring Facebook login credentials

1. Since this is a Mock project you can use the following Facebook login credentials:
   - username: briantmkhabela@gmail.com
   - password: Fb2024pw
     

## Step 4: Running the project with Docker Compose

1. Open the command-line interface and navigate to the root directory of the cloned repository.
2. Run the following command to start the application using Docker Compose:

```bash
docker-compose up --build
```

3. Wait for the build and deployment processes to complete. You should see log messages indicating a successful launch.
4. Access the application by visiting `http://localhost` in your web browser.
5. Login using your Facebook credentials to access the site.

Congratulations! You have successfully set up and ran the SaleSeeker project with the SaleSeeker-API, SaleSeeker-Web, and SaleSeekerDAL components.
