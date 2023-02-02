# Tax Calculator API

API solution for calculation taxes depends on the VAT rate.

## Usage

API path is **api/v1/calculate** and have 4 endpoints and all query params are in double
- /net - query params are  (amount, vatrate)
- /gross - query params are  (amount, vatrate)
- /vat - query params are  (amount, vatrate)
- /varrate - query params are  (net, gross, vat) - this endpoint will calculate vatrate value by given net, gross, and vat

## Calculations

Calcualte `Net`, `Gross` and `VAT` values for the purchase by given `VAT Rate` and one of this values.
Calculation logic is placed inside service.

## Infrastructure

.Net 6 API project with Swagger interface for visualization of the API.
MediatR [MediatR Page](https://github.com/jbogard/MediatR) is used to solve decoupling the in-process sending of messages from handling messages.
FluentVAlidation is used for handleing validation exceptions with behaviours, handlers and mediators.

> This API follow RESTful API standards.
Dependency Injsction is done in separate library project APIDependencyInjection.
DDD pattern standards is followed, using separate layer(Lib Project).

> Solution is without Docker integration.

## Start the project

Project can be runed localy using Visual Studio 2022 or by command line with `dotnet run` command inside *TaxCalculatorAPI* project.