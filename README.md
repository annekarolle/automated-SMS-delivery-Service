# Automated SMS delivery Service Twilio

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white)


## Project Description

This project is a .NET 7 application that automates SMS sending using Twilio. It includes a background service for automatic sending and provides the option of sending via API using a POST method.

### Technical Details

The application uses .NET's BackgroundService to send SMS automatically in the background. The relevant code is located in 


```
/Services/TwilioAutomatedSMSSendService.cs
```

## Configuration

Before you start using the program, you need to configure a few things.

### Twilio Configuration

* Create an account on Twilio.
* Obtain the necessary credentials (AccountSid, AuthToken, and a phone number provided by Twilio).

### Project Configuration

* Clone this repository
  
```
    git clone https://github.com/annekarolle/automated-SMS-delivery-Service.git
```

  * In the project's root directory, create an appsettings.json file and add Twilio information:
  
```
    {
        "Twilio": {
        "AccountSid": "Twilio AccountSid",
        "AuthToken": "Twilio AuthToken" 
        },
    }
```

## Api de Envio via POST

API for POST-based Sending
You can also send SMS via API using a POST method. Here is an example of the DTO used:

```
    SmsDTO {
            public string To { get; set; }
            public string Message { get; set; }
        }
```


## Project Structure 

```
root
│   appsettings.json
│   Program.cs
│
└───Controllers
│   │   SendSMSController.cs
│
└───DTO
│   │   SMSDTO.cs
│
└───Services
    │   TwilioAutomatedSMSSendService.cs
    │   TwilioClientService.cs

```

### Root: The root folder of the project.

* appsettings.json: The configuration file to store settings, such as Twilio credentials.

* Program.cs: The entry point of the program.

### Controllers: Contains controllers for your web application.

* SendSMSController.cs: Controller responsible for the SMS sending logic.

### DTO: Contains Data Transfer Objects (DTOs) used to define the structure of data you send and receive.

* SMSDTO.cs: DTO to represent the data necessary for sending SMS.


### Services: Contains services responsible for business logic.

* TwilioAutomatedSMSSendService.cs: Service that utilizes BackgroundService to send SMS automatically.
* TwilioClientService.cs: Service that interacts with the Twilio API for SMS sending.

### Contact
[![Linkedin](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/annekarolle/)
[![Portfolio](https://img.shields.io/badge/website-000000?style=for-the-badge&logo=About.me&logoColor=white)](https://annekarolle.github.io/portfolio/)
[![email](https://img.shields.io/badge/Gmail-D14836?style=for-the-badge&logo=gmail&logoColor=white)](annekarolle@gmail.com)