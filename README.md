# SMS Service

Table of Contents

- [Description](#description)
- [Implementation details](#implementation-details)
- [Tech Stack](#tech-stack)

## Description

A simple service that handles sending SMS to different vendors. A single endpoint is exposed for the users to send their message along with the corresponding receiving  number.

The service then handles SMS sending by using vendors based on the country that corresponds to the number. Due to cost management reasons, there are three different vendors that can accomplish this operation:

1. SMSVendorGR

    - Used to send SMS to Greek numbers.
    - Accepts text only in Greek characters.
    - Cannot send an SMS with greater than 480 characters.

2. SMSVendorCY

    - Used to send SMS to Cypriot numbers.
    - Cannot send an SMS with greater than 160 characters.

3. SMSVendorRest

    - Used to send SMS to all other countries.
    - Cannot send an SMS with greater than 480 characters.

When an SMS has more characters than the corresponding limit, it is split to multiple SMS when sent. All vendors support a `Send` method, that persists the message to a database.

## Implementation Details

The API exposes a `POST` endpoint, which accepts an SMS Data Transfer Object (DTO) in the request body, as shown below:

```json
{
    "text": "The SMS text content goes here.",
    "number": "+(country code)(subscriber number)"
}
```

When a request is sent, the appropriate vendor is selected based on the country code of the number. This is done in a custom Middleware inserted into the request pipeline. To be more specific, `VendorMiddleware` determines the correct country and initializes an object of the corresponding vendor, using the Factory and the Strategy Design Patterns.

The vendor object is passed to the Controller in the `VendorFilter`. This is because no request gets passed at the time of Controller construction and as a result, the vendor must be injected during the action method invocation.

Each vendor has its own validations. The validations are performed in the `ValidationFilter`, after the injection of the correct vendor. If validation errors are present, a response with status code *400* is returned, providing some information about the errors.

If the validation check passes, the `SmsDto` is mapped to a `Sms`. The SMS is then sent by the vendor, after applying the necessary  logic to split the message if it exceeds the maximum character limit.

For the persistence of the message to the database, the Repository Design pattern has been implemented, with the repository being injected to the vendors.

## Tech Stack

The service was built with .NET 6 and ASP.NET Core Web API.

The validations were implemented using [FluentValidation](https://docs.fluentvalidation.net).

For mapping from `SmsDto` to `Sms` [Automapper](https://automapper.org/) was used.

For the database, a simple schema was created in SQL Server, while the connection was made with [Entity Framework Core 6](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-6.0/whatsnew).

In the test project, [XUnit](https://xunit.net/) was used along with [Moq](https://github.com/moq/moq) and the [InMemory](https://learn.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=dotnet-core-cli) version of EF Core 6.
