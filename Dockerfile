FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /EstimationToolApi
EXPOSE 5001
EXPOSE 443
WORKDIR /src
COPY . .
RUN dotnet build "Divstack.Company.Estimation.Tool.sln" -c Release
WORKDIR /src/Divstack.Company.Estimation.Tool.Bootstrapper
RUN dotnet publish "Divstack.Company.Estimation.Tool.Bootstrapper.csproj" --no-build -c Release -o /EstimationToolApi
WORKDIR /EstimationToolApi
ENV ConnectionStrings__Carts "Server=195.78.66.133;Port=3306;Database=divstack_estimatetool;Uid=divstack_estimatetool;Pwd=IBi2q6JB7)wm--YQ;"
ENV ConnectionStrings__Users "Server=195.78.66.133;Port=3306;Database=divstack_estimatetool;Uid=divstack_estimatetool;Pwd=IBi2q6JB7)wm--YQ;"
ENV ConnectionStrings__Services "Server=195.78.66.133;Port=3306;Database=divstack_estimatetool;Uid=divstack_estimatetool;Pwd=IBi2q6JB7)wm--YQ;"
ENV ConnectionStrings__Valuations "Server=195.78.66.133;Port=3306;Database=divstack_estimatetool;Uid=divstack_estimatetool;Pwd=IBi2q6JB7)wm--YQ;"
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Divstack.Company.Estimation.Tool.Bootstrapper.dll
