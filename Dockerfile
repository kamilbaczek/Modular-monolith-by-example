FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /EstimationToolApi
EXPOSE 5001
EXPOSE 443
WORKDIR /src
COPY . .
RUN dotnet build "Divstack.Company.Estimation.Tool.sln" -c Release
WORKDIR /src/Src/Bootstrapper/Divstack.Company.Estimation.Tool.Bootstrapper
RUN dotnet publish "Divstack.Company.Estimation.Tool.Bootstrapper.csproj" --no-build -c Release -o /EstimationToolApi
WORKDIR /EstimationToolApi
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Divstack.Company.Estimation.Tool.Bootstrapper.dll
