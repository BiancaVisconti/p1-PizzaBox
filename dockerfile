FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR p1/
COPY . .
RUN dotnet build
RUN dotnet publish -c Release -o out PizzaBox.Client/PizzaBox.Client.csproj
CMD ["dotnet", "out/PizzaBox.Client.dll"]
