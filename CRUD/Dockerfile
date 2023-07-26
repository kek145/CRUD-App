FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-libraries
WORKDIR /src

COPY CRUD.DAL/*.csproj CRUD.DAL/
COPY CRUD.BL/*.csproj CRUD.BL/
COPY CRUD.Domain/*.csproj CRUD.Domain/
COPY CRUD.API/*.csproj CRUD.API/
RUN dotnet restore CRUD.DAL/
RUN dotnet restore CRUD.BL/
RUN dotnet restore CRUD.Domain/
RUN dotnet restore CRUD.API/

COPY CRUD.DAL/. CRUD.DAL/
COPY CRUD.BL/. CRUD.BL/
COPY CRUD.Domain/. CRUD.Domain/

FROM build-libraries AS build-app
WORKDIR /src/CRUD.API

COPY CRUD.API/. .

RUN dotnet build -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build-app /app/publish .

EXPOSE 80

ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "CRUD.API.dll"]