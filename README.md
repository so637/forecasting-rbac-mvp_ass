<<<<<<< HEAD
# Getting Started with Create React App

This project was bootstrapped with [Create React App](https://github.com/facebook/create-react-app).

## Available Scripts

In the project directory, you can run:

### `npm start`

Runs the app in the development mode.\
Open [http://localhost:3000](http://localhost:3000) to view it in your browser.

The page will reload when you make changes.\
You may also see any lint errors in the console.

### `npm test`

Launches the test runner in the interactive watch mode.\
See the section about [running tests](https://facebook.github.io/create-react-app/docs/running-tests) for more information.

### `npm run build`

Builds the app for production to the `build` folder.\
It correctly bundles React in production mode and optimizes the build for the best performance.

The build is minified and the filenames include the hashes.\
Your app is ready to be deployed!

See the section about [deployment](https://facebook.github.io/create-react-app/docs/deployment) for more information.

### `npm run eject`

**Note: this is a one-way operation. Once you `eject`, you can't go back!**

If you aren't satisfied with the build tool and configuration choices, you can `eject` at any time. This command will remove the single build dependency from your project.

Instead, it will copy all the configuration files and the transitive dependencies (webpack, Babel, ESLint, etc) right into your project so you have full control over them. All of the commands except `eject` will still work, but they will point to the copied scripts so you can tweak them. At this point you're on your own.

You don't have to ever use `eject`. The curated feature set is suitable for small and middle deployments, and you shouldn't feel obligated to use this feature. However we understand that this tool wouldn't be useful if you couldn't customize it when you are ready for it.

## Learn More

You can learn more in the [Create React App documentation](https://facebook.github.io/create-react-app/docs/getting-started).

To learn React, check out the [React documentation](https://reactjs.org/).

### Code Splitting

This section has moved here: [https://facebook.github.io/create-react-app/docs/code-splitting](https://facebook.github.io/create-react-app/docs/code-splitting)

### Analyzing the Bundle Size

This section has moved here: [https://facebook.github.io/create-react-app/docs/analyzing-the-bundle-size](https://facebook.github.io/create-react-app/docs/analyzing-the-bundle-size)

### Making a Progressive Web App

This section has moved here: [https://facebook.github.io/create-react-app/docs/making-a-progressive-web-app](https://facebook.github.io/create-react-app/docs/making-a-progressive-web-app)

### Advanced Configuration

This section has moved here: [https://facebook.github.io/create-react-app/docs/advanced-configuration](https://facebook.github.io/create-react-app/docs/advanced-configuration)

### Deployment

This section has moved here: [https://facebook.github.io/create-react-app/docs/deployment](https://facebook.github.io/create-react-app/docs/deployment)

### `npm run build` fails to minify

This section has moved here: [https://facebook.github.io/create-react-app/docs/troubleshooting#npm-run-build-fails-to-minify](https://facebook.github.io/create-react-app/docs/troubleshooting#npm-run-build-fails-to-minify)
=======
Forecasting & RBAC MVP
About the Task

This is a simple full-stack MVP built using React and ASP.NET Core Web API.

The goal of this Task is to show:

Role-based access control (RBAC)

CSV upload

Forecast generation

Approval workflow for forecast changes

The focus is on logic and architecture, not UI design.

Tech Stack

Frontend: React

Backend: ASP.NET Core Web API

Database: SQLite (Entity Framework Core)

User Roles

Admin

Manager

User

Roles are checked on the backend using request headers.

How Login Works

Static users are stored in the database

Login returns user role

Role is sent in API requests using header:

X-User-Role

CSV Upload

Admin can upload a CSV file

CSV data is stored as raw text

Example CSV used:

Value
100
200
150

Forecast Logic

After CSV upload, Admin generates forecast

Forecast is created for next 12 months

Simple average-based logic is used

One record per month is stored

Approval Workflow

Users and Managers can propose forecast changes

Original forecast is not updated

A new commitment record is created

Status: Pending / Approved / Rejected

Admin or Manager approves the change

Database Tables

CsvImports – stores uploaded CSV

SimulatedProjects – stores system forecast

UserCommitments – stores user changes

How to Run
Backend
cd Forecast.Api
dotnet run

Frontend
cd forecast-ui
npm start

Test Users
Role	Username	Password
Admin	admin	admin123
Manager	manager	manager123
User	user	user123
>>>>>>> 01af2c569c0d22f95c0557f567dc79c761fc4c60
