FROM mcr.microsoft.com/dotnet/core/sdk:6.0 as builder
COPY /src /app
RUN dotnet publish /app/BadgeCreation.csproj -c Release -o /out 
COPY entrypoint.sh /out/entrypoint.sh

FROM mcr.microsoft.com/dotnet/core/runtime:6.0 as base
COPY --from=builder /out /app
RUN chmod +x /app/entrypoint.sh