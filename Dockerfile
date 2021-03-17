FROM mcr.microsoft.com/dotnet/aspnet:5.0 as base
WORKDIR /app
EXPOSE 80
EXPOSE 443 

FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
WORKDIR /src
COPY ["./Hahn.ApplicationProcess.February2021.Web", "./Hahn.ApplicationProcess.February2021.Web"]
COPY ["./Hahn.ApplicationProcess.February2021.Domain", "./Hahn.ApplicationProcess.February2021.Domain"]
COPY ["./Hahn.ApplicationProcess.February2021.Data", "./Hahn.ApplicationProcess.February2021.Data"]
COPY ["./Hahn.ApplicationProcess.Application.sln", "./"]
RUN dotnet restore;
COPY . .
WORKDIR "/src/."
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet build -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "Hahn.ApplicationProcess.February2021.Web.dll" ]